using UnityEngine;

namespace CrashBandicoot.Players
{
    /// <summary>
    /// Component for ground, fall, wall and air jumps.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(FallState))]
    public class JumpState : AbstractState
    {
        [SerializeField] 
        private FallState fallState;
        [Tooltip("The number of jumps in the air."), Min(0)]
        public int airJumps = 0;
        [Tooltip("The maximum jump height in world units."), Min(0f)]
        public float maximumHeight = 4f;
        [Tooltip("The time (in seconds) to reach the maximum jump height."), Min(0.01f)]
        public float timeApex = 0.5f;
        [SerializeField]
        [Tooltip("Activate Forward Jump when height is at this percent."), Range(0F, 100F)] 
        private float forwardJumpPercentage = 60F;

        public int CurrentAirJumps { get; private set; }
        
        private float jumpGroundHeight;

        protected override void Reset ()
        {
            base.Reset();
            fallState = GetComponent<FallState>();
        }

        private void OnEnable () => motor.OnLand += HandleLanded;
        private void OnDisable () => motor.OnLand -= HandleLanded;

        private void OnValidate()
        {
            var gravity = GetCurrentGravity();
            motor.Gravity = gravity * -1F;
        }

        protected override void UpdateState ()
        {
            base.UpdateState();
            CheckJumpForwardTrigger();
        }

        public void UpdateInput (bool isButtonDown)
        {
            if (isButtonDown) Activate();
            else Release();
        }

        private void Activate ()
        {
            if (!CanJump()) return;
            
            var isAirJump = motor.IsAirborne && !fallState.WasJump;
            if (isAirJump) CurrentAirJumps++;

            jumpGroundHeight = transform.position.y;

            UpdateVerticalAxis();
            animator.Jump();
        }

        private void Release () => StopRisingVerticalSpeed();
        
        private void UpdateVerticalAxis()
        {
            var gravity = GetCurrentGravity();
            motor.VerticalSpeed = gravity * timeApex;
            motor.Gravity = gravity * -1F;
        }

        private void StopRisingVerticalSpeed ()
        {
            if (motor.IsRaising) motor.StopVerticalSpeed();
        }

        private void CheckJumpForwardTrigger ()
        {
            var trigger = motor.IsRaising && motor.IsMoveInputting && HasReachMaxHeight();
            if (trigger) animator.JumpForward();
        }

        private bool CanJump () =>
            IsJumpAvailable(); /*||
            fallState.WasFallingBufferJump && 
            IsGroundJumpAvailable();*/

        private bool IsJumpAvailable () =>
            IsGroundJumpAvailable()||
            IsAirJumpAvailable();/* ||
            fallState.IsJumpAvailable();*/

        private bool IsGroundJumpAvailable() => motor.IsGrounded;

        private bool IsAirJumpAvailable()
        {
            var hasAvailableJumps = CurrentAirJumps < airJumps;
            return motor.IsAirborne && hasAvailableJumps;
        }

        private bool HasReachMaxHeight () =>  GetCurrentHeight() > GetForwardJumpHeight();

        private void HandleLanded ()
        {
            CurrentAirJumps = 0;
            jumpGroundHeight = 0F;
        }
        
        private float GetForwardJumpHeight() => maximumHeight * forwardJumpPercentage * 0.01F;

        private float GetCurrentHeight () => transform.position.y - jumpGroundHeight;

        private float GetCurrentGravity()
        {
            /*
             * Gravity function extracted from the Displacement Kinematic formula:
             * 
             * Δx = v0t + 1/2 * at²; where v0 = 0, a = gravity and t = timeApex.
             * 
             * maximumHeight = gravity * timeApex² / 2
             * gravity = 2 * maximumHeight / timeApex²
             */
            return 2f * maximumHeight / (timeApex * timeApex);
        }
    }
}
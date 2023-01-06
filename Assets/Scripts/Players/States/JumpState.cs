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

        [Header("SEF")]
        [SerializeField] private AudioClip jumpSound;
        [SerializeField] private AudioClip jumpForwardSound;

        public int CurrentAirJumps { get; private set; }

        private float jumpGroundHeight;
        private bool hasJumpedForward;

        protected override void Reset()
        {
            base.Reset();
            fallState = GetComponent<FallState>();
        }

        private void OnEnable() => Motor.OnLand += HandleLanded;
        private void OnDisable() => Motor.OnLand -= HandleLanded;

        private void OnValidate()
        {
            var gravity = GetCurrentGravity();
            Motor.Gravity = gravity * -1F;
        }

        protected override void EnterState()
        {
            base.EnterState();
            player.LimbManager.Bottom.Play(jumpSound);
        }

        protected override void UpdateState()
        {
            base.UpdateState();
            CheckJumpForwardTrigger();
        }

        public void UpdateInput(bool isButtonDown)
        {
            if (isButtonDown) Activate();
            else Release();
        }

        private void Activate()
        {
            if (!IsJumpAvailable())
            {
                fallState.TryRegisterBufferJump();
                return;
            }
            Jump();
        }

        private void Release() => StopRisingVerticalSpeed();

        private void Jump()
        {
            var isAirJump = Motor.IsAirborne && !fallState.WasJump;
            if (isAirJump) CurrentAirJumps++;

            jumpGroundHeight = transform.position.y;

            UpdateVerticalAxis();
            Animator.Jump();
        }

        private void UpdateVerticalAxis()
        {
            var gravity = GetCurrentGravity();
            Motor.VerticalSpeed = gravity * timeApex;
            Motor.Gravity = gravity * -1F;
        }

        private void StopRisingVerticalSpeed()
        {
            if (Motor.IsRaising) Motor.StopVerticalSpeed();
        }

        private void CheckJumpForwardTrigger()
        {
            var trigger =
                !hasJumpedForward &&
                Motor.IsRaising &&
                Motor.IsMoveInputting &&
                HasReachMaxHeight();

            if (trigger)
            {
                hasJumpedForward = true;
                Animator.JumpForward();
                player.LimbManager.Chest.Play(jumpForwardSound);
            }
        }

        private bool IsJumpAvailable() =>
            IsGroundJumpAvailable() ||
            IsAirJumpAvailable() ||
            fallState.IsJumpAvailable();

        private bool IsGroundJumpAvailable() => Motor.IsGrounded;

        private bool IsAirJumpAvailable()
        {
            var hasAvailableJumps = CurrentAirJumps < airJumps;
            return Motor.IsAirborne && hasAvailableJumps;
        }

        private bool HasReachMaxHeight() => GetCurrentHeight() > GetForwardJumpHeight();

        private void HandleLanded()
        {
            CurrentAirJumps = 0;
            jumpGroundHeight = 0F;
            hasJumpedForward = false;

            if (fallState.IsBufferJumpAvailable()) Jump();
        }

        private float GetForwardJumpHeight() => maximumHeight * forwardJumpPercentage * 0.01F;

        private float GetCurrentHeight() => transform.position.y - jumpGroundHeight;

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
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

        public int CurrentAirJumps { get; private set; }
        public bool WasGroundedJump { get; private set; }

        protected override void Reset ()
        {
            base.Reset();
            fallState = GetComponent<FallState>();
        }

        private void OnValidate()
        {
            var gravity = GetCurrentGravity();
            motor.Gravity = gravity * -1F;
        }

        public void Press ()
        {
            if (!CanJump()) return;
            
            animator.Jump();

            WasGroundedJump = motor.IsGrounded;

            var isAirJump = motor.IsAirborne && !fallState.WasJump;
            if (isAirJump) CurrentAirJumps++;

            UpdateVerticalAxis();
        }

        public void Release () => ExitState();

        /// <summary>
        /// Returns whether any jump can be executed.
        /// </summary>
        /// <returns>Whether any jump can be executed.</returns>
        public bool CanJump() =>
            IsJumpAvailable() ||
            fallState.WasFallingBufferJump && 
            IsGroundJumpAvailable();

        protected override void ExitState()
        {
            base.ExitState();
            
            WasGroundedJump = false;
            CurrentAirJumps = 0;
            
            var isRising = motor.VerticalSpeed > 0f;
            if (isRising) motor.StopVerticalSpeed();
        }

        private bool IsJumpAvailable() =>
            IsGroundJumpAvailable() ||
            IsAirJumpAvailable() ||
            fallState.IsJumpAvailable();

        private bool IsGroundJumpAvailable() => motor.IsGrounded;

        private bool IsAirJumpAvailable()
        {
            var hasAvailableJumps = CurrentAirJumps < airJumps;
            return motor.IsAirborne && hasAvailableJumps;
        }

        private void UpdateVerticalAxis()
        {
            var gravity = GetCurrentGravity();
            motor.VerticalSpeed = gravity * timeApex;
            motor.Gravity = gravity * -1F;
        }

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
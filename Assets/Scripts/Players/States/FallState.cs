using UnityEngine;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class FallState : AbstractState
    {
        [Tooltip("The time (in frames) to still performs a jump after falling from the ground. AKA Coyote frame time."), Min(0)]
        public int fallGroundAirFrames = 30;
        [Tooltip("The time (in frames) to still performs a jump before touching the ground."), Min(0)]
        public int fallBufferFrames = 30;

        public bool WasJump { get; private set; }
        public bool WasFallingFromGround { get; private set; }
        public bool WasFallingBufferJump { get; private set; }
        
        private int lastFrame;
        private int lastBufferFrame;

        protected override void EnterState ()
        {
            base.EnterState();
            WasFallingFromGround = motor.IsGrounded;
            lastFrame = Time.frameCount;
        }

        protected override void ExitState ()
        {
            base.ExitState();
            CheckFallingBuffer();

            WasJump = false;
            WasFallingFromGround = false;

            lastFrame = 0;
            lastBufferFrame = 0;
        }
        
        public bool IsJumpAvailable ()
        {
            var isAvailable =
                !WasJump &&
                WasFallingFromGround &&
                IsInFallJumpWindow();

            if (isAvailable) WasJump = true;
            return isAvailable;
        }

        private bool IsInFallJumpWindow()
        {
            var elapsedFrames = Time.frameCount - lastFrame;
            return elapsedFrames <= fallGroundAirFrames;
        }
        
        private void CheckFallingBuffer()
        {
            var elapsedFrames = Time.frameCount - lastBufferFrame;
            WasFallingBufferJump = elapsedFrames <= fallBufferFrames;
        }
    }
}
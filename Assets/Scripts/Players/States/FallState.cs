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

        [SerializeField] private AudioClip landSound;

        public bool WasJump { get; private set; }
        public bool WasFallingFromGround { get; private set; }
        public bool WasBufferJumpRegistered { get; private set; }

        private int lastFrame;
        private int lastBufferFrame;

        void OnEnable()
        {
            Motor.OnLand += HandleLanded;
            Motor.OnFallen += HandleFallen;
        }

        void OnDisable()
        {
            Motor.OnLand -= HandleLanded;
            Motor.OnFallen -= HandleFallen;
        }

        public bool IsJumpAvailable()
        {
            var isAvailable =
                !WasJump &&
                WasFallingFromGround &&
                IsInFallJumpWindow();

            if (isAvailable) WasJump = true;
            return isAvailable;
        }

        internal void TryRegisterBufferJump()
        {
            if (!IsExecuting) return;

            lastBufferFrame = GetFrames();
            WasBufferJumpRegistered = true;
        }

        internal bool IsBufferJumpAvailable()
        {
            if (!WasBufferJumpRegistered) return false;

            var elapsedFrames = GetFrames() - lastBufferFrame;

            lastBufferFrame = 0;
            WasBufferJumpRegistered = false;

            return elapsedFrames <= fallBufferFrames;
        }

        private bool IsInFallJumpWindow()
        {
            var elapsedFrames = GetFrames() - lastFrame;
            return elapsedFrames <= fallGroundAirFrames;
        }

        private void HandleFallen()
        {
            WasFallingFromGround = Motor.IsGrounded;
            lastFrame = GetFrames();
        }

        private void HandleLanded()
        {
            lastFrame = 0;
            WasJump = false;
            WasFallingFromGround = false;
            player.LimbManager.RightFoot.Play(landSound);
        }
    }
}
using UnityEngine;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class SpinState : AbstractState
    {
        [SerializeField, Tooltip("The Spin time (in seconds)."), Min(0F)]
        private float time = 0.5F;
        [SerializeField, Tooltip("The Cooldown time (in seconds)."), Min(0F)]
        private float cooldown = 0.5F;
        [SerializeField]
        private GameObject spinVFX;

        private float lastTime;

        protected override void EnterState()
        {
            base.EnterState();
            spinVFX.SetActive(true);
        }

        protected override void ExitState()
        {
            base.ExitState();
            spinVFX.SetActive(false);
        }

        public void UpdateInput(bool isButtonDown)
        {
            //animator.SetSpinning(isButtonDown);
            if (!isButtonDown || !CanSpin()) return;

            Enable();
            Invoke(nameof(Disable), time);
        }

        private bool CanSpin() =>
            !IsExecuting &&
            !IsCooldown() &&
            !StateMachine.IsExecuting<SpawnState>() &&
            !StateMachine.IsExecuting<UnSpawnState>();

        private bool IsCooldown()
        {
            var elapsedTime = GetTime() - lastTime;
            return elapsedTime <= cooldown;
        }

        private void Enable() => animator.SetSpinning(true);

        private void Disable()
        {
            lastTime = GetTime();
            animator.SetSpinning(false);
        }
    }
}
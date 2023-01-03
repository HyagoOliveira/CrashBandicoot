using UnityEngine;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class SpawnState : AbstractState
    {
        public void Trigger() => animator.Spawn();

        protected override void EnterState()
        {
            base.EnterState();
            motor.CanMove = false;
            motor.StopMoveInput();
        }

        protected override void ExitState()
        {
            base.ExitState();
            motor.CanMove = true;
        }
    }
}
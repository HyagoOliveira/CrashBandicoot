using UnityEngine;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class SpawnState : AbstractState
    {
        public void Trigger() => Animator.Spawn();

        protected override void EnterState()
        {
            base.EnterState();
            Motor.CanMove = false;
            Motor.StopMoveInput();
        }

        protected override void ExitState()
        {
            base.ExitState();
            Motor.CanMove = true;
        }
    }
}
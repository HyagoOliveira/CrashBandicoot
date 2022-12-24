using UnityEngine;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class UnSpawnState : AbstractState
    {
        public void Trigger () => animator.UnSpawn();
        
        protected override void EnterState ()
        {
            base.EnterState();
            motor.CanMove = false;
            motor.StopMoveInput();
        }
    }
}
using UnityEngine;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class SpawnState : AbstractState 
    {
        protected override void EnterState ()
        {
            base.EnterState();
            motor.CanMove = false;
        }

        protected override void ExitState ()
        {
            base.ExitState();
            motor.CanMove = true;
        }
    }
}
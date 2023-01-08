using UnityEngine;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class UnSpawnState : AbstractState
    {
        public void Trigger() => Animator.UnSpawn();

        protected override void EnterState()
        {
            base.EnterState();
            Motor.CanMove = false;
            Motor.StopMoveInput();
            player.SoundEffects.PlayUnspawn();
        }
    }
}
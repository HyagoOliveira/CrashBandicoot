using UnityEngine;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class SpawnState : AbstractState
    {
        [SerializeField] private AudioClip portalExit;

        public void Trigger() => Animator.Spawn();

        protected override void EnterState()
        {
            base.EnterState();
            Motor.CanMove = false;
            Motor.StopMoveInput();
            player.LimbManager.Chest.Play(portalExit);
        }

        protected override void ExitState()
        {
            base.ExitState();
            Motor.CanMove = true;
        }
    }
}
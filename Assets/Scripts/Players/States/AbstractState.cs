using UnityEngine;
using ActionCode.Characters;

namespace CrashBandicoot.Players
{
    [RequireComponent(typeof(Player))]
    public abstract class AbstractState : ActionCode.AnimatorStates.AbstractState
    {
        [SerializeField] protected Player player;

        protected CharacterMotor Motor => player.Motor;
        protected PlayerAnimator Animator => player.Animator;

        protected override void Reset()
        {
            base.Reset();
            player = GetComponent<Player>();
        }
    }
}
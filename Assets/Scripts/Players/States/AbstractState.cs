using UnityEngine;
using CrashBandicoot.Characters;

namespace CrashBandicoot.Players
{
    [RequireComponent(typeof(CharacterMotor))]
    [RequireComponent(typeof(PlayerAnimator))]
    public abstract class AbstractState : ActionCode.AnimatorStates.AbstractState
    {
        [SerializeField] protected CharacterMotor motor;
        [SerializeField] protected PlayerAnimator animator;

        protected override void Reset()
        {
            base.Reset();
            motor = GetComponent<CharacterMotor>();
            animator = GetComponent<PlayerAnimator>();
        }
    }
}
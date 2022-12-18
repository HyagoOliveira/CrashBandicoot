using UnityEngine;
using ActionCode.AnimatorStates;
using CrashBandicoot.Characters;

namespace CrashBandicoot.Players
{
	[RequireComponent(typeof(CharacterMotor))]
	[RequireComponent(typeof(PlayerAnimator))]
	public abstract class AbstractState : AbstractMonoBehaviourState 
	{
		[SerializeField] protected CharacterMotor motor;
		[SerializeField] protected PlayerAnimator animator;

		protected virtual void Reset()
		{
			motor = GetComponent<CharacterMotor>();
			animator = GetComponent<PlayerAnimator>();
		}
	}
}
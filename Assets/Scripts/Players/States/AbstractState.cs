using UnityEngine;
using ActionCode.AnimatorStates;
using CrashBandicoot.Characters;
using System.Collections;

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

		public IEnumerator WaitWhileIsExecuting () => new WaitWhile(() => IsExecuting);
	}
}
using UnityEngine;

namespace ActionCode.Characters
{
	/// <summary>
	/// Abstract component for a Character.
	/// </summary>
	public abstract class AbstractCharacter : MonoBehaviour, ICharacter
	{
		[field: SerializeField] public CharacterMotor Motor { get; private set; }
		[field: SerializeField] public CharacterAnimator Animator { get; private set; }
		[field: SerializeField] public CharacterLimbManager LimbManager { get; private set; }

		protected virtual void Reset ()
		{
			Motor = GetComponentInChildren<CharacterMotor>();
			Animator = GetComponentInChildren<CharacterAnimator>();
			LimbManager = GetComponentInChildren<CharacterLimbManager>();
		}
	}
}
using UnityEngine;

namespace ActionCode.Characters
{
	/// <summary>
	/// Abstract component for Characters Sound Effects implementing <see cref="ICharacterSoundEffects"/> interface.
	/// <para>You can implement this class and create new behaviours.</para>
	/// </summary>
	public abstract class AbstractCharacterSoundEffects<T> : MonoBehaviour, ICharacterSoundEffects
		where T : ICharacterSoundEffectsData
	{
		[field: SerializeField] public CharacterLimbManager LimbManager { get; protected set; }
		[field: SerializeField] public T Data { get; protected set; }
		
		protected virtual void Reset ()
		{
			LimbManager = transform.root.
				GetComponentInChildren<CharacterLimbManager>(includeInactive: true);
		}

		public virtual void PlayLeftFootstep() => LimbManager.LeftFoot.Play(Data.LeftFootstep);
		public virtual void PlayRightFootstep() => LimbManager.RightFoot.Play(Data.RightFootstep);
		public virtual void PlayJump() => LimbManager.Bottom.Play(Data.Jump);
		public virtual void PlayLand() => LimbManager.Bottom.Play(Data.Land);
		public virtual void PlayCustom (string clip) => LimbManager.Custom.Play(Data.Custom.GetClip(clip));
		public virtual void PlayCustom (AudioClip clip) => LimbManager.Custom.Play(clip);
	}
}
using UnityEngine;
using ActionCode.Audio;

namespace ActionCode.Characters
{
	/// <summary>
	/// Base component for Characters Sound Effects.
	/// <para>You can override this class and change or create new behaviours.</para>
	/// </summary>
	public class CharacterSoundEffects : MonoBehaviour, ICharacterEffects
	{
		[SerializeField] protected CharacterLimbManager limbManager;
		[SerializeField] protected AudioClip leftFootstep;
		[SerializeField] protected AudioClip rightFootstep;
		[SerializeField] protected AudioClip jump;
		[SerializeField] protected AudioClip land;
		[SerializeField] protected AudioDictionary custom;
		
		protected virtual void Reset ()
		{
			limbManager = transform.root.
				GetComponentInChildren<CharacterLimbManager>(includeInactive: true);
		}

		public virtual void PlayLeftFootstep() => limbManager.LeftFoot.Play(leftFootstep);
		public virtual void PlayRightFootstep() => limbManager.RightFoot.Play(rightFootstep);
		public virtual void PlayJump() => limbManager.Bottom.Play(jump);
		public virtual void PlayLand() => limbManager.Bottom.Play(land);
		public virtual void PlayCustom (string clip) => PlayCustom(custom.GetClip(clip));
		
		/// <summary>
		/// Plays a custom AudioClip.
		/// </summary>
		/// <param name="clip">The AudioClip instance.</param>
		public virtual void PlayCustom (AudioClip clip) => limbManager.Custom.Play(clip);
	}
}
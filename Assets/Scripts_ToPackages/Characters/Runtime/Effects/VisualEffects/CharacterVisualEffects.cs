using System;
using UnityEngine;

namespace ActionCode.Characters
{
	/// <summary>
	/// Base component for Characters Visual Effects implementing <see cref="ICharacterVisualEffects"/> interface.
	/// <para>You can override this class and implement new behaviours.</para>
	/// </summary>
    [DisallowMultipleComponent]
    public class CharacterVisualEffects : MonoBehaviour, ICharacterVisualEffects
    {
	    [SerializeField] private ParticleSystem leftFootstep;
	    [SerializeField] private ParticleSystem rightFootstep;
	    [SerializeField] private ParticleSystem jump;
	    [SerializeField] private ParticleSystem land;
	    [SerializeField] private ParticleSystemDictionary custom;

	    void Awake () => custom.Initialize();

	    public virtual void PlayLeftFootstep () => leftFootstep.Play();
	    public virtual void PlayRightFootstep () => rightFootstep.Play();
	    public virtual void PlayJump () => jump.Play();
	    public virtual void PlayLand () => land.Play();
	    public virtual void PlayCustom (string name) => custom.Play(name);
    }
}
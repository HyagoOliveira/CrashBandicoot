using UnityEngine;

namespace ActionCode.Characters
{
	/// <summary>
	/// Base component for Characters Visual Effects.
	/// <para>You can override this class and change or create new behaviours.</para>
	/// </summary>
    [DisallowMultipleComponent]
    public class CharacterVisualEffects : MonoBehaviour, ICharacterEffects
    {
	    [SerializeField] protected ParticleSystem leftFootstep;
	    [SerializeField] protected ParticleSystem rightFootstep;
	    [SerializeField] protected ParticleSystem jump;
	    [SerializeField] protected ParticleSystem land;
	    [SerializeField] protected ParticleSystemDictionary custom;

	    void Awake () => custom.Initialize();

	    public virtual void PlayLeftFootstep () => leftFootstep.Play();
	    public virtual void PlayRightFootstep () => rightFootstep.Play();
	    public virtual void PlayJump () => jump.Play();
	    public virtual void PlayLand () => land.Play();
	    public virtual void PlayCustom (string name) => custom.Play(name);
    }
}
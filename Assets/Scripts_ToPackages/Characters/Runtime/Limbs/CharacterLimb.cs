using UnityEngine;

namespace ActionCode.Characters
{
    /// <summary>
    /// Represents a Character Limb like Head, Chest or a Hand/Foot.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioSource))]
    public sealed class CharacterLimb : MonoBehaviour
    {
        [SerializeField, Tooltip("The local AudioSource component.")]
        private AudioSource audioSource;

        private void Reset() => audioSource = GetComponent<AudioSource>();

        public void Play (AudioClip clip) => audioSource.PlayOneShot(clip);

        public void Pause () => audioSource.Pause();
        public void Resume () => audioSource.UnPause();
    }
}
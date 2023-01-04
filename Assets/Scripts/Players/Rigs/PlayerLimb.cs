using UnityEngine;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioSource))]
    public sealed class PlayerLimb : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;

        private void Reset() => audioSource = GetComponent<AudioSource>();

        public void Play(AudioClip clip) => audioSource.PlayOneShot(clip);
    }
}
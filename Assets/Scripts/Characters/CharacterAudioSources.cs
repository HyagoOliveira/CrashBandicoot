using UnityEngine;

namespace CrashBandicoot.Characters
{
    [DisallowMultipleComponent]
    public sealed class CharacterAudioSources : MonoBehaviour
    {
        [SerializeField] private AudioSource head;
        [SerializeField] private AudioSource chest;
        [SerializeField] private AudioSource foot;

        public void PlayOnHead(AudioClip clip) => head.PlayOneShot(clip);
        public void PlayOnChest(AudioClip clip) => chest.PlayOneShot(clip);
        public void PlayOnFoot(AudioClip clip) => foot.PlayOneShot(clip);
    }
}
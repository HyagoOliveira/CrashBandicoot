using UnityEngine;
using ActionCode.Characters;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class PlayerSoundEffects : MonoBehaviour 
    {
        [SerializeField] private CharacterLimbManager limbManager;
        
        [Header("Audio Clips")]
        [SerializeField] private AudioClip spawn;
        [SerializeField] private AudioClip unspawn;
        [SerializeField] private AudioClip jump;
        [SerializeField] private AudioClip jumpForward;
        [SerializeField] private AudioClip land;
        [SerializeField] private AudioClip spin;
        
        private void Reset () => limbManager = GetComponentInChildren<CharacterLimbManager>();
        
        public void PlaySpawn() => limbManager.Chest.Play(spawn);
        public void PlayUnspawn() => limbManager.Chest.Play(unspawn);
        public void PlayJump() => limbManager.Bottom.Play(jump);
        public void PlayJumpForward() => limbManager.Bottom.Play(jumpForward);
        public void PlayLand() => limbManager.Bottom.Play(land);
        public void PlaySpin() => limbManager.Chest.Play(spin);
    }
}
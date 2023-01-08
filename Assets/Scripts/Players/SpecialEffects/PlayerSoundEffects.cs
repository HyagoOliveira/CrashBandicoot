using UnityEngine;
using ActionCode.Characters;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class PlayerSoundEffects : MonoBehaviour 
    {
        [SerializeField] private CharacterLimbManager limbManager;
        
        [Header("Audio Clips")]
        [SerializeField] private AudioClip jump;
        [SerializeField] private AudioClip jumpForward;
        [SerializeField] private AudioClip land;
        [SerializeField] private AudioClip spin;
        
        private void Reset () => limbManager = GetComponentInChildren<CharacterLimbManager>();
        
        public void PlayJump() => limbManager.Bottom.Play(jump);
        public void PlayJumpForward() => limbManager.Bottom.Play(jumpForward);
        public void PlayLand() => limbManager.Bottom.Play(land);
        public void PlaySpin() => limbManager.Chest.Play(spin);
    }
}
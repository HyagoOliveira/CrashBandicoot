using UnityEngine;
using ActionCode.Audio;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Player))]
    public sealed class PlayerSoundEffects : MonoBehaviour 
    {
        [SerializeField] private Player player;
        
        [Header("Audio Clips")]
        [SerializeField] private AudioClip spawn;
        [SerializeField] private AudioClip unspawn;
        [SerializeField] private AudioClip jump;
        [SerializeField] private AudioClip jumpForward;
        [SerializeField] private AudioClip land;
        [SerializeField] private AudioClip spin;
        [SerializeField] private AudioDictionary footsteps;
        
        private void Reset () => player = GetComponent<Player>();
        
        public void PlaySpawn() => player.LimbManager.Chest.Play(spawn);
        public void PlayUnspawn() => player.LimbManager.Chest.Play(unspawn);
        public void PlayJump() => player.LimbManager.Bottom.Play(jump);
        public void PlayJumpForward() => player.LimbManager.Bottom.Play(jumpForward);
        public void PlayLand() => player.LimbManager.Bottom.Play(land);
        public void PlaySpin() => player.LimbManager.Chest.Play(spin);
        
        // Functions called from Animation clips.
        public void PlayLeftFootstep ()
        {
            if (!player.IsSpinning)
                player.LimbManager.LeftFoot.Play(footsteps.GetRandomClip());
        }

        public void PlayRightFootstep ()
        {
            if (!player.IsSpinning)
                player.LimbManager.RightFoot.Play(footsteps.GetRandomClip());
        }
    }
}
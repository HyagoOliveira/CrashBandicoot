using UnityEngine;

namespace CrashBandicoot.Characters
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimator : MonoBehaviour 
    {
        [SerializeField] protected Animator animator;
        
        private readonly int isGrounded = Animator.StringToHash("IsGrounded");
        private readonly int isAirborne = Animator.StringToHash("IsAirborne");
        private readonly int isFalling = Animator.StringToHash("IsFalling");
        private readonly int isMoveInputting = Animator.StringToHash("IsMoveInputting");

        private void Reset() => animator = GetComponent<Animator>();
        
        public void SetIsGrounded(bool value) => animator.SetBool(isGrounded, value);
        public void SetIsAirborne(bool value) => animator.SetBool(isAirborne, value);
        public void SetIsFalling(bool value) => animator.SetBool(isFalling, value);
        public void SetIsMoveInputting(bool value) => animator.SetBool(isMoveInputting, value);
    }
}
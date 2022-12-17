using UnityEngine;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    public sealed class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private readonly int spawn = Animator.StringToHash("Spawn");
        private readonly int unSpawn = Animator.StringToHash("UnSpawn");
        private readonly int isGrounded = Animator.StringToHash("IsGrounded");
        private readonly int isAirborne = Animator.StringToHash("IsAirborne");
        private readonly int isMoveInputting = Animator.StringToHash("IsMoveInputting");
        private readonly int runningSlopeIndex = Animator.StringToHash("RunningSlopeIndex");
        
        private void Reset() => animator = GetComponent<Animator>();
        
        public void Spawn() => animator.SetTrigger(spawn);
        public void UnSpawn() => animator.SetTrigger(unSpawn);

        public void SetIsGrounded(bool value) => animator.SetBool(isGrounded, value);
        public void SetIsAirborne(bool value) => animator.SetBool(isAirborne, value);
        public void SetIsMoveInputting(bool value) => animator.SetBool(isMoveInputting, value);
        
        public void ResetRunningSlope()
        {
            const float normalSlopeIndex = 0f;
            SetRunningSlopeIndex(normalSlopeIndex);
        }

        public void SetRunningSlopeUpwards()
        {
            const float upSlopeIndex = 1f;
            SetRunningSlopeIndex(upSlopeIndex);
        }

        public void SetRunningSlopeDownwards()
        {
            const float downSlopeIndex = -1f;
            SetRunningSlopeIndex(downSlopeIndex);
        }

        private void SetRunningSlopeIndex(float value) => animator.SetFloat(runningSlopeIndex, value);
    }
}

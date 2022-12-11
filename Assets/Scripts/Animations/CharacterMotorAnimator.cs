using UnityEngine;
using CrashBandicoot.Physicss;

namespace CrashBandicoot.Animators
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CharacterMotor))]
    public sealed class CharacterMotorAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private CharacterMotor motor;

        private readonly int isGrounded = Animator.StringToHash("IsGrounded");
        private readonly int isAirborne = Animator.StringToHash("IsAirborne");
        private readonly int isMoveInputting = Animator.StringToHash("IsMoveInputting");
        private readonly int respawn = Animator.StringToHash("Respawn");
        private readonly int runningSlopeIndex = Animator.StringToHash("RunningSlopeIndex");

        private void Reset()
        {
            animator = GetComponent<Animator>();
            motor = GetComponent<CharacterMotor>();
        }

        private void Update()
        {
            SetIsGrounded(motor.IsGrounded);
            SetIsAirborne(motor.IsAirborne);
            SetIsMoveInputting(motor.IsMoveInputting);
        }

        public void Respawn() => animator.SetTrigger(respawn);

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

        private void SetIsGrounded(bool value) => animator.SetBool(isGrounded, value);
        private void SetIsAirborne(bool value) => animator.SetBool(isAirborne, value);
        private void SetIsMoveInputting(bool value) => animator.SetBool(isMoveInputting, value);
        private void SetRunningSlopeIndex(float value) => animator.SetFloat(runningSlopeIndex, value);
    }
}
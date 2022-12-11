using UnityEngine;
using CrashBandicoot.Physicss;

namespace CrashBandicoot.Animators
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CharacterMotor))]
    public sealed class CharacterMotorAnimatior : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private CharacterMotor motor;

        private readonly int hillIndex = Animator.StringToHash("HillIndex");
        private readonly int isGrounded = Animator.StringToHash("IsGrounded");
        private readonly int isAirborne = Animator.StringToHash("IsAirborne");
        private readonly int isMoveInputting = Animator.StringToHash("IsMoveInputting");
        private readonly int respawn = Animator.StringToHash("Respawn");

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

        private void SetHillIndex(float value) => animator.SetFloat(hillIndex, value);
        private void SetIsGrounded(bool value) => animator.SetBool(isGrounded, value);
        private void SetIsAirborne(bool value) => animator.SetBool(isAirborne, value);
        private void SetIsMoveInputting(bool value) => animator.SetBool(isMoveInputting, value);
    }
}
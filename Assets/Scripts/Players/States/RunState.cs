using UnityEngine;
using ActionCode.AnimatorStates;
using CrashBandicoot.Physicss;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CharacterMotor))]
    [RequireComponent(typeof(PlayerAnimator))]
    public sealed class RunState : AbstractMonoBehaviourState
    {
        [SerializeField] private CharacterMotor motor;
        [SerializeField] private PlayerAnimator animator;

        private void Reset()
        {
            motor = GetComponent<CharacterMotor>();
            animator = GetComponent<PlayerAnimator>();
        }

        protected override void UpdateState()
        {
            base.UpdateState();
            UpdateAnimationAccordingWithSlopeInclination();
        }

        protected override void ExitState() => animator.ResetRunningSlope();

        private void UpdateAnimationAccordingWithSlopeInclination()
        {
            if (motor.IsOverSlope())
            {
                var dot = Vector3.Dot(motor.GroundHit.normal, transform.forward);
                var isRunningUpwardSlope = dot < 0F;
                var isRunningDownwardSlope = dot > 0F;

                if (isRunningUpwardSlope) animator.SetRunningSlopeUpwards();
                else if (isRunningDownwardSlope) animator.SetRunningSlopeDownwards();
                else animator.ResetRunningSlope();
            }
            else animator.ResetRunningSlope();
        }
    }
}
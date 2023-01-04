using UnityEngine;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class RunState : AbstractState
    {
        protected override void UpdateState()
        {
            base.UpdateState();
            UpdateAnimationAccordingWithSlopeInclination();
        }

        protected override void ExitState() => Animator.ResetRunningSlope();

        private void UpdateAnimationAccordingWithSlopeInclination()
        {
            if (Motor.IsOverSlope())
            {
                var dot = Vector3.Dot(Motor.GroundHit.normal, transform.forward);
                var isRunningUpwardSlope = dot < 0F;
                var isRunningDownwardSlope = dot > 0F;

                if (isRunningUpwardSlope) Animator.SetRunningSlopeUpwards();
                else if (isRunningDownwardSlope) Animator.SetRunningSlopeDownwards();
                else Animator.ResetRunningSlope();
            }
            else Animator.ResetRunningSlope();
        }
    }
}
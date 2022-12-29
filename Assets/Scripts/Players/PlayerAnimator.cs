using UnityEngine;
using CrashBandicoot.Characters;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class PlayerAnimator : CharacterAnimator
    {
        private readonly int spawn = Animator.StringToHash("Spawn");
        private readonly int unSpawn = Animator.StringToHash("UnSpawn");
        private readonly int jump = Animator.StringToHash("Jump");
        private readonly int jumpForward = Animator.StringToHash("JumpForward");
        private readonly int runningSlopeIndex = Animator.StringToHash("RunningSlopeIndex");
        private readonly int spinning = Animator.StringToHash("Spinning");

        private const int spinningLayerIndex = 1;

        public void Spawn() => animator.SetTrigger(spawn);
        public void UnSpawn() => animator.SetTrigger(unSpawn);
        public void Jump() => animator.SetTrigger(jump);
        public void JumpForward() => animator.SetTrigger(jumpForward);

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

        public void SetSpinning(bool value) => animator.SetBool(spinning, value);

        public bool IsSpinning() => IsState(spinning, spinningLayerIndex);

        private void SetRunningSlopeIndex(float value) => animator.SetFloat(runningSlopeIndex, value);

        private bool IsState(int id, int layer = 0) => animator.GetCurrentAnimatorStateInfo(layer).shortNameHash == id;
    }
}
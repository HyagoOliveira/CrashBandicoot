using UnityEngine;
using CrashBandicoot.Characters;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class PlayerAnimator : CharacterAnimator
    {
        private readonly int spawn = Animator.StringToHash("Spawn");
        private readonly int unSpawn = Animator.StringToHash("UnSpawn");
        private readonly int runningSlopeIndex = Animator.StringToHash("RunningSlopeIndex");
        
        public void Spawn() => animator.SetTrigger(spawn);
        public void UnSpawn() => animator.SetTrigger(unSpawn);
        
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
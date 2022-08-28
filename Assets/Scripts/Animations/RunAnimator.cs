using UnityEngine;

namespace CrashBandicoot
{
    public sealed class RunAnimator : AbstractAnimatorController
    {
        public LayerMask floorMask;
        public float upHillAngle = 30f;
        public float downHillAngle = -30f;

        private readonly int RUNNING = Animator.StringToHash("running");
        private readonly int RUNNING_INDEX = Animator.StringToHash("runningIndex");
        private readonly int HILL_INDEX = Animator.StringToHash("hillIndex");
        private readonly int SPEED_MULTIPLIER = Animator.StringToHash("runningSpeedMultiplier");

        private const float UP_HILL_INDEX = 1f;
        private const float NORMAL_HILL_INDEX = 0f;
        private const float DOWN_HILL_INDEX = -1F;

        private void Update()
        {
            UpdateHillIndex();
        }


        public void EnableRunning(bool enabled)
        {
            animator.SetBool(RUNNING, enabled);
        }

        public void SetMultiplier(float multiplier)
        {
            animator.SetFloat(SPEED_MULTIPLIER, multiplier);
        }

        private void UpdateHillIndex()
        {
            float index = NORMAL_HILL_INDEX;

            Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 0.1f, floorMask, QueryTriggerInteraction.Ignore);

            if (hit.collider)
            {
                float floorAngle = Vector3.SignedAngle(hit.normal, Vector3.up, Vector3.right);
                bool isUpHill = floorAngle > upHillAngle;
                bool isDownHill = floorAngle < downHillAngle;

                if (isUpHill) index = UP_HILL_INDEX;
                else if (isDownHill) index = DOWN_HILL_INDEX;
            }

            SetHillIndex(index);
        }

        public void SetHillIndex(float index)
        {
            animator.SetFloat(HILL_INDEX, index);
        }
    }
}
using UnityEngine;
using ActionCode.AnimatorStates;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    public sealed class PlayerCostumeManager : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private PlayerAnimator playerAnimator;
        [SerializeField] private AnimatorStateMachine stateMachine;
        [SerializeField] private PlayerCostume defaultCostume;
        [SerializeField] private PlayerCostume[] costumes;

        private void Reset() => animator = GetComponent<Animator>();

        public void SetDefaultCostume() => SetCostume(defaultCostume);

        public void SetCostume(int index) => SetCostume(costumes[index]);

        public void SetCostume(PlayerCostume costume)
        {
            DisableAllCostumes();

            animator.avatar = costume.Avatar;
            stateMachine.ResetBinders();
            playerAnimator.Spawn();

            costume.Enable();
        }

        private void DisableAllCostumes()
        {
            defaultCostume.Disable();
            foreach (var costume in costumes)
            {
                costume.Disable();
            }
        }
    }
}
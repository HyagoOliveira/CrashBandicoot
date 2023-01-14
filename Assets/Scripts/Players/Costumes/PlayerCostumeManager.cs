using UnityEngine;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class PlayerCostumeManager : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private PlayerCostume[] costumes;

        public PlayerCostume CurrentCostume { get; private set; }

        public PlayerCostume DefaultCostume => costumes[0];

        private void Reset()
        {
            player = GetComponentInParent<Player>();
            costumes = GetComponentsInChildren<PlayerCostume>(includeInactive: true);
        }

        private void Awake() => InitializeDefaultCostume();

        public void SetDefaultCostume() => SetCostume(DefaultCostume);

        public void SetCostume(int index)
        {
            var hasCostume = index >= 0 && index < costumes.Length;

            if (hasCostume) SetCostume(costumes[index]);
            else Debug.LogWarningFormat("Costume index {0} does not exist.", index);
        }

        public void SetCostume(PlayerCostume costume)
        {
            if (player.IsSpinning) return;

            CurrentCostume.Disable();
            SetCurrentCostume(costume);
            player.Animator.Respawn();
        }

        private void InitializeDefaultCostume() => SetCurrentCostume(DefaultCostume);

        private void SetCurrentCostume(PlayerCostume costume)
        {
            CurrentCostume = costume;
            costume.Enable(player.transform);
            player.StateMachine.Rebind();
        }
    }
}
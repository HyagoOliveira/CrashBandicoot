using UnityEngine;
using UnityEngine.InputSystem;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class PlayerCostumeManager : MonoBehaviour
    {
        [SerializeField] private bool playRespawnAnimation = true;
        [SerializeField] private Player player;
        [SerializeField] private PlayerCostume[] costumes;

        public PlayerCostume DefaultCostume => costumes[0];

        private void Reset()
        {
            player = GetComponentInParent<Player>();
            costumes = GetComponentsInChildren<PlayerCostume>(includeInactive: true);
        }

        //TODO delete later
        private void Update() => DebugCostumesUsingNumpad();

        public void SetDefaultCostume() => SetCostume(DefaultCostume);

        public void SetCostume(int index)
        {
            var hasCostume = index >= 0 && index < costumes.Length;

            if (hasCostume) SetCostume(costumes[index]);
            else Debug.LogWarningFormat("Costume index {0} does not exist.", index);
        }

        public void SetCostume(PlayerCostume costume)
        {
            DisableAllCostumes();
            costume.Enable();

            if (playRespawnAnimation) player.Animator.Respawn();
        }

        private void DisableAllCostumes()
        {
            foreach (var costume in costumes)
            {
                costume.Disable();
            }
        }

        private void DebugCostumesUsingNumpad()
        {
            if (Keyboard.current.numpad0Key.wasPressedThisFrame) SetCostume(0);
            else if (Keyboard.current.numpad1Key.wasPressedThisFrame) SetCostume(1);
            else if (Keyboard.current.numpad2Key.wasPressedThisFrame) SetCostume(2);
            else if (Keyboard.current.numpad3Key.wasPressedThisFrame) SetCostume(3);
            else if (Keyboard.current.numpad4Key.wasPressedThisFrame) SetCostume(4);
            else if (Keyboard.current.numpad5Key.wasPressedThisFrame) SetCostume(5);
            else if (Keyboard.current.numpad6Key.wasPressedThisFrame) SetCostume(6);
            else if (Keyboard.current.numpad7Key.wasPressedThisFrame) SetCostume(7);
            else if (Keyboard.current.numpad8Key.wasPressedThisFrame) SetCostume(8);
            else if (Keyboard.current.numpad9Key.wasPressedThisFrame) SetCostume(9);
        }
    }
}
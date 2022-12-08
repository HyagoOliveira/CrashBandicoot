using UnityEngine;

namespace CrashBandicoot.Players
{
    /// <summary>
    /// Handles inputs from <see cref="PlayerInputSettings"/>.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] private PlayerInputSettings settings;

        private void OnEnable()
        {
            settings.OnMove += HandleMove;
            settings.OnSpin += HandleSpin;
            settings.OnJump += HandleJump;
            settings.OnCrouch += HandleCrounch;
            settings.OnPauseMenu += HandlePauseMenu;
            settings.OnInventoryStatus += HandleInventoryStatus;
        }

        private void OnDisable()
        {
            settings.OnMove -= HandleMove;
            settings.OnSpin -= HandleSpin;
            settings.OnJump -= HandleJump;
            settings.OnCrouch -= HandleCrounch;
            settings.OnPauseMenu -= HandlePauseMenu;
            settings.OnInventoryStatus -= HandleInventoryStatus;
        }

        private void HandleMove(Vector2 input) => print(input);
        private void HandleSpin(bool isButtonDown) => print($"Spin: {isButtonDown}");
        private void HandleJump(bool isButtonDown) => print($"Jump: {isButtonDown}");
        private void HandleCrounch(bool isButtonDown) => print($"Crouch: {isButtonDown}");
        private void HandlePauseMenu(bool isButtonDown) => print($"PauseMenu: {isButtonDown}");
        private void HandleInventoryStatus(bool isButtonDown) => print($"Inventory Status: {isButtonDown}");
    }
}
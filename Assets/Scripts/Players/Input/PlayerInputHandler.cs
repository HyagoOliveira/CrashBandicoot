using UnityEngine;
using CrashBandicoot.Physicss;

namespace CrashBandicoot.Players
{
    /// <summary>
    /// Handles inputs from <see cref="PlayerInputSettings"/>.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CharacterMotor))]
    public sealed class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] private PlayerInputSettings settings;
        [SerializeField] private CharacterMotor motor;

        private void Reset() => motor = GetComponent<CharacterMotor>();

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

        private void HandleMove(Vector2 input) => motor.SetMovementInput(input);
        private void HandleSpin(bool isButtonDown) => print($"Spin: {isButtonDown}");
        private void HandleJump(bool isButtonDown) => print($"Jump: {isButtonDown}");
        private void HandleCrounch(bool isButtonDown) => print($"Crouch: {isButtonDown}");
        private void HandlePauseMenu(bool isButtonDown) => print($"PauseMenu: {isButtonDown}");
        private void HandleInventoryStatus(bool isButtonDown) => print($"Inventory Status: {isButtonDown}");
    }
}
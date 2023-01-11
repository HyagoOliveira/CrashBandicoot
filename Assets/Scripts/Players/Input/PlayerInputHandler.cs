using UnityEngine;
using ActionCode.Characters;

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
        [SerializeField] private PlayerSettings playerSettings;
        [SerializeField] private CharacterMotor motor;

        [Header("States")]
        [SerializeField] private JumpState jumpState;
        [SerializeField] private SpinState spinState;

        private void Reset() => motor = GetComponent<CharacterMotor>();

        private void OnEnable()
        {
            settings.OnMove += HandleMove;
            settings.OnSpin += HandleSpin;
            settings.OnJump += HandleJump;
            settings.OnCrouch += HandleCrounch;
            settings.OnSwitch += HandleSwitch;
            settings.OnInventoryStatus += HandleInventoryStatus;
        }

        private void OnDisable()
        {
            settings.OnMove -= HandleMove;
            settings.OnSpin -= HandleSpin;
            settings.OnJump -= HandleJump;
            settings.OnCrouch -= HandleCrounch;
            settings.OnSwitch -= HandleSwitch;
            settings.OnInventoryStatus -= HandleInventoryStatus;

            HandleMove(Vector2.zero);
        }

        private void HandleMove(Vector2 input) => motor.SetMoveInput(input);
        private void HandleSpin(bool isButtonDown) => spinState.UpdateInput(isButtonDown);
        private void HandleJump(bool isButtonDown) => jumpState.UpdateInput(isButtonDown);
        private void HandleCrounch(bool isButtonDown) => print($"Crouch: {isButtonDown}");

        private void HandleSwitch(bool isButtonDown)
        {
            if (isButtonDown) playerSettings.Switch();
        }
        
        private void HandleInventoryStatus(bool isButtonDown) => print($"Inventory Status: {isButtonDown}");
    }
}
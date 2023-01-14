using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static CrashBandicoot.Players.PlayerInput;
using static UnityEngine.InputSystem.InputAction;

namespace CrashBandicoot.Players
{
    [CreateAssetMenu(fileName = "PlayerInputSettings", menuName = Global.SettingsPath.PLAYERS + "Input Settings", order = 110)]
    public sealed class PlayerInputSettings : ScriptableObject
    {
        public event Action<Vector2> OnMove;
        public event Action<Vector2> OnLook;

        public event Action<bool> OnSpin;
        public event Action<bool> OnJump;
        public event Action<bool> OnCrouch;
        public event Action<bool> OnSwitch;
        public event Action<bool> OnPauseMenu;
        public event Action<bool> OnInventoryStatus;

        private PlayerActions actions;

        internal void Initialize()
        {
            var input = new PlayerInput();
            actions = input.Player;
        }

        internal void EnableActions()
        {
            actions.Enable();
            BindActions();
        }

        internal void DisableActions()
        {
            UnbindActions();
            actions.Disable();
        }

        internal void ResetAxes()
        {
            actions.Move.Disable();
            actions.Look.Disable();

            actions.Move.Enable();
            actions.Look.Enable();
        }

        private void BindActions()
        {
            BindAxisAction(actions.Move, HandleMove);
            BindAxisAction(actions.Look, HandleLook);

            BindButtonAction(actions.Spin, HandleSpin);
            BindButtonAction(actions.Jump, HandleJump);
            BindButtonAction(actions.Crouch, HandleCrouch);
            BindButtonAction(actions.Switch, HandleSwitch);
            BindButtonAction(actions.PauseMenu, HandlePauseMenu);
            BindButtonAction(actions.InventoryStatus, HandleInventoryStatus);
        }

        private void UnbindActions()
        {
            UnbindAxisAction(actions.Move, HandleMove);
            UnbindAxisAction(actions.Look, HandleLook);

            UnbindButtonAction(actions.Spin, HandleSpin);
            UnbindButtonAction(actions.Jump, HandleJump);
            UnbindButtonAction(actions.Crouch, HandleCrouch);
            UnbindButtonAction(actions.Switch, HandleSwitch);
            UnbindButtonAction(actions.PauseMenu, HandlePauseMenu);
            UnbindButtonAction(actions.InventoryStatus, HandleInventoryStatus);
        }

        private void HandleMove(CallbackContext ctx) => OnMove?.Invoke(ctx.ReadValue<Vector2>());
        private void HandleLook(CallbackContext ctx) => OnLook?.Invoke(ctx.ReadValue<Vector2>());

        private void HandleSpin(CallbackContext ctx) => OnSpin?.Invoke(ctx.ReadValueAsButton());
        private void HandleJump(CallbackContext ctx) => OnJump?.Invoke(ctx.ReadValueAsButton());
        private void HandleCrouch(CallbackContext ctx) => OnCrouch?.Invoke(ctx.ReadValueAsButton());
        private void HandleSwitch(CallbackContext ctx) => OnSwitch?.Invoke(ctx.ReadValueAsButton());
        private void HandlePauseMenu(CallbackContext ctx) => OnPauseMenu?.Invoke(ctx.ReadValueAsButton());
        private void HandleInventoryStatus(CallbackContext ctx) => OnInventoryStatus?.Invoke(ctx.ReadValueAsButton());

        private static void BindAxisAction(InputAction axis, Action<CallbackContext> handler)
        {
            axis.started += handler;
            axis.performed += handler;
            axis.canceled += handler;
        }

        private static void UnbindAxisAction(InputAction axis, Action<CallbackContext> handler)
        {
            axis.started -= handler;
            axis.performed -= handler;
            axis.canceled -= handler;
        }

        private static void BindButtonAction(InputAction button, Action<CallbackContext> handler)
        {
            button.started += handler;
            button.canceled += handler;
        }

        private static void UnbindButtonAction(InputAction button, Action<CallbackContext> handler)
        {
            button.started -= handler;
            button.canceled -= handler;
        }
    }
}
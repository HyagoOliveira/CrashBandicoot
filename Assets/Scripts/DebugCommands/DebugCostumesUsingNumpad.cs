using CrashBandicoot.Players;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CrashBandicoot.DebugCommands
{
    [ExecuteInEditMode]
    [DisallowMultipleComponent]
    public sealed class DebugCostumesUsingNumpad : MonoBehaviour
    {
        [SerializeField] private PlayerSettings playerSettings;

        private void Update()
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

        private void OnEnable()
        {
            print(
                "Player Costumes Debug is enabled.\n" +
                "Use the Numpad from 0 to 9 to change the current player costume."
            );
        }

        private void OnDisable() => print("Player Costumes Debug is disabled.");

        private void SetCostume(int index) =>
            playerSettings.Current.CostumeManager.SetCostume(index);
    }
}
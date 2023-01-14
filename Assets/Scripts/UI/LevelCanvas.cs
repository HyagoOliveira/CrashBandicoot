using UnityEngine;
using IngameDebugConsole;
using ActionCode.PauseSystem;
using CrashBandicoot.Players;
using ActionCode.AnimatorStates;

namespace CrashBandicoot.UI
{
    [DisallowMultipleComponent]
    public sealed class LevelCanvas : MonoBehaviour
    {
        [SerializeField] private PauseSettings pauseSettings;
        [SerializeField] private PlayerSettings playerSettings;
        [SerializeField] private DebugLogManager logManager;

        private PlayerManager playerManager;

        private void Awake() => playerManager = FindObjectOfType<PlayerManager>();

        private void OnEnable()
        {
            logManager.OnLogWindowShown += HandleLogWindowShown;
            logManager.OnLogWindowHidden += HandleLogWindowHidden;
        }

        private void OnDisable()
        {
            logManager.OnLogWindowShown -= HandleLogWindowShown;
            logManager.OnLogWindowHidden -= HandleLogWindowHidden;
        }

        private void HandleLogWindowShown()
        {
            playerManager.enabled = false;
            SetPlayerStateMachineGUIEnable(false);
            pauseSettings.Pause();
        }

        private void HandleLogWindowHidden()
        {
            pauseSettings.Resume();
            playerManager.enabled = true;
            SetPlayerStateMachineGUIEnable(true);
        }

        private void SetPlayerStateMachineGUIEnable(bool enabled)
        {
            var hasStateMachineGUI = playerSettings.Current.
                TryGetComponent(out AnimatorStateMachineGUI stateMachineGUI);
            if (hasStateMachineGUI) stateMachineGUI.enabled = enabled;
        }
    }
}
using UnityEngine;
using IngameDebugConsole;
using ActionCode.PauseSystem;

namespace CrashBandicoot.UI
{
    [DisallowMultipleComponent]
    public sealed class LevelCanvas : MonoBehaviour
    {
	    [SerializeField] private PauseSettings pauseSettings;
	    [SerializeField] private DebugLogManager logManager;

        private void OnEnable ()
        {
            logManager.OnLogWindowShown += HandleLogWindowShown;
            logManager.OnLogWindowHidden += HandleLogWindowHidden;
        }
        
        private void OnDisable ()
        {
            logManager.OnLogWindowShown -= HandleLogWindowShown;
            logManager.OnLogWindowHidden -= HandleLogWindowHidden;
        }

        private void HandleLogWindowShown () => pauseSettings.Pause();
        private void HandleLogWindowHidden () => pauseSettings.Resume();
    }
}
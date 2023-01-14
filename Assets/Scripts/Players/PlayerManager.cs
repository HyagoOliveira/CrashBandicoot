using System.Collections;
using ActionCode.PauseSystem;
using UnityEngine;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(Global.ExecutionOrder.MANAGERS)]
    public sealed class PlayerManager : MonoBehaviour
    {
        [SerializeField] private PlayerSettings settings;
        [SerializeField] private PlayerInputSettings inputSettings;
        [SerializeField] private PauseSettings pauseSettings;
        [SerializeField] private float timeToSpawnPlayers = 0.1f;

        private void Awake()
        {
            settings.Initialize();
            inputSettings.Initialize();
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(timeToSpawnPlayers);
            settings.Spawn();
        }

        private void OnEnable()
        {
            inputSettings.EnableActions();
            inputSettings.OnPauseMenu += HandlePauseMenu;
            settings.OnPlayerSwitched += HandlePlayerSwitched;
        }

        private void OnDisable()
        {
            inputSettings.DisableActions();
            inputSettings.OnPauseMenu -= HandlePauseMenu;
            settings.OnPlayerSwitched -= HandlePlayerSwitched;
        }

        private void HandlePlayerSwitched() => inputSettings.ResetAxes();

        private void HandlePauseMenu(bool isButtonDown)
        {
            if (!isButtonDown) return;

            pauseSettings.Toggle();
            inputSettings.ResetAxes();
        }
    }
}
using System.Collections;
using UnityEngine;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    [DefaultExecutionOrder(Global.ExecutionOrder.MANAGERS)]
    public sealed class PlayerManager : MonoBehaviour
    {
        [SerializeField] private PlayerSettings settings;
        [SerializeField] private PlayerInputSettings inputSettings;
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

        private void OnEnable ()
        {
            inputSettings.EnableActions();
            settings.OnPlayerSwitched += HandlePlayerSwitched;
        }

        private void OnDisable ()
        {
            inputSettings.DisableActions();
            settings.OnPlayerSwitched -= HandlePlayerSwitched;
        }

        private void HandlePlayerSwitched () => inputSettings.ResetAxes();
    }
}
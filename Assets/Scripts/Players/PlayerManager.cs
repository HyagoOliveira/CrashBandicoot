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

        private void Awake()
        {
            settings.Initialize();
            inputSettings.Initialize();
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(0.1F);
            settings.Spawn();
        }

        private void OnEnable() => inputSettings.EnableActions();
        private void OnDisable() => inputSettings.DisableActions();
    }
}
using UnityEngine;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class PlayerManager : MonoBehaviour
    {
        [SerializeField] private PlayerSettings settings;
        [SerializeField] private PlayerInputSettings inputSettings;

        private void Awake() => inputSettings.Initialize();
        private void OnEnable() => inputSettings.EnableActions();
        private void OnDisable() => inputSettings.DisableActions();
    }
}
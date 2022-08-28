using UnityEngine;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class PlayerInputManager : MonoBehaviour
    {
        [SerializeField]
        private PlayerInputSettings settings;

        private void Awake() => settings.Initialize();
        private void OnEnable() => settings.EnableActions();
        private void OnDisable() => settings.DisableActions();
    }
}
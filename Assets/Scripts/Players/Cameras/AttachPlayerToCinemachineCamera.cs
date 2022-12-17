using UnityEngine;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public abstract class AttachPlayerToCinemachineCamera : MonoBehaviour
    {
        [SerializeField] private PlayerSettings settings;

        private void Reset() => FindCamera();
        private void OnEnable() => AddListeners();
        private void OnDisable() => RemoveListeners();

        protected abstract void FindCamera();
        protected abstract void SwitchCameraTo(Player player);

        private void AddListeners()
        {
            settings.OnPlayerSpawned += HandleOnPlayerSpawned;
            settings.OnPlayerSwitched += HandleOnPlayerSwitched;
        }

        private void RemoveListeners()
        {
            settings.OnPlayerSpawned -= HandleOnPlayerSpawned;
            settings.OnPlayerSwitched -= HandleOnPlayerSwitched;
        }

        private void HandleOnPlayerSpawned() => SwitchCameraTo(settings.Current);
        private void HandleOnPlayerSwitched() => SwitchCameraTo(settings.Current);
    }
}
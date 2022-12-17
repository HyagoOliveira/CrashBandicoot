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
            settings.OnPlayerSpawn += HandleOnPlayerSpawn;
            settings.OnPlayerSwitch += HandleOnPlayerSwitch;
        }

        private void RemoveListeners()
        {
            settings.OnPlayerSpawn -= HandleOnPlayerSpawn;
            settings.OnPlayerSwitch -= HandleOnPlayerSwitch;
        }

        private void HandleOnPlayerSpawn(Player player) => SwitchCameraTo(player);
        private void HandleOnPlayerSwitch() => SwitchCameraTo(settings.Current);
    }
}
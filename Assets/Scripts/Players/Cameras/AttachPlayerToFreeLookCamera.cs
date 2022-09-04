using UnityEngine;
using Cinemachine;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CinemachineFreeLook))]
    public sealed class AttachPlayerToFreeLookCamera : MonoBehaviour
    {
        [SerializeField] private PlayerSettings settings;
        [SerializeField] private CinemachineFreeLook virtualCamera;

        private void Reset() => virtualCamera = GetComponent<CinemachineFreeLook>();

        private void OnEnable() => AddListeners();
        private void OnDisable() => RemoveListeners();

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
        private void HandleOnPlayerSwitch(Player player, Player _) => SwitchCameraTo(player);

        private void SwitchCameraTo(Player player)
        {
            virtualCamera.Follow = player.transform;
            virtualCamera.LookAt = player.transform;
        }
    }
}
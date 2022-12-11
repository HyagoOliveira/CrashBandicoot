using UnityEngine;
using Cinemachine;

namespace CrashBandicoot.Players
{
    [RequireComponent(typeof(CinemachineFreeLook))]
    public sealed class AttachPlayerToFreeLookCamera : AttachPlayerToCinemachineCamera
    {
        [SerializeField] private CinemachineFreeLook virtualCamera;

        protected override void FindCamera() => virtualCamera = GetComponent<CinemachineFreeLook>();

        protected override void SwitchCameraTo(Player player)
        {
            virtualCamera.Follow = player.transform;
            virtualCamera.LookAt = player.transform;
        }
    }
}
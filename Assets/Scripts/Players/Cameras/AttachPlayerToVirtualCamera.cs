using UnityEngine;
using Cinemachine;

namespace CrashBandicoot.Players
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public sealed class AttachPlayerToVirtualCamera : AttachPlayerToCinemachineCamera
    {
        [SerializeField] private CinemachineVirtualCamera virtualCamera;

        protected override void FindCamera() => virtualCamera = GetComponent<CinemachineVirtualCamera>();
        protected override void SwitchCameraTo(Player player) => virtualCamera.Follow = player.transform;
    }
}
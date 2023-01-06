using UnityEngine;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class PlayerCostume : MonoBehaviour
    {
        public SkinnedMeshRenderer[] meshRenderers;

        private void Reset() =>
            meshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();

        internal void Enable() => gameObject.SetActive(true);
        internal void Disable() => gameObject.SetActive(false);
    }
}
using UnityEngine;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class PlayerCostume : MonoBehaviour
    {
        [field: SerializeField] public Avatar Avatar { get; private set; }

        internal void Enable() => gameObject.SetActive(true);
        internal void Disable() => gameObject.SetActive(false);
    }
}
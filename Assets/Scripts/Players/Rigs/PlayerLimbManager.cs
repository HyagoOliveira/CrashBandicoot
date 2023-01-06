using UnityEngine;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class PlayerLimbManager : MonoBehaviour
    {
        [field: SerializeField] public PlayerLimb Head { get; private set; }
        [field: SerializeField] public PlayerLimb Chest { get; private set; }
        [field: SerializeField] public PlayerLimb Bottom { get; private set; }

        private void Reset()
        {
            Head = GetOrCreate<PlayerLimb>("Head");
            Chest = GetOrCreate<PlayerLimb>("Chest");
            Bottom = GetOrCreate<PlayerLimb>("Bottom");
        }

        private T GetOrCreate<T>(string name) where T : Component
        {
            var child = FindChildRecursively(transform, name);
            if (child == null)
            {
                Debug.LogErrorFormat("'{0}' was not found", name);
                return null;
            }

            return child.GetComponent<T>() ?? child.gameObject.AddComponent<T>();
        }

        private static Transform FindChildRecursively(Transform parent, string childName)
        {
            Transform result = null;

            foreach (Transform child in parent)
            {
                if (child.name.Equals(childName)) return child.transform;

                result = FindChildRecursively(child, childName);
                if (result != null) break;
            }

            return result;
        }
    }
}
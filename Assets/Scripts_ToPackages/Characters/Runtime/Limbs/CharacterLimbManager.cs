using UnityEngine;

namespace ActionCode.Characters
{
    /// <summary>
    /// Manager for <see cref="CharacterLimb"/>.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class CharacterLimbManager : MonoBehaviour
    {
        [field: SerializeField] public CharacterLimb Head { get; private set; }
        [field: SerializeField] public CharacterLimb Chest { get; private set; }
        [field: SerializeField] public CharacterLimb LeftHand { get; private set; }
        [field: SerializeField] public CharacterLimb RightHand { get; private set; }
        [field: SerializeField] public CharacterLimb Bottom { get; private set; }
        [field: SerializeField] public CharacterLimb LeftFoot { get; private set; }
        [field: SerializeField] public CharacterLimb RightFoot { get; private set; }
        [field: SerializeField] public CharacterLimb Custom { get; private set; }

        private void Reset()
        {
            Head = GetOrCreate<CharacterLimb>("Head");
            Chest = GetOrCreate<CharacterLimb>("Chest");
            Bottom = GetOrCreate<CharacterLimb>("Bottom");
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
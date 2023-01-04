using UnityEngine;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class PlayerLimbManager : MonoBehaviour
    {
        [field: SerializeField] public Transform RootBone { get; private set; }
        [field: SerializeField] public PlayerLimb Head { get; private set; }
        [field: SerializeField] public PlayerLimb Chest { get; private set; }
        [field: SerializeField] public PlayerLimb LeftFoot { get; private set; }
        [field: SerializeField] public PlayerLimb RightFoot { get; private set; }

        private void Reset()
        {
            const string root = "Ct_Hips__SKN_0_JNT";
            const string head = "Ct_Head__SKN_0_JNT";
            const string chest = "Ct_Spine__SKN_2_JNT";
            const string leftFoot = "Lf_Leg__SKN_3_JNT";
            const string rightFoot = "Rt_Leg__SKN_3_JNT";

            RootBone = FindChildRecursively(transform, root);
            Head = GetOrCreate<PlayerLimb>(head);
            Chest = GetOrCreate<PlayerLimb>(chest);
            LeftFoot = GetOrCreate<PlayerLimb>(leftFoot);
            RightFoot = GetOrCreate<PlayerLimb>(rightFoot);
        }

        private T GetOrCreate<T>(string name) where T : Component
        {
            var child = FindChildRecursively(transform, name);
            if (child == null)
            {
                Debug.LogErrorFormat("'{0}' was not found,");
                return null;
            }

            var component = child.GetComponent<T>() ??
                child.gameObject.AddComponent<T>();

            return component;
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
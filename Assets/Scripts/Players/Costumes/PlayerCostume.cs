using UnityEngine;
using System.Collections.Generic;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class PlayerCostume : MonoBehaviour
    {
        public SkinnedMeshRenderer[] meshRenderers;

        private void Reset() =>
            meshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();

        internal void UpdateSkinnedMeshBones(Transform rootBone, Dictionary<string, Transform> bones)
        {
            var skinnedBones = GetSkinBones(meshRenderers[0], bones);
            foreach (var mesh in meshRenderers)
            {
                mesh.rootBone = rootBone;
                mesh.bones = skinnedBones;
            }
        }

        internal void Enable() => gameObject.SetActive(true);
        internal void Disable() => gameObject.SetActive(false);

        private static Transform[] GetSkinBones(SkinnedMeshRenderer mesh, Dictionary<string, Transform> bones)
        {
            var newBones = new Transform[mesh.bones.Length];

            for (int i = 0; i < mesh.bones.Length; i++)
            {
                var boneName = mesh.bones[i].name;
                newBones[i] = bones[boneName];
            }

            return newBones;
        }
    }
}
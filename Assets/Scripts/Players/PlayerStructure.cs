using UnityEngine;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class PlayerStructure : MonoBehaviour
    {
        [SerializeField] private AudioSource head;
        [SerializeField] private AudioSource chest;
        [SerializeField] private AudioSource leftFoot;
        [SerializeField] private AudioSource rightFoot;

        private void Reset()
        {
            const string path = "Ct_Root__SKN_0_JNT/Ct_Hips__SKN_0_JNT/";
            const string chestPath = path + "Ct_Spine__SKN_0_JNT/Ct_Spine__SKN_1_JNT/" +
                "Ct_Spine__SKN_2_JNT";
            const string headPath = path + "Ct_Spine__SKN_0_JNT/Ct_Spine__SKN_1_JNT/" +
                "Ct_Spine__SKN_2_JNT/Ct_Neck__SKN_0_JNT/Ct_Head__SKN_0_JNT";
            const string leftLegPath = path + "Lf_Leg__SKN_0_JNT/Lf_Leg__SKN_1_JNT/" +
                "Lf_Leg__SKN_2_JNT/Lf_Leg__SKN_3_JNT";
            const string rightLegPath = path + "Rt_Leg__SKN_0_JNT/Rt_Leg__SKN_1_JNT/" +
                "Rt_Leg__SKN_2_JNT/Rt_Leg__SKN_3_JNT";

            head = GetOrCreate<AudioSource>(headPath);
            chest = GetOrCreate<AudioSource>(chestPath);
            leftFoot = GetOrCreate<AudioSource>(leftLegPath);
            rightFoot = GetOrCreate<AudioSource>(rightLegPath);
        }

        public void PlayOnHead(AudioClip clip) => head.PlayOneShot(clip);
        public void PlayOnChest(AudioClip clip) => chest.PlayOneShot(clip);
        public void PlayOnLeftFoot(AudioClip clip) => leftFoot.PlayOneShot(clip);
        public void PlayOnRightFoot(AudioClip clip) => rightFoot.PlayOneShot(clip);

        private T GetOrCreate<T>(string path) where T : Component
        {
            var child = transform.Find(path);
            if (child == null) return null;

            var component = child.GetComponent<T>();
            if (component == null) component = child.gameObject.AddComponent<T>();

            return component;
        }
    }
}
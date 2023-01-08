using UnityEngine;
using ActionCode.Audio;

namespace ActionCode.Characters
{
    /// <summary>
    /// ScriptableObject implementation of <see cref="ICharacterSoundEffectsData"/>.
    /// <para>You can override this class to add more AudiClips.</para>
    /// </summary>
    [CreateAssetMenu(fileName = "ScriptableCharacterSoundEffectsData", menuName = "ActionCode/Characters/ScriptableCharacterSoundEffects", order = 110)]
    public class ScriptableCharacterSoundEffectsData : ScriptableObject, ICharacterSoundEffectsData
    {
        [field: SerializeField] public AudioClip LeftFootstep { get; private set; }
        [field: SerializeField] public AudioClip RightFootstep { get; private set; }
        [field: SerializeField] public AudioClip Jump { get; private set; }
        [field: SerializeField] public AudioClip Land { get; private set; }
        [field: SerializeField] public AudioDictionary Custom { get; private set; }
    }
}
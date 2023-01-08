using System;
using UnityEngine;
using ActionCode.Audio;

namespace ActionCode.Characters
{
    /// <summary>
    /// Serializable implementation of <see cref="ICharacterSoundEffectsData"/>.
    /// <para>You can override this class to add more AudiClips.</para>
    /// </summary>
    [Serializable]
    public class CharacterSoundEffectsData : ICharacterSoundEffectsData
    {
        [field: SerializeField] public AudioClip LeftFootstep { get; private set; }
        [field: SerializeField] public AudioClip RightFootstep { get; private set; }
        [field: SerializeField] public AudioClip Jump { get; private set; }
        [field: SerializeField] public AudioClip Land { get; private set; }
        [field: SerializeField] public AudioDictionary Custom { get; private set; }
    }
}
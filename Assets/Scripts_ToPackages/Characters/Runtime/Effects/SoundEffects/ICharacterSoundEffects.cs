using UnityEngine;

namespace ActionCode.Characters
{
    /// <summary>
    /// Interface used on objects able to have Character Sound Effects.
    /// </summary>
    public interface ICharacterSoundEffects : ICharacterEffects
    {
        /// <summary>
        /// Plays a custom AudioClip.
        /// </summary>
        /// <param name="clip">The AudioClip name.</param>
        void PlayCustom (AudioClip clip);
    }
}
using ActionCode.Audio;
using UnityEngine;

namespace ActionCode.Characters
{
    public interface ICharacterSoundEffectsData 
    {
        /// <summary>
        /// The custom Audio Dictionary.
        /// </summary>
        AudioDictionary Custom { get; }
        
        /// <summary>
        /// The AudioClip for the left footstep.
        /// </summary>
        AudioClip LeftFootstep { get; }
        
        /// <summary>
        /// The AudioClip for the right footstep.
        /// </summary>
        AudioClip RightFootstep { get; }
        
        /// <summary>
        /// The AudioClip for the jump.
        /// </summary>
        AudioClip Jump { get; }
        
        /// <summary>
        /// The AudioClip for the land.
        /// </summary>
        AudioClip Land { get; }
    }
}
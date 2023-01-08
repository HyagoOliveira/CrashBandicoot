using UnityEngine;

namespace ActionCode.Characters
{
	/// <summary>
	/// Serializable implementation for a Character Sound Effects.
	/// <para>
	/// You can further override this class and <see cref="CharacterSoundEffectsData"/>
	/// to change behaviours.
	/// </para>
	/// </summary>
    [DisallowMultipleComponent]
    public class CharacterSoundEffects : AbstractCharacterSoundEffects<CharacterSoundEffectsData> 
    {
    }
}
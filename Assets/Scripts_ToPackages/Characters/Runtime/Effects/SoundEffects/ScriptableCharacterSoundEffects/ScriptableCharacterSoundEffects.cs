using UnityEngine;

namespace ActionCode.Characters
{
	/// <summary>
	/// Scriptable Object implementation for a Character Sound Effects.
	/// <para>
	/// You can further override this class and <see cref="ScriptableCharacterSoundEffectsData"/>
	/// to change behaviours.
	/// </para>
	/// </summary>
    [DisallowMultipleComponent]
    public class ScriptableCharacterSoundEffects : 
		AbstractCharacterSoundEffects<ScriptableCharacterSoundEffectsData> 
    {
    }
}
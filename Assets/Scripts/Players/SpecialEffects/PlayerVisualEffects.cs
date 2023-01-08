using UnityEngine;
using ActionCode.Characters;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class PlayerVisualEffects : MonoBehaviour 
    {
	    [SerializeField] private CharacterLimbManager limbManager;
        
        [field: SerializeField]
        public GameObject Spin { get; private set; }
        
        private void Reset () => limbManager = GetComponentInChildren<CharacterLimbManager>();
    }
}
using UnityEngine;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class PlayerCostume : MonoBehaviour
    {
        [SerializeField] Transform rootSKN;

        private void Reset () => rootSKN = transform.Find("Ct_Root__SKN_0_JNT");

        internal void Enable (Transform root)
        {
            rootSKN.SetParent(root);
            rootSKN.SetAsFirstSibling();
            
            gameObject.SetActive(true);  
        }

        internal void Disable ()
        {
            rootSKN.SetParent(transform);
            gameObject.SetActive(false);  
        } 
    }
}
using UnityEngine;

namespace CrashBandicoot
{
    [RequireComponent(typeof(Animator))]
    public abstract class AbstractAnimatorController : MonoBehaviour
    {
        [SerializeField] protected Animator animator;

        protected virtual void Reset()
        {
            animator = GetComponent<Animator>();
        }
    }
}
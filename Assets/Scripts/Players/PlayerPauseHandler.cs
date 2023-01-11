using UnityEngine;
using ActionCode.PauseSystem;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Player))]
    public sealed class PlayerPauseHandler : MonoBehaviour 
    {
	    [SerializeField, Tooltip("The Pause System settings.")] 
	    private PauseSettings settings;
	    [SerializeField] private Player player;

	    private void Reset ()
	    {
		    player = GetComponent<Player>();
	    }

	    private void OnEnable ()
	    {
		    settings.OnPaused += HandlePaused;
		    settings.OnResumed += HandleResumed;
	    }

	    private void OnDisable ()
	    {
		    settings.OnPaused -= HandlePaused;
		    settings.OnResumed -= HandleResumed;
	    }

	    public void Pause ()
	    {
		    player.Motor.enabled = false;
		    player.Animator.enabled = false;
		    player.InputHandler.enabled = false;
		    player.Animator.SetPlaybackSpeed(0f);
	    }

	    public void Resume ()
	    {
		    player.Motor.enabled = true;
		    player.Animator.enabled = true;
		    player.InputHandler.enabled = true;
		    player.Animator.SetPlaybackSpeed(1f);
	    }

	    private void HandlePaused () => Pause();
	    private void HandleResumed () => Resume();
    }
}
using System;
using UnityEngine;
using ActionCode.AnimatorStates;
using ActionCode.Characters;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CharacterMotor))]
    [RequireComponent(typeof(PlayerAnimator))]
    [RequireComponent(typeof(PlayerSoundEffects))]
    [RequireComponent(typeof(PlayerInputHandler))]
    [RequireComponent(typeof(AnimatorStateMachine))]
    public sealed class Player : MonoBehaviour, IEnable, IDisable, IEquatable<Player>
    {
        [SerializeField, Tooltip("The player identifier.")]
        private PlayerName id = PlayerName.None;

        [field: SerializeField]
        public CharacterMotor Motor { get; private set; }

        [field: SerializeField]
        public PlayerAnimator Animator { get; private set; }

        [field: SerializeField]
        public AnimatorStateMachine StateMachine { get; private set; }
        
        [field: SerializeField]
        public PlayerSoundEffects SoundEffects { get; private set; }
        
        [field: SerializeField]
        public PlayerVisualEffects VisualEffects { get; private set; }
        
        [field: SerializeField]
        public PlayerInputHandler InputHandler { get; private set; }

        [field: SerializeField]
        public CharacterLimbManager LimbManager { get; private set; }

        [field: SerializeField]
        public PlayerCostumeManager CostumeManager { get; private set; }

        /// <summary>
        /// The player identifier name.
        /// </summary>
        public PlayerName Name => id;

        /// <summary>
        /// Whether the player is currently enabled.
        /// </summary>
        public bool Enabled => gameObject.activeInHierarchy;

        /// <summary>
        /// Whether the player is currently spinning.
        /// </summary>
        public bool IsSpinning => StateMachine.IsExecuting<SpinState>();

        public int Index { get; internal set; }

        private void Reset()
        {
            Motor = GetComponent<CharacterMotor>();
            Animator = GetComponent<PlayerAnimator>();
            StateMachine = GetComponent<AnimatorStateMachine>();
            SoundEffects = GetComponent<PlayerSoundEffects>();
            VisualEffects = GetComponent<PlayerVisualEffects>();
            InputHandler = GetComponent<PlayerInputHandler>();
            LimbManager = GetComponentInChildren<CharacterLimbManager>();
            CostumeManager = GetComponentInChildren<PlayerCostumeManager>();
        }

        /// <summary>
        /// Places the player at the given position and rotation.
        /// </summary>
        /// <param name="position">World position.</param>
        /// <param name="rotation">World rotation.</param>
        public void Place(Vector3 position, Quaternion rotation) =>
            transform.SetPositionAndRotation(position, rotation);

        /// <summary>
        /// Switches the place between the given player.
        /// </summary>
        /// <param name="nextPlayer">The player to switch for.</param>
        public void SwitchPlace(Player nextPlayer)
        {
            var position = nextPlayer.transform.position;
            var rotation = nextPlayer.transform.rotation;
            Place(position, rotation);
        }

        /// <summary>
        /// Enables the player.
        /// </summary>
        public void Enable()
        {
            gameObject.SetActive(true);
            //TODO enable all necessary components.
        }

        /// <summary>
        /// Disables the player.
        /// </summary>
        public void Disable()
        {
            gameObject.SetActive(false);
            //TODO disable all necessary components.
        }

        /// <summary>
        /// Checks if is able to switch from.
        /// </summary>
        /// <returns></returns>
        public bool IsAbleToSwitchOut () => Motor.IsGrounded && Enabled && !IsSpinning;

        /// <summary>
        /// Checks if is able to switch into.
        /// </summary>
        /// <returns></returns>
        public bool IsAbleToSwitchIn() => !Enabled;

        /// <summary>
        /// Checks if the given player is equals to this.
        /// </summary>
        /// <param name="other">The player to test.</param>
        /// <returns>True if both players are the same. False otherwise.</returns>
        public bool Equals(Player other) => Name == other.Name;

        internal void Destroy()
        {
            Destroy(gameObject);
            // TODO dispose other components here.
        }
    }
}
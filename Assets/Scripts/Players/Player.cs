using System;
using UnityEngine;

namespace CrashBandicoot.Players
{
    [DisallowMultipleComponent]
    public sealed class Player : MonoBehaviour, IEnable, IDisable, IEquatable<Player>
    {
        [SerializeField, Tooltip("The player identifier.")]
        private PlayerName id = PlayerName.None;

        /// <summary>
        /// The player identifier name.
        /// </summary>
        public PlayerName Name => id;

        /// <summary>
        /// Places the player at the given position and rotation.
        /// </summary>
        /// <param name="position">World position.</param>
        /// <param name="rotation">World rotation.</param>
        public void Place(Vector3 position, Quaternion rotation)
        {
            transform.SetPositionAndRotation(position, rotation);
        }

        public void Switch(Player nextPlayer)
        {
            var position = nextPlayer.transform.position;
            var rotation = nextPlayer.transform.rotation;

            transform.SetPositionAndRotation(position, rotation);
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
        /// Checks if is able to switch.
        /// </summary>
        /// <returns></returns>
        public bool IsAbleToSwitch() => !gameObject.activeInHierarchy;
        //TODO && check if spawn animation is finished

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
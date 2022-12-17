using System;
using System.Collections.Generic;
using UnityEngine;

namespace CrashBandicoot.Players
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = Global.SettingsPath.PLAYERS + "Settings", order = 110)]
    public sealed class PlayerSettings : ScriptableObject
    {
        [SerializeField, Tooltip("The first Player to be spawned.")]
        private PlayerName first = PlayerName.CrashBandicoot;
        [SerializeField, Tooltip("The Players prefabs.")]
        private Player[] prefabs;

        /// <summary>
        /// Action fired when a Player is spawned.
        /// </summary>
        public event Action OnPlayerSpawned;
        
        /// <summary>
        /// Action fired when a Player is despawned.
        /// </summary>
        public event Action OnPlayerDeSpawned;

        /// <summary>
        /// Action fired when a Player is switched.
        /// </summary>
        public event Action OnPlayerSwitched;

        /// <summary>
        /// Action fired when a Player dies.
        /// </summary>
        public event Action OnPlayerDied;

        /// <summary>
        /// The last active Player.
        /// </summary>
        public Player Last => players[lastName];

        /// <summary>
        /// The current active Player.
        /// </summary>
        public Player Current => players[currentName];

        private PlayerName lastName;
        private PlayerName currentName;
        private Dictionary<PlayerName, Player> players;

        internal void Initialize() => InstantiatePrefabs();

        /// <summary>
        /// Spawns the first Player only if no other one is enabled.
        /// </summary>
        public void Spawn()
        {
            var playerName = first;
            var place = GetSpawnPlace();
            var isPlayerEnabledInScene = TryGetFirstPlayerEnabled(out Player player);

            if (isPlayerEnabledInScene)
            {
                playerName = player.Name;
                place = (player.transform.position, player.transform.rotation);
            }
            
            Spawn(playerName, position: place.Item1, rotation: place.Item2);
        }

        /// <summary>
        /// Spawns the given Player using the position and rotation.
        /// </summary>
        /// <param name="player">The Player to spawn.</param>
        /// <param name="position">The world position to spawn.</param>
        /// <param name="rotation">The world rotation to spawn.</param>
        public void Spawn(PlayerName player, Vector3 position, Quaternion rotation)
        {
            lastName = PlayerName.None;
            currentName = player;

            Current.Enable();
            Current.Place(position, rotation);

            OnPlayerSpawned?.Invoke();
        }

        /// <summary>
        /// DeSpawns the current Player.
        /// </summary>
        public void DeSpawn() => OnPlayerDeSpawned?.Invoke();

        /// <summary>
        /// Switches into the next Player.
        /// <para>It checks if switch is possible.</para>
        /// </summary>
        public void Switch() => Switch(GetNextPlayerName());

        /// <summary>
        /// Switches into the given player if available.
        /// </summary>
        /// <param name="name">The Player to switch.</param>
        public void Switch(PlayerName name)
        {
            if (!IsAbleToSwitchFor(name, out Player nextPlayer)) return;
            
            Current.Switch(nextPlayer);

            lastName = currentName;
            currentName = name;

            OnPlayerSwitched?.Invoke();
        }

        /// <summary>
        /// Kills the given player.
        /// </summary>
        /// <param name="name">The Player to kill.</param>
        public void Kill(PlayerName name)
        {
            OnPlayerDied?.Invoke();
            players[name].Destroy();
            players[name] = null;
        }

        /// <summary>
        /// Disables all the instantiated Players.
        /// </summary>
        public void Disable()
        {
            foreach (var player in players.Values)
            {
                player.Disable();
            }
        }

        /// <summary>
        /// Gets the next Player name based on the current one.
        /// </summary>
        /// <returns></returns>
        public PlayerName GetNextPlayerName()
        {
            //TODO improve this part using a proper Indexed Dictionary collection.
            var index = -1;
            var names = new PlayerName[players.Count];
            players.Keys.CopyTo(names, index: 0);
            for (int i = 0; i < names.Length; i++)
            {
                if (currentName == names[i])
                {
                    index = i;
                    break;
                }
            }

            if (++index >= names.Length) index = 0;
            return names[index];
        }

        /// <summary>
        /// Checks if is able to switch into the given player.
        /// </summary>
        /// <param name="name">The Player name trying to switch.</param>
        /// <param name="player">The Player if available.</param>
        /// <returns>Whether is possible to switch for the given player.</returns>
        public bool IsAbleToSwitchFor(PlayerName name, out Player player)
        {
            var hasPlayer = Contains(name, out player);
            return hasPlayer && player.IsAbleToSwitch();
        }
        
        /// <summary>
        /// Checks if contains the given player and references it back.
        /// </summary>
        /// <param name="name">The Player name trying to get.</param>
        /// <param name="player">The Player if available.</param>
        /// <returns>Whether contains the player.</returns>
        public bool Contains(PlayerName name, out Player player) =>
            players.TryGetValue(name, out player);

        private void InstantiatePrefabs()
        {
            var instances = GetScenePlayerInstances();
            players = new Dictionary<PlayerName, Player>(prefabs.Length);

            foreach (var prefab in prefabs)
            {
                var prefabName = prefab.Name;
                var hasPlayerInstanceInScene = instances.TryGetValue(prefabName, out Player player);

                if (!hasPlayerInstanceInScene)
                {
                    player = Instantiate(
                        prefab, 
                        position: Vector3.zero,
                        rotation: Quaternion.identity
                    );

                    player.gameObject.name = prefab.name;
                    player.gameObject.SetActive(false);
                }

                players.Add(player.Name, player);
            }
        }

        private bool TryGetFirstPlayerEnabled (out Player enabledPlayer)
        {
            foreach (var player in players.Values)
            {
                if (!player.Enabled) continue;
                
                enabledPlayer = player;
                return true;
            }

            enabledPlayer = null;
            return false;
        }

        private static (Vector3, Quaternion) GetSpawnPlace ()
        {
            //TODO Add default SpawnPlace GameObject in each level and use it.
            return (Vector3.zero, Quaternion.identity);
        }
        
        private static Dictionary<PlayerName, Player> GetScenePlayerInstances()
        {
            var instances = new Dictionary<PlayerName, Player>();

            foreach (var player in FindObjectsOfType<Player>(includeInactive: true))
            {
                instances.Add(player.Name, player);
            }

            return instances;
        }
    }
}
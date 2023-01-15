using UnityEngine;
using IngameDebugConsole;

namespace CrashBandicoot.DebugCommands
{
    [DisallowMultipleComponent]
    public sealed class DebugCommandsManager : MonoBehaviour
    {
        [SerializeField] private DebugCostumesUsingNumpad debugCostumes;

        private const string debugCostumesCommand = "debugCostumes";

        private void Reset()
        {
            debugCostumes = GetComponent<DebugCostumesUsingNumpad>();

            EnableCostumesDebbuger(false);
        }

        private void OnEnable()
        {
            DebugLogConsole.AddCommand<bool>(
                debugCostumesCommand,
                "Debugs the current Player Costumers using the Numpad.",
                EnableCostumesDebbuger
            );
        }

        private void OnDisable()
        {
            DebugLogConsole.RemoveCommand(debugCostumesCommand);
        }

        private void EnableCostumesDebbuger(bool enabled) => debugCostumes.enabled = enabled;
    }
}
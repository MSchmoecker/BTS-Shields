using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace Shields {
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class Plugin : BaseUnityPlugin {
        public const string PluginGUID = "com.maxsch.BelowTheStone.Shields";
        public const string PluginName = "Shields";
        public const string PluginVersion = "0.0.1";

        public static ManualLogSource Log { get; private set; }

        private void Awake() {
            Harmony harmony = new Harmony(PluginGUID);
            harmony.PatchAll();

            Log = Logger;
        }
    }
}

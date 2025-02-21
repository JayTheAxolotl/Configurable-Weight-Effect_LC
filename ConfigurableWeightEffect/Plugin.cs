using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace ConfigurableWeightEffect;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;

    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
    }



    // All debug code beyond this point, remove for final release
    public static string Weight;
    
    [HarmonyPatch(typeof(ItemCharger))]
    [HarmonyPatch("ChargeItem")]
    [HarmonyPostfix]
    static void OnItemCharge()
    {
        Logger.LogInfo($"Current Player Weight is: {Weight}");
    }
}
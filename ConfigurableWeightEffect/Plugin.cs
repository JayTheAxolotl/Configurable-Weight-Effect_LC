using BepInEx;
using BepInEx.Logging;
using ConfigurableWeightEffect.Patches;
using HarmonyLib;
using MonoMod.ModInterop;

namespace ConfigurableWeightEffect;

[BepInPlugin(modGUID, modName, modVersion)]
public class ConfigurableWeightEffect : BaseUnityPlugin
{
    public const string modGUID = "org.configurable-weight-effect.axian";
    public const string modName = "Configurable Weight Effect";
    public const string modVersion = "1.0.0";
    
    internal static new ManualLogSource Logger;
    
    private readonly Harmony harmony = new Harmony(modGUID);

    private static ConfigurableWeightEffect Instance;
    
    private void Awake()
    {
        // Plugin startup logic
        
        if (Instance == null)
        {
            Instance = this;
        }
        
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {modGUID} is loaded!");
        
        harmony.PatchAll(typeof(ConfigurableWeightEffect));
        harmony.PatchAll(typeof(PlayerControllerB_patches));
    }

    

    // All debug code beyond this point, remove for final release
    public static float Weight;
    
    [HarmonyPatch(typeof(ItemCharger))]
    [HarmonyPatch("ChargeItem")]
    [HarmonyPostfix]
    static void OnItemCharge()
    {
        Logger.LogInfo($"Current Player Weight is: {Weight}");
    }
}
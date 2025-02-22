using GameNetcodeStuff;
using HarmonyLib;

namespace ConfigurableWeightEffect.Patches;

[HarmonyPatch(typeof(PlayerControllerB))]
[HarmonyPatch("Update")]

public class PlayerControllerB_patches
{
    // Just a temporary variable for easier readibility
    private static float float1;
    public static float divisor = ConfigurableWeightEffect.divisor;
    
    [HarmonyPrefix]
    public static void PrefixPatch(PlayerControllerB __instance)
    {
        float1 = __instance.carryWeight - 1;
        float1 = float1 / divisor;
        __instance.carryWeight = float1 + 1;
        
        // DEBUG LINE
        ConfigurableWeightEffect.Weight = __instance.carryWeight;
    }

    [HarmonyPostfix]
    public static void PostfixPatch(PlayerControllerB __instance)
    {
        float1 = __instance.carryWeight - 1;
        float1 = float1 * divisor;
        __instance.carryWeight = float1 + 1;
    }
}
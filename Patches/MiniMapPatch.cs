using HarmonyLib;
using UnityEngine;
using ValheimHudScaler.Minimap;

namespace ValheimHudScaler.Patches
{
    internal static class MinimapPatches
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(global::Minimap), "Start")]
        private static void MinimapStartPostfix(global::Minimap __instance)
        {
            MinimapHudChanger changer = Object.FindAnyObjectByType<MinimapHudChanger>();
            changer?.SetMinimapInstance(__instance);
        }
    }
}
using HarmonyLib;
using UnityEngine;

namespace ValheimHudScaler.Patches
{
    internal static class MinimapPatches
    {
        private const float MinimapZoomMultiplier = 1.25f;

        [HarmonyPostfix]
        [HarmonyPatch(typeof(global::Minimap), "Start")]
        private static void MinimapStartPostfix(global::Minimap __instance)
        {
            if (__instance == null)
            {
                return;
            }

            if (__instance.m_mapImageSmall != null)
            {
                __instance.m_mapImageSmall.rectTransform.localScale = Vector3.one * MinimapZoomMultiplier;
            }

            if (__instance.m_mapImageLarge != null)
            {
                __instance.m_mapImageLarge.rectTransform.localScale = Vector3.one * MinimapZoomMultiplier;
            }

            if (__instance.m_mapSmall != null)
            {
                __instance.m_mapSmall.transform.localScale = Vector3.one * MinimapZoomMultiplier;
            }

            if (__instance.m_largeRoot != null)
            {
                __instance.m_largeRoot.transform.localScale = Vector3.one * MinimapZoomMultiplier;
            }
        }

    }
}
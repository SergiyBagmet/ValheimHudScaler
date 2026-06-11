using HarmonyLib;
using UnityEngine;
using ValheimHudScaler.MiniMap;

namespace ValheimHudScaler.MiniMap
{
    [HarmonyPatch(typeof(global::Minimap), "Start")]
    public static class MiniMapPatch
    {
        private static float _lastScale = -1f; // для оптимизации, чтобы не применять масштаб, если он не изменился

        private static void Postfix(global::Minimap __instance)
        {
            var manager = ValheimHudScalerPlugin.Instance?.MiniMapHudManager;
            if (manager == null)
                return;

            float scale = manager.CurrentScale;
            if (Mathf.Approximately(scale, _lastScale))
                return;

            _lastScale = scale;

            Vector3 targetScale = Vector3.one * scale;

            if (__instance.m_smallRoot != null)
                __instance.m_smallRoot.transform.localScale = targetScale;

            if (__instance.m_mapImageSmall != null)
                __instance.m_mapImageSmall.rectTransform.localScale = targetScale;

            if (__instance.m_mapSmall != null)
                __instance.m_mapSmall.transform.localScale = targetScale;
        }
    }
}
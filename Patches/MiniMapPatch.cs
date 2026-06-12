using HarmonyLib;
using UnityEngine;

namespace ValheimHudScaler.MiniMap
{
    [HarmonyPatch(typeof(global::Minimap), "Start")]
    public static class MiniMapPatch
    {
        private static float _lastScale = -1f;
        private static global::Minimap _currentMinimap;
        private static bool _subscribed; //проверка, чтобы не подписываться на событие несколько раз при повторных вызовах Start (например, при загрузке разных сцен)

        [HarmonyPostfix]
        private static void Postfix(global::Minimap __instance)
        {
            _currentMinimap = __instance;

            var manager = ValheimHudScalerPlugin.Instance?.MiniMapHudManager;
            if (manager == null)
                return;

            if (!_subscribed)
            {
                manager.ScaleChanged += ApplyScale; // подписываемся на событие изменения масштаба
                _subscribed = true;
            }

            ApplyScale(manager.GetScaleForMinimap()); // применяем текущий масштаб при каждом вызове Start, чтобы учесть возможные изменения при загрузке разных сцен
        }

        private static void ApplyScale(float scale) // метод для применения масштаба к объектам миникарты
        {
            if (_currentMinimap == null || Mathf.Approximately(scale, _lastScale))
                return;

            _lastScale = scale; // сохраняем последний примененный масштаб, чтобы избежать лишних изменений при повторных вызовах Start без изменения масштаба

            Vector3 targetScale = Vector3.one * scale;

            if (_currentMinimap.m_smallRoot != null)
                _currentMinimap.m_smallRoot.transform.localScale = targetScale;

            if (_currentMinimap.m_mapImageSmall != null)
                _currentMinimap.m_mapImageSmall.rectTransform.localScale = targetScale;

            if (_currentMinimap.m_mapSmall != null)
                _currentMinimap.m_mapSmall.transform.localScale = targetScale;

            Debug.Log("[HudScaler] Patch applied scale " + scale + " to minimap objects");
        }
    }
}
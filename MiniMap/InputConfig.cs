using BepInEx.Configuration;
using UnityEngine;

namespace ValheimHudScaler.Minimap
{
    public class InputConfig
    {
        public ConfigEntry<KeyCode> MinimapScaleIncreaseKey { get; private set; }
        public ConfigEntry<KeyCode> MinimapScaleDecreaseKey { get; private set; }
        public ConfigEntry<float> MinimapScaleAmount { get; private set; }

        public ConfigEntry<KeyCode> MiniHudScaleIncreaseKey { get; private set; }
        public ConfigEntry<KeyCode> MiniHudScaleDecreaseKey { get; private set; }
        public ConfigEntry<float> MiniHudScaleAmount { get; private set; }

        public ConfigEntry<KeyCode> FrameToggleCircleKey { get; private set; }

        public void Bind(ConfigFile config)
        {
            MinimapScaleIncreaseKey = config.Bind(
                "Input",
                "MinimapScaleIncreaseKey",
                KeyCode.Equals,
                "Key to increase the minimap scale (use '=' key).");

            MinimapScaleDecreaseKey = config.Bind(
                "Input",
                "MinimapScaleDecreaseKey",
                KeyCode.Minus,
                "Key to decrease the minimap scale (use '-' key).");

            MinimapScaleAmount = config.Bind(
                "Input",
                "MinimapScaleAmount",
                0.1f,
                "Scale step for minimap scaling.");

            MiniHudScaleIncreaseKey = config.Bind(
                "Input",
                "MiniHudScaleIncreaseKey",
                KeyCode.Equals,
                "Key to increase the mini HUD scale when holding Shift.");

            MiniHudScaleDecreaseKey = config.Bind(
                "Input",
                "MiniHudScaleDecreaseKey",
                KeyCode.Minus,
                "Key to decrease the mini HUD scale when holding Shift.");

            MiniHudScaleAmount = config.Bind(
                "Input",
                "MiniHudScaleAmount",
                0.1f,
                "Scale step for mini HUD scaling.");

            FrameToggleCircleKey = config.Bind(
                "Input",
                "FrameToggleCircleKey",
                KeyCode.RightBracket,
                "Key to toggle the minimap frame between circle and previous shape.");
        }
    }
}

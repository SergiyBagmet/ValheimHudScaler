using BepInEx.Configuration;
using UnityEngine;

namespace ValheimHudScaler.MiniMap
{
    public class Config
    {
        public ConfigEntry<KeyCode> MiniHudScaleModifierKey { get; private set; } //shift
        public ConfigEntry<KeyCode> MiniHudScaleIncreaseKey { get; private set; } // +
        public ConfigEntry<KeyCode> MiniHudScaleDecreaseKey { get; private set; } // -
        public ConfigEntry<float> MiniHudScaleAmount { get; private set; } // на сколько увеличивать/уменьшать масштаб при каждом нажатии +/-
        public ConfigEntry<float> MiniHudScaleValue { get; private set; } // текущее значение масштаба, сохраняемое в конфиге

        //public ConfigEntry<KeyCode> MinimapScaleIncreaseKey { get; private set; }
        //public ConfigEntry<KeyCode> MinimapScaleDecreaseKey { get; private set; }
        //public ConfigEntry<float> MinimapScaleAmount { get; private set; }

        //public ConfigEntry<KeyCode> FrameToggleCircleKey { get; private set; }

        public void Bind(ConfigFile config)
        {
            MiniHudScaleModifierKey = config.Bind(
                "Input",
                "MiniHudScaleModifierKey",
                KeyCode.LeftShift,
                "Modifier key to enable mini HUD scaling.");
                
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

            MiniHudScaleValue = config.Bind(
                "General",
                "MiniHudScaleValue",
                1.0f,
                "Current scale value for the mini HUD, saved in the config.");
            /*
            FrameToggleCircleKey = config.Bind(
                "Input",
                "FrameToggleCircleKey",
                KeyCode.RightBracket,
                "Key to toggle the minimap frame between circle and previous shape.");
            */
            
        }
    }
}

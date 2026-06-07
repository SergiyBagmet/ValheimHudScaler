using UnityEngine;

namespace ValheimHudScaler.Minimap
{
    public class UserInput : MonoBehaviour
    {
        private MinimapHudChanger hudChanger;
        private InputConfig config;

        public void Initialize(MinimapHudChanger changer, InputConfig config)
        {
            hudChanger = changer;
            this.config = config;
        }

        private void Update()
        {
            if (hudChanger == null || config == null)
                return;

            bool shiftHeld = ZInput.GetKey(KeyCode.LeftShift) || ZInput.GetKey(KeyCode.RightShift);

            if (ZInput.GetKeyDown(config.MinimapScaleIncreaseKey.Value) && !shiftHeld)
            {
                hudChanger.ChangeMinimapScale(config.MinimapScaleAmount.Value);
            }

            if (ZInput.GetKeyDown(config.MinimapScaleDecreaseKey.Value) && !shiftHeld)
            {
                hudChanger.ChangeMinimapScale(-config.MinimapScaleAmount.Value);
            }

            if (ZInput.GetKeyDown(config.MiniHudScaleIncreaseKey.Value) && shiftHeld)
            {
                hudChanger.ChangeMiniHudScale(config.MiniHudScaleAmount.Value);
            }

            if (ZInput.GetKeyDown(config.MiniHudScaleDecreaseKey.Value) && shiftHeld)
            {
                hudChanger.ChangeMiniHudScale(-config.MiniHudScaleAmount.Value);
            }

            if (ZInput.GetKeyDown(config.FrameToggleCircleKey.Value))
            {
                hudChanger.ToggleCircleFrame();
            }
        }
    }
}
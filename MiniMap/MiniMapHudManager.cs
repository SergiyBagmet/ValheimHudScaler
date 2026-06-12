using UnityEngine;

namespace ValheimHudScaler.MiniMap
{
    public class MiniMapHudManager
    {
        private readonly Config config;
        private readonly InputManager inputManager;

        public float CurrentScale { get; private set; }
        public event System.Action<float> ScaleChanged;

        public MiniMapHudManager(Config config, InputManager inputManager)
        {
            Debug.Log("[HudScaler] MiniMapHudManager constructor start");

            this.config = config;
            this.inputManager = inputManager;

            CurrentScale = Mathf.Clamp(
                config.MiniHudScaleValue.Value, // начальный масштаб из конфига
                0.75f, // минимальный масштаб
                3f);    // максимальный масштаб

            inputManager.IncreaseHudScaleRequested += Increase; // подписываемся на события от InputManager
            inputManager.DecreaseHudScaleRequested += Decrease;

            Debug.Log("[HudScaler] MiniMapHudManager subscribed to input events");
        }

        public void Increase()
        {
            Debug.Log("[HudScaler] Increase event received, current=" + CurrentScale);
            SetScale(CurrentScale + config.MiniHudScaleAmount.Value);
        }

        public void Decrease()
        {
            Debug.Log("[HudScaler] Decrease event received, current=" + CurrentScale);
            SetScale(CurrentScale - config.MiniHudScaleAmount.Value);
        }

        private void SetScale(float value)
        {
            CurrentScale = Mathf.Clamp(value, 0.75f, 3f); // ограничиваем масштаб в разумных пределах

            config.MiniHudScaleValue.Value = CurrentScale;
            Debug.Log("[HudScaler] Scale changed to " + CurrentScale);
            ScaleChanged?.Invoke(CurrentScale);
        }

        public float GetScaleForMinimap()
        {
            return CurrentScale;
        }

        public void Dispose()
        {
            if (inputManager != null)
            {
                inputManager.IncreaseHudScaleRequested -= Increase; // отписываемся от событий при уничтожении
                inputManager.DecreaseHudScaleRequested -= Decrease;
            }
        }
    }
}
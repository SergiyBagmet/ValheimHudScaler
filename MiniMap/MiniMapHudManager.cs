using UnityEngine;

namespace ValheimHudScaler.MiniMap
{
    public class MiniMapHudManager
    {
        private readonly Config config;
        private readonly InputManager inputManager;

        public float CurrentScale { get; private set; }

        public MiniMapHudManager(Config config, InputManager inputManager)
        {
            this.config = config;
            this.inputManager = inputManager;

            CurrentScale = Mathf.Clamp(
                config.MiniHudScaleValue.Value, // начальный масштаб из конфига
                0.75f, // минимальный масштаб
                3f);    // максимальный масштаб

            inputManager.IncreaseHudScaleRequested += Increase; // подписываемся на события от InputManager
            inputManager.DecreaseHudScaleRequested += Decrease;
        }

        public void Increase()
        {
            SetScale(CurrentScale + config.MiniHudScaleAmount.Value);
        }

        public void Decrease()
        {
            SetScale(CurrentScale - config.MiniHudScaleAmount.Value);
        }

        private void SetScale(float value)
        {
            CurrentScale = Mathf.Clamp(value, 0.75f, 3f); // ограничиваем масштаб в разумных пределах

            config.MiniHudScaleValue.Value = CurrentScale;
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
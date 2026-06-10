using System;
using UnityEngine;


using ValheimHudScaler.MiniMap;

public class InputManager : MonoBehaviour
{
    private readonly Config config;

    public event Action IncreaseHudScaleRequested;
    public event Action DecreaseHudScaleRequested;

    private void Update()
    {
        if (!ZInput.GetKey(config.MiniHudScaleModifierKey.Value))
            return;

        if (ZInput.GetKeyDown(config.MiniHudScaleIncreaseKey.Value))
        {
            IncreaseHudScaleRequested?.Invoke();
        }

        if (ZInput.GetKeyDown(config.MiniHudScaleDecreaseKey.Value))
        {
            DecreaseHudScaleRequested?.Invoke();
        }
    }
}
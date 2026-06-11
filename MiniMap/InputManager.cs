using System;
using UnityEngine;


using ValheimHudScaler.MiniMap;

public class InputManager : MonoBehaviour
{
    private Config config;
    
    public event Action IncreaseHudScaleRequested;
    public event Action DecreaseHudScaleRequested;

    public void Initialize(Config config)
    {
        this.config = config;
    }

    private void Update()
    {   
        if (config == null)
            return; 

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
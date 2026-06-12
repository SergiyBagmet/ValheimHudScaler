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
        Debug.Log("[HudScaler] InputManager initialized");
    }

    private void Update()
    {   
        if (config == null)
            return; 

        if (!ZInput.GetKey(config.MiniHudScaleModifierKey.Value))
            return;

        if (ZInput.GetKeyDown(config.MiniHudScaleIncreaseKey.Value))
        {
            Debug.Log("[HudScaler] Increase key pressed");
            IncreaseHudScaleRequested?.Invoke();
        }

        if (ZInput.GetKeyDown(config.MiniHudScaleDecreaseKey.Value))
        {
            Debug.Log("[HudScaler] Decrease key pressed");
            DecreaseHudScaleRequested?.Invoke();
        }
    }
}
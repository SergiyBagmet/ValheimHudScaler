using BepInEx;
using HarmonyLib;
using UnityEngine;

using ValheimHudScaler.MiniMap;

[BepInPlugin("Shampusiha.ValheimHudScaler", "ValheimHudScaler", "1.0.0")]
public class ValheimHudScalerPlugin : BaseUnityPlugin
{
    public static ValheimHudScalerPlugin Instance { get; private set; }

    internal Config HudConfig;
    internal MiniMapHudManager MiniMapHudManager;

    private Harmony harmony;
    private InputManager inputManager;

    private void Awake()
    {
        Debug.Log("[HudScaler] Plugin Awake started");

        Instance = this;

        HudConfig = new Config();
        HudConfig.Bind(Config);

        var inputObject = new GameObject("MiniMapInput");
        DontDestroyOnLoad(inputObject);
        Debug.Log("[HudScaler] Input object made persistent across scenes");

        inputManager = inputObject.AddComponent<InputManager>();
        inputManager.Initialize(HudConfig);

        MiniMapHudManager = new MiniMapHudManager(HudConfig, inputManager);
        Debug.Log("[HudScaler] MiniMapHudManager created");

        harmony = new Harmony("Shampusiha.ValheimHudScaler");
        harmony.PatchAll();
        Debug.Log("[HudScaler] Harmony PatchAll finished");
    }

    private void OnDestroy()
    {
        Debug.Log("[HudScaler] Plugin OnDestroy started");

        MiniMapHudManager?.Dispose();

        if (inputManager != null)
            Destroy(inputManager.gameObject);

        harmony?.UnpatchSelf();
    }
}
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
        Instance = this;

        HudConfig = new Config();
        HudConfig.Bind(Config);

        var inputObject = new GameObject("MiniMapInput");
        inputManager = inputObject.AddComponent<InputManager>();
        inputManager.Initialize(HudConfig);

        MiniMapHudManager = new MiniMapHudManager(HudConfig, inputManager);

        harmony = new Harmony("Shampusiha.ValheimHudScaler");
        harmony.PatchAll();
    }

    private void OnDestroy()
    {
        MiniMapHudManager?.Dispose();

        if (inputManager != null)
            Destroy(inputManager.gameObject);

        harmony?.UnpatchSelf();
    }
}
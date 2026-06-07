using BepInEx;
using HarmonyLib;
using UnityEngine;


using ValheimHudScaler.Minimap;



[BepInPlugin("Shampusiha.ValheimHudScaler", "ValheimHudScaler", "1.0.0")]
public class ValheimHudScalerPlugin : BaseUnityPlugin
{
    private Harmony harmony;
    private MinimapHudChanger hudChanger;
    private UserInput userInput;
    private InputConfig inputConfig;

    private void Awake()
    {
        harmony = new Harmony("Shampusiha.ValheimHudScaler");
        harmony.PatchAll();

        inputConfig = new InputConfig();
        inputConfig.Bind(Config);

        var hudGameObject = new GameObject("HudScaler");
        hudChanger = hudGameObject.AddComponent<MinimapHudChanger>();
        hudChanger.Init();

        userInput = hudGameObject.AddComponent<UserInput>();
        userInput.Initialize(hudChanger, inputConfig);
        DontDestroyOnLoad(hudGameObject);
    }

    private void OnDestroy()
    {
        hudChanger?.Shutdown();
        harmony.UnpatchSelf();
    }
}
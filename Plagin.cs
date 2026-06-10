using BepInEx;
using HarmonyLib;
using UnityEngine;

using ValheimHudScaler.MiniMap;

[BepInPlugin("Shampusiha.ValheimHudScaler", "ValheimHudScaler", "1.0.0")]
public class ValheimHudScalerPlugin : BaseUnityPlugin
{   
    internal static ValheimHudScalerPlugin Instance; // для доступа к конфигу из других классов
    internal Config HudConfig; // для хранения настроек, связанных с миникартой

    private Harmony harmony; // для управления патчами
    
    private void Awake()
    {
        Instance = this;
        HudConfig = new Config();
        HudConfig.Bind(Config);

        harmony = new Harmony("Shampusiha.ValheimHudScaler");
        harmony.PatchAll();


        var hudGameObject = new GameObject("HudScaler");
        //hudChanger = hudGameObject.AddComponent<MinimapHudChanger>();
        //hudChanger.Init();

        //userInput = hudGameObject.AddComponent<UserInput>();
        //userInput.Initialize(hudChanger, inputConfig);
        //DontDestroyOnLoad(hudGameObject);
    }

    private void OnDestroy()
    {
        harmony.UnpatchSelf(); // удаляем все патчи при выгрузке плагина
    }
}
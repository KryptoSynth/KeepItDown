﻿using HarmonyLib;
using Unity.Netcode;
using UnityEngine;

namespace KeepItDown; 

internal static class AudioPatches {
    static string GetFormattedName(Object gameObject) {
        return gameObject.name.Replace("(Clone)", "").Replace("Item", "");
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(NoisemakerProp), nameof(NoisemakerProp.Start))]
    static void NoiseMakerProp_Start_Postfix(NoisemakerProp __instance) {
        var gameObject = __instance.gameObject;
        var name = GetFormattedName(gameObject);
        KeepItDownPlugin.Instance.Bind(name, gameObject, __instance.maxLoudness, v => __instance.maxLoudness = v);
        KeepItDownPlugin.Instance.Bind(name, gameObject, __instance.minLoudness, v => __instance.minLoudness = v);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(AnimatedItem), nameof(AnimatedItem.Start))]
    static void AnimatedItem_Start_Postfix(AnimatedItem __instance) {
        var name = GetFormattedName(__instance.gameObject);
        KeepItDownPlugin.Instance.BindAudioSource(name, __instance.itemAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(RadarBoosterItem), nameof(RadarBoosterItem.Start))]
    static void RadarBoosterItem_Start_Postfix(RadarBoosterItem __instance) {
        KeepItDownPlugin.Instance.BindAudioSource("RadarBoosterPing", __instance.pingAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(ShipAlarmCord), "Start")]
    static void ShipAlarmCord_Start_Postfix(ShipAlarmCord __instance) {
        KeepItDownPlugin.Instance.BindAudioSources("ShipAlarm", __instance.hornClose, __instance.hornFar);
        KeepItDownPlugin.Instance.BindAudioSource("ShipAlarmCord", __instance.cordAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(BoomboxItem), nameof(BoomboxItem.Start))]
    static void BoomboxItem_Start_Postfix(BoomboxItem __instance) {
        KeepItDownPlugin.Instance.BindAudioSource("Boombox", __instance.boomboxAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(WalkieTalkie), nameof(WalkieTalkie.Start))]
    static void WalkieTalkie_Start_Postfix(WalkieTalkie __instance) {
        KeepItDownPlugin.Instance.BindAudioSource("Walkie-talkie", __instance.thisAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(FlashlightItem), nameof(FlashlightItem.Start))]
    static void FlashlightItem_Start_Postfix(FlashlightItem __instance) {
        KeepItDownPlugin.Instance.BindAudioSource("Flashlight", __instance.flashlightAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(SprayPaintItem), nameof(SprayPaintItem.Start))]
    static void SprayPaintItem_Start_Postfix(SprayPaintItem __instance) {
        KeepItDownPlugin.Instance.BindAudioSource("Spraycan", __instance.sprayAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(Landmine), "Start")]
    static void Landmine_Start_Postfix(Landmine __instance) {
        KeepItDownPlugin.Instance.BindAudioSource("Landmine", __instance.mineAudio);
    }
    
        [HarmonyPostfix]
    [HarmonyPatch(typeof(SteamValveHazard), "Start")]
    static void SteamValveHazard_Start_Postfix(SteamValveHazard __instance)
    {
        KeepItDownPlugin.Instance.BindAudioSource("SteamValve", __instance.valveAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(SpikeRoofTrap), "Start")]
    static void SpikeRoofTrap_Start_Postfix(SpikeRoofTrap __instance) {
        KeepItDownPlugin.Instance.BindAudioSource("SpikeTrap", __instance.spikeTrapAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(Turret), "Start")]
    static void Turret_Start_Postfix(Turret __instance) {
        KeepItDownPlugin.Instance.BindAudioSources("Turret", __instance.mainAudio, __instance.berserkAudio, __instance.farAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(VehicleController), "Start")]
    static void VehicleController_Start_Postfix(VehicleController __instance) {
        KeepItDownPlugin.Instance.BindAudioSource("CruiserHorn", __instance.hornAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(VehicleController), "SetRadioValues")]
    static void VehicleControllerRadio_Start_Postfix(VehicleController __instance) {
        KeepItDownPlugin.Instance.BindAudioSources("CruiserRadio", __instance.radioAudio, __instance.radioInterference);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(VehicleController), "SetCarEffects")]
    static void VehicleControllerEngine_Start_Postfix(VehicleController __instance) {
        KeepItDownPlugin.Instance.BindAudioSources("CruiserSkid", __instance.tireAudio, __instance.skiddingAudio);
        KeepItDownPlugin.Instance.BindAudioSources(
            "CruiserEngine",
            __instance.vehicleEngineAudio,
            __instance.engineAudio1,
            __instance.engineAudio2
        );
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(JesterAI), nameof(JesterAI.Start))]
    static void JesterAI_Start_Postfix(JesterAI __instance) {
        KeepItDownPlugin.Instance.BindAudioSource("Jester", __instance.farAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(SandSpiderAI), nameof(SandSpiderAI.Start))]
    static void JesterAI_Start_Postfix(SandSpiderAI __instance) {
        KeepItDownPlugin.Instance.BindAudioSource("Spider", __instance.footstepAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(CentipedeAI), nameof(CentipedeAI.Start))]
    static void JesterAI_Start_Postfix(CentipedeAI __instance) {
        KeepItDownPlugin.Instance.BindAudioSource("SnareFleaFaceHug", __instance.clingingToPlayer2DAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(RadMechAI), nameof(RadMechAI.Start))]
    static void JesterAI_Start_Postfix(RadMechAI __instance) {
        KeepItDownPlugin.Instance.BindAudioSources(
            "OldBird",
            __instance.blowtorchAudio,
            __instance.explosionAudio,
            __instance.LocalLRADAudio,
            __instance.LocalLRADAudio2,
            __instance.chargeForwardAudio,
            __instance.flyingDistantAudio,
            __instance.spotlightOnAudio
        );
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(ButlerEnemyAI), "Start")]
    static void JesterAI_Start_Postfix(ButlerEnemyAI __instance) {
        KeepItDownPlugin.Instance.BindAudioSource("ButlerMurderMusic", ButlerEnemyAI.murderMusicAudio);
    }
    
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(FlowerSnakeEnemy), nameof(FlowerSnakeEnemy.Start))]
    static void JesterAI_Start_Postfix(FlowerSnakeEnemy __instance) {
        KeepItDownPlugin.Instance.BindAudioSource("TulipSnakeFlapping", __instance.flappingAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(CaveDwellerAI), nameof(CaveDwellerAI.Start))]
    static void JesterAI_Start_Postfix(CaveDwellerAI __instance) {
        KeepItDownPlugin.Instance.BindAudioSource("ManeaterCry", __instance.babyCryingAudio);
        KeepItDownPlugin.Instance.BindAudioSource("ManeaterScream", __instance.screamAudio);
        KeepItDownPlugin.Instance.BindAudioSource("ManeaterScreamMusic", __instance.screamAudioNonDiagetic);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(TVScript), "OnEnable")]
    static void TVScript_OnEnable_Postfix(TVScript __instance) {
        KeepItDownPlugin.Instance.BindAudioSource("TV", __instance.tvSFX);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(TVScript), "OnDisable")]
    static void TVScript_OnDisable_Postfix(TVScript __instance) {
        KeepItDownPlugin.Instance.RemoveBindings("TV", __instance.tvSFX.gameObject);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(StartOfRound), "OnEnable")]
    static void StartOfRound_OnEnable_Postfix(StartOfRound __instance) {
        KeepItDownPlugin.Instance.BindAudioSource("ShipDoor", __instance.shipDoorAudioSource);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(StartOfRound), "OnDisable")]
    static void StartOfRound_OnDisable_Postfix(StartOfRound __instance) {
        KeepItDownPlugin.Instance.RemoveBindings("ShipDoor", __instance.gameObject);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(StormyWeather), "OnEnable")]
    static void StormyWeather_OnEnable_Postfix(StormyWeather __instance) {
        KeepItDownPlugin.Instance.BindAudioSources(
            "Thunder",
            __instance.randomStrikeAudio,
            __instance.randomStrikeAudioB,
            __instance.targetedStrikeAudio
        );  
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(StormyWeather), "OnDisable")]
    static void StormyWeather_OnDisable_Postfix(StormyWeather __instance) {
        KeepItDownPlugin.Instance.RemoveBindings("Thunder", __instance.gameObject);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(GrabbableObject), nameof(GrabbableObject.Start))]
    static void GrabbableObject_Start_Postfix(GrabbableObject __instance) {
        switch (__instance) {
            case RemoteProp remoteProp:
                KeepItDownPlugin.Instance.BindAudioSource("Remote", remoteProp.remoteAudio);
                break;
            case JetpackItem jetpackItem:
                KeepItDownPlugin.Instance.BindAudioSource("Jetpack", jetpackItem.jetpackAudio);
                break;
            case Shovel shovel:
                KeepItDownPlugin.Instance.BindAudioSource("Shovel", shovel.shovelAudio);
                break;
            case ShotgunItem shotgunItem:
                KeepItDownPlugin.Instance.BindAudioSources("Shotgun", shotgunItem.gunShootAudio, shotgunItem.gunBulletsRicochetAudio);
                break;
            case KnifeItem knifeItem:
                KeepItDownPlugin.Instance.BindAudioSource("Knife", knifeItem.knifeAudio);
                break;
            case ClockProp clockProp:
                KeepItDownPlugin.Instance.BindAudioSource("Clock", clockProp.tickAudio);
                break;
            case SoccerBallProp soccerBallProp:
                KeepItDownPlugin.Instance.BindAudioSource("SoccerBall", soccerBallProp.soccerBallAudio);
                break;
            case WhoopieCushionItem whoopieCushionItem:
                KeepItDownPlugin.Instance.BindAudioSource("WhoopieCushion", whoopieCushionItem.whoopieCushionAudio);
                break;
            case ExtensionLadderItem extensionLadderItem:
                KeepItDownPlugin.Instance.BindAudioSource("ExtensionLadder", extensionLadderItem.ladderAudio);
                break;
            case StunGrenadeItem stunGrenadeItem:
                var name = stunGrenadeItem.name.Contains("Egg") ? "EasterEgg" : "StunGrenade";
                KeepItDownPlugin.Instance.BindAudioSource(name, stunGrenadeItem.itemAudio);
                break;
        }
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(NetworkBehaviour), nameof(NetworkBehaviour.OnNetworkSpawn))]
    static void NetworkBehaviour_OnNetworkSpawn_Postfix(NetworkBehaviour __instance) {
        switch (__instance) {
            case ItemCharger itemCharger:
                KeepItDownPlugin.Instance.BindAudioSource("ItemCharger", itemCharger.zapAudio);
                break;
        }
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(HUDManager), "OnEnable")]
    static void HUDManager_OnEnable_Postfix(HUDManager __instance) {
        KeepItDownPlugin.Instance.BindAudioSource("Scan", __instance.UIAudio);
    }
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(HUDManager), "OnDisable")]
    static void HUDManager_OnDisable_Postfix(HUDManager __instance) {
        KeepItDownPlugin.Instance.RemoveBindings("Scan", __instance.UIAudio.gameObject);
    }
}
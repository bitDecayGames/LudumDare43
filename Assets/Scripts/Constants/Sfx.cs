using System;
using UnityEngine;

public class Sfx : MonoBehaviour
{
    public static string BuildSlideSfxStringFromMaterialType(String material)
    {
        return String.Format("Slide/{0}", char.ToUpper(material[0]) + material.Substring(1));
    }
    
    public static string AmbientFogHorn = "Ambient/FogHorn";
    public static string AmbientShipBell = "Ambient/ShipBell";
    public static string AmbientChainMove = "Ambient/ChainMove";
    public static string AmbientChainMove2 = "Ambient/ChainMove2";
    public static string AmbientBirdFlap = "Ambient/BirdFlap";
    public static string AmbientBirdFlapLong = "Ambient/BirdFlapLong";
    public static string AmbientSplash = "Ambient/Splash";
    public static string AmbientRotatePieceClockwise = "Ambient/RotatePieceClockwise";
    public static string AmbientRotatePieceCounterClockwise = "Ambient/RotatePieceCounterClockwise";
    public static string AmbientCratePoinsoned = "Ambient/CratePoisoned";
    public static string AmbientItemFallingOffShip = "Ambient/ItemFallingOffShip";
    public static string ImpactMetal = "Impact/Metal";
    public static string ImpactMetal2 = "Impact/Metal2";
    public static string ImpactMetalBarrel = "Impact/MetalBarrel";
    public static string ImpactMetalBarrel2 = "Impact/MetalBarrel2";
    public static string ImpactWood = "Impact/Wood";
    public static string ImpactWood2 = "Impact/Wood2";
    public static string MenuMove = "Menu/MenuMove";
    public static string MenuSelect = "Menu/Select";
    public static string MenuSelect2 = "Menu/Select2";
    public static string StepWood = "Step/Wood";
    public static string VoiceGrunt = "Voice/Grunt";
    public static string VoiceRatSqueak = "Voice/RatSqueak";
    public static string SlideStone = "Slide/Stone";
    public static string SlideWood = "Slide/Wood";
    public static string ScoreScreenStarOne = "ScoreScreen/StarOne";
    public static string ScoreScreenStarTwo = "ScoreScreen/StarTwo";
    public static string ScoreScreenStarThree = "ScoreScreen/StarThree";
    public static string ScoreScreenStarStarsAndBonus = "ScoreScreen/StarsAndBonus";
    public static string ScoreScreenBonusStamp = "ScoreScreen/BonusStamp";
}
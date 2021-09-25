using Verse;
using RimWorld;
using System.Collections.Generic;
using RimWorld.Planet;

namespace ESCP_RaceTools
{
    public class SettlementPreference : DefModExtension
    {
        //determines the chance a settlement actually follows the defined rules
        public float chance = 1f;
        //if not null, faction bases can only spawn on biomes with on of these keywords in their defName. Case sensitive
        //Probably don't mix this with dis/likedBiomeList
        public List<string> biomeKeyWords;
        //range for temperature, only settle on tile if temperature is within range
        public bool useTemperatureRange = false;
        public float temperatureRangeMin;
        public float temperatureRangeMax;
        //range for elevation, only settle on tile if elevation is within range
        public bool useElevationRange = false;
        public float elevationRangeMin;
        public float elevationRangeMax;
        //range for swampiness, only settle on tile if swampiness is within range
        public bool useSwampinessRange = false;
        public float swampinessRangeMin;
        public float swampinessRangeMax;
        //range for Rainfall, only settle on tile if rainfall is within range
        public bool useRainfallRange = false;
        public float rainfallRangeMin;
        public float rainfallRangeMax;
        //list of strings corresponding to biome defNames, only settle if tile biome is listed
        //make sure to use MayRequire, or patch in, biomes that are added by other mods
        public List<string> likedBiomeList;
        //list of strings corresponding to biome defNames, only settle if tile biome is not listed
        //dislikedBiomeList doesn't need MayRequire or a patch for biomes from other mods
        public List<string> dislikedBiomeList;
        //list of strings corresponding to hilliness levels, only settle if tile biome has a listed hilliness
        public List<Hilliness> requiredHillLevels;
        public List<Hilliness> disallowedHillLevels;
        //catch all for ocean, lake and river. Used in cases where the faction just wants water, but doesn't care what type
        public bool requiresWater = false;
        //only settle if tile is coastal, lakeside, has rivers or has roads
        public bool onlyCoastal = false;
        public bool onlyLakeside = false;
        public bool onlyRiver = false;
        public bool onlyRoad = false;

        /*potential additons
         * diseaseChance
         */

        public bool IgnoreBiomeSelectionWeight = true;

        public static SettlementPreference Get(Def def)
        {
            return def.GetModExtension<SettlementPreference>();
        }
    }
}

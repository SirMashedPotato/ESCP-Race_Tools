using HarmonyLib;
using RimWorld;
using Verse;
using RimWorld.Planet;
using System;

namespace ESCP_RaceTools
{
    /// <summary>
    /// Patch that uses the SettlementPreference defModExtension to control faction base spawns
    /// It was a little while ago, but I believe this was originally based on code created by Jecrell
    /// Most functionality is in SettlementPreferenceUtility
    /// </summary>
    [HarmonyPatch(typeof(TileFinder))]
    [HarmonyPatch("RandomSettlementTileFor")]
    [HarmonyPatch([typeof(PlanetLayer), typeof(Faction), typeof(bool), typeof(Predicate<PlanetTile>)])]

    public static class TileFinder_RandomSettlementTileFor_Patch
    {
        public static bool Prefix(PlanetLayer layer, Faction faction, ref PlanetTile __result)
        {
            if (ESCP_RaceTools_ModSettings.EnableSettlementPreference)
            {
                if (faction != null && SettlementPreference.Get(faction.def) != null && Rand.Chance(SettlementPreference.Get(faction.def).chance))
                {
                    //if true is returned, passes control onto default TileFinder.RandomSettlementTileFor
                    return SettlementPreferenceUtility.GetTileID(layer, faction, out __result);
                }
            }
            return true;
        }
    }
}

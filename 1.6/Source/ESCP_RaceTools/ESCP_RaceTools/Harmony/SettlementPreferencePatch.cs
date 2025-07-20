using HarmonyLib;
using RimWorld;
using Verse;
using RimWorld.Planet;

namespace ESCP_RaceTools
{
    //public static class SettlementPreferencePatch
    //{
    //    /// <summary>
    //    /// Patch that uses the SettlementPreference defModExtension to control faction base spawns
    //    /// It was a little while ago, but I believe this was originally based on code created by Jecrell
    //    /// Most functionality is in SettlementPreferenceUtility
    //    /// </summary>
    //    [HarmonyPatch(typeof(TileFinder))]
    //    [HarmonyPatch("RandomSettlementTileFor")]
    //    public static class TileFinder_RandomSettlementTileFor_Patch
    //    {
    //        [HarmonyPrefix]
    //        public static bool SettlementPatch(ref int __result, Faction faction)
    //        {
    //            if (ESCP_RaceTools_ModSettings.EnableSettlementPreference)
    //            {
    //                if (faction != null && SettlementPreference.Get(faction.def) != null && Rand.Chance(SettlementPreference.Get(faction.def).chance))
    //                {
    //                    //if true is returned, passes control onto default TileFinder.RandomSettlementTileFor
    //                    return SettlementPreferenceUtility.GetTileID(faction, out __result);
    //                }
    //            }
    //            return true;
    //        }
    //    }
    //}
}

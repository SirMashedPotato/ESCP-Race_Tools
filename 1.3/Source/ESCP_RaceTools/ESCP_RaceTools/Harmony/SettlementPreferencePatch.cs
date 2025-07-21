using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;
using Verse.AI;
using Verse.AI.Group;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Linq;
using RimWorld.Planet;

namespace ESCP_RaceTools
{
    public static class SettlementPreferencePatch
    {
        /* 
         * Patch that uses the SettlementPreference defModExtension to control faction base spawns
         * It was a little while ago, but I believe this was originally based on code created by Jecrell
         */
        [HarmonyPatch(typeof(TileFinder))]
        [HarmonyPatch("RandomSettlementTileFor")]
        public static class TileFinder_RandomSettlementTileFor_Patch
        {
            [HarmonyPrefix]
            public static bool SettlementPatch(ref int __result, Faction faction)
            {
                if (ModSettingsUtility.ESCP_EnableSettlementPreference())
                {
                    if (faction != null && SettlementPreference.Get(faction.def) != null && Rand.Chance(SettlementPreference.Get(faction.def).chance))
                    {
                        //if true is returned, passes control onto default TileFinder.RandomSettlementTileFor
                        return SettlementPreferenceUtility.GetTileID(faction, out __result);
                    }
                }
                return true;
            }
        }
    }
}

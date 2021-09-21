using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Linq;
using RimWorld.Planet;


namespace ESCP_RaceTools
{
    //Setting the Harmony instance
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.ESCP_RaceTools");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    /* 
     * Patch that checks for thing made of orichalcum and made by Orsimer
     * If thing is found, increase quality level by 1
     */
    [HarmonyPatch(typeof(GenRecipe))]
    [HarmonyPatch("PostProcessProduct")]
    public static class GenRecipe_PostProcessProduct_Patch
    {
        [HarmonyTranspiler]
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            if (ModSettingsUtility.ESCP_RaceTools_EnableStuffKnowledge())
            {
                var codes = new List<CodeInstruction>(instructions);
                //used for checking for the right function call
                var generateQuality = AccessTools.Method(typeof(QualityUtility), nameof(QualityUtility.GenerateQualityCreatedByPawn), new Type[] { typeof(Pawn), typeof(SkillDef) });
                //function that is called to check quality
                var stuffCheck = AccessTools.Method(typeof(StuffKnowledgeUtility), nameof(StuffKnowledgeUtility.CheckQualityIncrease));
                //find the right position in the stack
                for (int i = 0; i < codes.Count; i++)
                {
                    if (codes[i].opcode == OpCodes.Call && codes[i].operand == generateQuality)
                    {
                        yield return codes[i];
                        yield return new CodeInstruction(OpCodes.Stloc_2); // stores original quality
                        yield return new CodeInstruction(OpCodes.Ldarg_2); // pawn
                        yield return new CodeInstruction(OpCodes.Ldloc_2); // loads original quality
                        yield return new CodeInstruction(OpCodes.Ldarg_0); // thing
                        yield return new CodeInstruction(OpCodes.Ldarg_1); // recipe def
                        codes[i] = new CodeInstruction(OpCodes.Call, stuffCheck); // modify
                        yield return codes[i]; // and return modifed
                        if (ModSettingsUtility.ESCP_StuffKnowledgeLogging()) Log.Message("ESCP_RaceTools_ModName".Translate() + ", has succesfully patched GenRecipe.PostProcessProduct");
                    }
                    else
                    {
                        yield return codes[i];
                    }
                }
            }
        }
    }

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
            if (ModSettingsUtility.ESCP_SettlementPreference())
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

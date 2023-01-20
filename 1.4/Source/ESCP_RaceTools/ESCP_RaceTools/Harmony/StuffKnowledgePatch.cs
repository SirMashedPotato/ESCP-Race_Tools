using HarmonyLib;
using RimWorld;
using Verse;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ESCP_RaceTools
{
    public static class StuffKnowledgePatch
    {
        /// <summary>
        /// Patch that checks for stuff knowledge
        /// If checks are passed, increase quality level by 1
        /// Has to be a transpiler as it requires information on the stuff of the thing
        /// </summary>
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
    }
}

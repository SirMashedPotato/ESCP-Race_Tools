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

namespace ESCP_RaceTools
{
    public class UniqueDeityNamePatch
    {

        /* Forces deity names for specific Ideo orgins to be picked sequentially, instead of randomly 
         * This patch only affects Ideo orgins with fixed deities
         */
        [HarmonyPatch(typeof(IdeoFoundation_Deity))]
        [HarmonyPatch("FillDeity")]
        public static class IdeoFoundation_Deity_FillDeity_PrePatch
        {
            [HarmonyPrefix]
            public static bool UniqueDeityNameOverridePatch(IdeoFoundation_Deity.Deity deity, ref IdeoFoundation_Deity __instance)
            {
                if (ModSettingsUtility_Ideo.ESCP_RaceTools_DeityNameFix())
                {
                    var props = IdeoOrginProperties.Get(__instance.ideo.StructureMeme);
                    if (props != null && props.IgnoreDuplicateDeityNames && __instance.ideo.StructureMeme.fixedDeityNameTypes != null)
                    {
                        /* copied from original function, related meme stuff removed */
                        Gender supremeGender = __instance.ideo.SupremeGender;
                        if (supremeGender != Gender.None)
                        {
                            deity.gender = supremeGender;
                        }
                        else
                        {
                            deity.gender = Gen.RandomEnumValue<Gender>(true);
                        }
                        /* new stuff */
                        MemeDef originMeme = __instance.ideo.StructureMeme;
                        if (props.RandomiseDeityName)
                        {
                            deity.name = originMeme.fixedDeityNameTypes.RandomElement().name;
                            deity.type = originMeme.fixedDeityNameTypes.RandomElement().type;
                            deity.iconPath = "UI/Deities/DeityGeneric";
                            return false;
                        } 
                        else
                        {
                            if (originMeme.fixedDeityNameTypes.Count() < originMeme.deityCount.max)
                            {
                                Log.Warning("Diety name count mismatch, reverting to vanilla code: " + originMeme.defName);
                                return true;
                            }
                            for (int i = 0; i < originMeme.fixedDeityNameTypes.Count(); i++)
                            {
                                if (!__instance.DeitiesListForReading.Where(x => x.name == originMeme.fixedDeityNameTypes[i].name).Any())
                                {
                                    deity.name = originMeme.fixedDeityNameTypes[i].name;
                                    deity.type = originMeme.fixedDeityNameTypes[i].type;
                                    deity.iconPath = "UI/Deities/DeityGeneric";

                                    if (props.RandomiseDeityType)
                                    {
                                        deity.type = originMeme.fixedDeityNameTypes.RandomElement().type;
                                    }

                                    return false;
                                }
                            }
                        }
                        Log.Warning("Unique deity name not found, reverting to vanilla code: " + originMeme.defName);
                    }
                }
                return true;
            }
        }

        /* Forces deity names for specific Ideo orgins to be picked sequentially, instead of randomly 
         * This patch only affects Ideo orgins with randomised deity names
         */

    }
}

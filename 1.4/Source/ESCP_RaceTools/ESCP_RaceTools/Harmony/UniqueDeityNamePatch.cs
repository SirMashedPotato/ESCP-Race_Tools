using HarmonyLib;
using RimWorld;
using Verse;
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
                if (ESCP_RaceTools_ModSettings.IdeologyDivinesNames)
                {
                    //Override Divines names

                    if (__instance.ideo.StructureMeme != null)
                    {
                        var cultureProps = IdeoCultureProperties.Get(__instance.ideo.culture);
                        if (cultureProps != null 
                            && ((cultureProps.overrideDivines && __instance.ideo.StructureMeme.defName == "ESCP_Structure_OriginDivinesEight") 
                            || (cultureProps.overrideNineDivines && __instance.ideo.StructureMeme.defName == "ESCP_Structure_OriginDivinesNine")))
                        {
                            for (int i = 0; i < 8; i++)
                            {
                                if (!__instance.DeitiesListForReading.Where(x => x.name == cultureProps.divinesList[i].name).Any())
                                {
                                    deity.name = cultureProps.divinesList[i].name;
                                    deity.type = cultureProps.divinesList[i].type;
                                    deity.iconPath = cultureProps.divinesList[i].iconPath;

                                    /* copied from original function, related meme stuff removed */
                                    Gender supremeGender = __instance.ideo.SupremeGender;
                                    if (supremeGender != Gender.None)
                                    {
                                        deity.gender = supremeGender;
                                    }
                                    else
                                    {
                                        if (cultureProps.divinesList[i].gender.HasValue)
                                        {
                                            deity.gender = cultureProps.divinesList[i].gender.Value;
                                        }
                                        else
                                        {
                                            deity.gender = Gen.RandomEnumValue<Gender>(true);
                                        }
                                    }
                                    return false;
                                }
                            }
                        }
                    }
                }

                if (ESCP_RaceTools_ModSettings.DeityNameFix)
                {
                    /* This should possibly be redone */

                    var props = IdeoOrginProperties.Get(__instance.ideo.StructureMeme);

                    if (props != null && props.IgnoreDuplicateDeityNames && __instance.ideo.StructureMeme.fixedDeityNameTypes != null)
                    {
                        /* copied from original function, related meme stuff removed */
                        Gender supremeGender = __instance.ideo.SupremeGender;
                        bool supremeGenderFlag = false;
                        if (supremeGender != Gender.None)
                        {
                            deity.gender = supremeGender;
                            supremeGenderFlag = true;
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
                            if (props.overrideDeityIcons)
                            {
                                deity.iconPath = props.iconPath.RandomElementWithFallback(props.iconPath.First());
                            }
                            else
                            {
                                deity.iconPath = "UI/Deities/DeityGeneric";
                            }
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
                                    

                                    if (props.overrideDeityGenders && !supremeGenderFlag && props.deityGenders.Count >= i+1)
                                    {
                                        deity.gender = props.deityGenders[i];
                                    }

                                    if (props.overrideDeityIcons && props.iconPath.Count >= i + 1)
                                    {
                                        deity.iconPath = props.iconPath[i];
                                    } 
                                    else
                                    {
                                        deity.iconPath = "UI/Deities/DeityGeneric";
                                    }

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
    }
}

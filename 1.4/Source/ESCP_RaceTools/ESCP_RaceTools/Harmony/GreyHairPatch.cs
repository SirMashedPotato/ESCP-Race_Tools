using HarmonyLib;
using RimWorld;
using Verse;

namespace ESCP_RaceTools
{
    /// <summary>
    /// 
    /// </summary>
    [HarmonyPatch(typeof(PawnHairColors))]
    [HarmonyPatch("HasGreyHair")]
    public static class PawnHairColors_HasGreyHair_Patch
    {
        [HarmonyPostfix]
        public static void HasGreyHair_Fix(Pawn pawn, int ageYears, ref bool __result)
        {
            if (__result)
            {
                GreyHairPatchProps props = GreyHairPatchProps.Get(pawn.def);
                if (props != null && props.minAgeForGreyHair > -1)
                {
                    float num = GenMath.SmootherStep(props.minAgeForGreyHair, pawn.def.race.lifeExpectancy, ageYears);
                    __result = Rand.Value < num;
                }
            }
        }
    }
}

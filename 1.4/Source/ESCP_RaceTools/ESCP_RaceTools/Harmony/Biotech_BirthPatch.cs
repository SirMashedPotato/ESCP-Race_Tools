using HarmonyLib;
using RimWorld;
using Verse;

namespace ESCP_RaceTools
{
    /// <summary>
    /// Adds inherited bonus genes based on the fathers race
    /// </summary>
    [HarmonyPatch(typeof(PregnancyUtility))]
    [HarmonyPatch("ApplyBirthOutcome")]
    public static class PregnancyUtility_ApplyBirthOutcome_Patch
    {
        [HarmonyPostfix]
        public static void ApplyBirthOutcome_Patch(ref Thing __result, Pawn father = null)
        {
            if (father != null)
            {
                if (__result != null && __result is Pawn child && !child.Dead)
                {
                    if (father.def != child.def)
                    {
                        RaceProperties props = RaceProperties.Get(father.def);
                        if (props != null && props.hybridInheritedGene != null)
                        {
                            child.genes.AddGene(props.hybridInheritedGene, false);
                        }
                    }
                }
            }
        }
    }
}

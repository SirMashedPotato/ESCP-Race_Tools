using HarmonyLib;
using RimWorld;
using Verse;
using System;

namespace ESCP_RaceTools
{
    /// <summary>
    /// Modifies the expectation level for certain races
    /// </summary>
    [HarmonyPatch(typeof(ExpectationsUtility))]
    [HarmonyPatch("CurrentExpectationFor")]
    [HarmonyPatch([typeof(Pawn)])]
    public static class ExpectationsUtility_CurrentExpectationFor_Patch
    {
        public static void Postfix(Pawn p, ref ExpectationDef __result)
        {
            if (ESCP_RaceTools_ModSettings.EnableDecreasedExpecations || ESCP_RaceTools_ModSettings.EnableIncreasedExpecations)
            {
                var props = RaceProperties.Get(p.def);
                if (props != null)
                {
                    if (props.modifiedExpectations && ((props.expectationOffset < 0 && ESCP_RaceTools_ModSettings.EnableDecreasedExpecations) || (props.expectationOffset > 0 && ESCP_RaceTools_ModSettings.EnableIncreasedExpecations)))
                    {
                        ExpectationDef expectationDef2;
                        if (props.expectationOffset < 0)
                        {
                            expectationDef2 = ExpectationsUtility.ExpectationForOrder(Math.Min(__result.order + props.expectationOffset, 0), true);

                        }
                        else
                        {
                            expectationDef2 = ExpectationsUtility.ExpectationForOrder(Math.Max(__result.order + props.expectationOffset, 0), true);

                        }
                        if (expectationDef2 != null)
                        {
                            __result = expectationDef2;
                        }
                    }
                }
            }
        }
    }
}

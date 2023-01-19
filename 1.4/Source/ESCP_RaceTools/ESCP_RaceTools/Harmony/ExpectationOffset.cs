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
    public static class ExpectationOffset
    {
        /*
         * Patch that removes specific thoughts when wearing certain apparel
         * Mostly intended for weather thoughts
         */
        [HarmonyPatch(typeof(ExpectationsUtility))]
        [HarmonyPatch("CurrentExpectationFor")]
        [HarmonyPatch(new Type[] { typeof(Pawn) })]
        public static class ExpectationsUtility_CurrentExpectationFor_Patch
        {
            [HarmonyPostfix]
            public static void ExpectationsPatch(Pawn p, ref ExpectationDef __result)
            {
                if (ModSettingsUtility.ESCP_RaceTools_EnableDecreasedExpecations() || ModSettingsUtility.ESCP_RaceTools_EnableIncreasedExpecations())
                {
                    var props = RaceProperties.Get(p.def);
                    if (props != null)
                    {
                        if (props.modifiedExpectations && ((props.expectationOffset < 0 && ModSettingsUtility.ESCP_RaceTools_EnableDecreasedExpecations()) || (props.expectationOffset > 0 && ModSettingsUtility.ESCP_RaceTools_EnableIncreasedExpecations())))
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
}

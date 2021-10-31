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
    public static class ApparelThoughtProtectionPatch
    {
        /*
         * Patch that removes specific thoughts when wearing certain apparel
         * Mostly intended for weather thoughts
         */
        [HarmonyPatch(typeof(MemoryThoughtHandler))]
        [HarmonyPatch("TryGainMemoryFast")]
        public static class MemoryThoughtHandler_TryGainMemoryFast_Patch
        {
            [HarmonyPrefix]
            public static bool ThoughtsPatch(ThoughtDef mem, ref Pawn ___pawn)
            {
                if (ModSettingsUtility.ESCP_RaceTools_EnableApparelThoughtProtection())
                {
                    foreach (Apparel apparel in ___pawn.apparel.WornApparel.ToList())
                    {
                        var props = ApparelProperties.Get(apparel.def);
                        if (props != null && props.negatedThoughts != null)
                        {
                            if (props.linkedApparel != null && props.negatedThoughts.Contains(mem.defName.ToString()))
                            {
                                int count = 0;
                                int i = props.requiredItems == -1 ? props.linkedApparel.Count() : props.requiredItems;
                                foreach (Apparel linked in ___pawn.apparel.WornApparel.ToList())
                                {
                                    if (props.linkedApparel.Contains(linked.def))
                                    {
                                        count++;
                                    }
                                }
                                if (count >= i)
                                {
                                    return false;
                                }
                            }
                            if (props.linkedApparel == null)
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }

        }

            /*
            [HarmonyPatch(typeof(Pawn_MindState))]
            [HarmonyPatch("MindStateTick")]
            old version, similar to tents mod.
            Thought gets added, then removed shortly after.
            Only affects weather thoughts

            public static class Pawn_MindState_MindStateTick_Patch
            {
                [HarmonyPostfix]
                public static void WeatherThoughtsPatch(Pawn_MindState __instance)
                {
                    if (Find.TickManager.TicksGame % 123  == 0 && ModSettingsUtility.ESCP_RaceTools_EnableApparelThoughtProtection() 
                        && __instance.pawn.Spawned && __instance.pawn.needs.mood != null && __instance.pawn.RaceProps.Humanlike)
                    {
                        Pawn pawn = __instance.pawn;
                        foreach(Apparel apparel in pawn.apparel.WornApparel.ToList())
                        {
                            var props = ApparelProperties.Get(apparel.def);
                            if (props != null && props.negatedThoughts != null)
                            {
                                if (props.linkedApparel != null)
                                {
                                    int count = 0;
                                    int i = props.requiredItems == -1 ? props.linkedApparel.Count() : props.requiredItems;
                                    foreach (Apparel linked in pawn.apparel.WornApparel.ToList())
                                    {
                                        if (props.linkedApparel.Contains(linked.def))
                                        {
                                            count++;
                                        }
                                    }
                                    if (count >= i)
                                    {
                                        if (CheckWeatherThoughts(props.negatedThoughts, __instance))
                                        {
                                            return;
                                        }
                                    }
                                }
                                if (props.linkedApparel == null)
                                {
                                    if (CheckWeatherThoughts(props.negatedThoughts, __instance))
                                    {
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }

                private static bool CheckWeatherThoughts(List<string> thoughts, Pawn_MindState instance)
                {
                    foreach(string def in thoughts)
                    {
                        if (instance.pawn.Map.weatherManager.CurWeatherLerped.exposedThought.defName == def)
                        {
                            instance.pawn.needs.mood.thoughts.memories.RemoveMemoriesOfDef(ThoughtDef.Named(def));
                        }
                    }
                    return false;
                }
            }
            */
        }
}

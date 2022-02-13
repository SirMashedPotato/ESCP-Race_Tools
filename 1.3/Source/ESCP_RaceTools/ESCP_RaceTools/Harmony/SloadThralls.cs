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
    public static class SloadThralls
    {

        [HarmonyPatch(typeof(Pawn_IdeoTracker))]
        class Pawn_IdeoTracker_CertaintyChangePerDay_Patch
        {
            [HarmonyPrefix]
            [HarmonyPatch("CertaintyChangePerDay", MethodType.Getter)]
            public static bool CertaintyChangePerDay_SloadThrallFix(ref Pawn ___pawn, ref float __result)
            {
                if (___pawn.health.hediffSet.hediffs.Where(x => x.def.ToString() == "ESCP_SloadThrallPassive").Any())
                {
                    __result = 1f;
                    return false;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(MeditationUtility))]
        [HarmonyPatch("CanMeditateNow")]
        public static class MeditationUtility_CanMeditateNow_Patch
        {
            [HarmonyPrefix]
            public static bool ThrallmeditationPatch(Pawn pawn, ref bool __result)
            {
                if (pawn.health.hediffSet.hediffs.Where(x => x.def.ToString() == "ESCP_SloadThrallPassive").Any())
                {
                    if (pawn.health.hediffSet.BleedRateTotal <= 0f)
                    {
                        if (HealthAIUtility.ShouldSeekMedicalRest(pawn))
                        {
                            Pawn_TimetableTracker timetable = pawn.timetable;
                            if (((timetable != null) ? timetable.CurrentAssignment : null) != TimeAssignmentDefOf.Meditate)
                            {
                                __result = false;
                            }
                        }
                        if (!HealthAIUtility.ShouldSeekMedicalRestUrgent(pawn))
                        {
                            __result =  true;
                        }
                    }
                    return false;
                }
                return true;
            }
        }

    }
}

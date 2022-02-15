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
using UnityEngine;

namespace ESCP_RaceTools
{
    //Make thrall names purple, becuase why not?
    [HarmonyPatch(typeof(PawnNameColorUtility))]
    [HarmonyPatch("PawnNameColorOf")]
    public static class PawnNameColorUtility_PawnNameColorOf_Patch
    {
        [HarmonyPrefix]
        public static bool PawnNameColorOf_SloadThrallFix(ref Pawn pawn, ref Color __result)
        {
            if (SloadUtility.PawnIsThrall(pawn) && ModSettingsUtility_SloadThralls.ESCP_RaceTools_SloadThrallNamesArePurple())
            {
                __result = new Color(0.8f, 0.6f, 1.0f);
                return false;
            }
            return true;
        }
    }

    /*
     * Basically just a ton of patches to ensure RimWorld doesn't throw a shit fit when checking for thrall needs 
     */

    /* Needs */

    public static class SloadThralls
    {
        [HarmonyPatch(typeof(Need))]
        class Need_CurLevel_Patch
        {
            [HarmonyPrefix]
            [HarmonyPatch("CurLevel", MethodType.Getter)]
            public static bool CurLevelInt_SloadThrallFix(ref Need __instance, ref Pawn ___pawn, ref float __result)
            {
                if (SloadUtility.PawnIsThrall(___pawn) && ModSettingsUtility_SloadThralls.ESCP_RaceTools_SloadThrallDisableNeeds())
                {
                    __result = __instance.MaxLevel;
                    return false;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(Need))]
        class Need_CurLevelPercentage_Patch
        {
            [HarmonyPrefix]
            [HarmonyPatch("CurLevelPercentage", MethodType.Getter)]
            public static bool CurLevelPercentage_SloadThrallFix(ref Pawn ___pawn,  ref float __result)
            {
                if (SloadUtility.PawnIsThrall(___pawn) && ModSettingsUtility_SloadThralls.ESCP_RaceTools_SloadThrallDisableNeeds())
                {
                    __result = 1f;
                    return false;
                }
                return true;
            }
        }

        /* Doesn't really seem to do anything
        [HarmonyPatch(typeof(Need))]
        class Need_IsFrozen_Patch
        {
            [HarmonyPrefix]
            [HarmonyPatch("IsFrozen", MethodType.Getter)]
            public static bool IsFrozent_SloadThrallFix(ref Pawn ___pawn, ref bool __result)
            {
                if (SloadUtility.PawnIsThrall(___pawn))
                {
                    __result = true;
                    return false;
                }
                return true;
            }
        }
        */

        /* Breaks UI
        [HarmonyPatch(typeof(Need))]
        class Need_ShowOnNeedList_Patch
        {
            [HarmonyPrefix]
            [HarmonyPatch("ShowOnNeedList", MethodType.Getter)]
            public static bool ShowOnNeedList_SloadThrallFix(ref Pawn ___pawn, ref bool __result)
            {
                if (SloadUtility.PawnIsThrall(___pawn))
                {
                    __result = false;
                    return false;
                }
                return true;
            }
        }
        */

        /* Mood and thought fixes */

        [HarmonyPatch(typeof(ThoughtHandler))]
        [HarmonyPatch("GetAllMoodThoughts")]
        public static class ThoughtHandler_GetAllMoodThoughts_Patch
        {
            [HarmonyPrefix]
            public static bool GetAllMoodThoughts_SloadThrallFix(ref Pawn ___pawn, List<Thought> outThoughts)
            {
                if (SloadUtility.PawnIsThrall(___pawn) && ModSettingsUtility_SloadThralls.ESCP_RaceTools_SloadThrallDisableMoods())
                {
                    outThoughts.Clear();
                    return false;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(ThoughtHandler))]
        [HarmonyPatch("GetSocialThoughts")]
        [HarmonyPatch(new Type[] { typeof(Pawn), typeof(ISocialThought), typeof(List<ISocialThought>) })]
        public static class ThoughtHandler_GetSocialThoughts_Patch
        {
            [HarmonyPrefix]
            public static bool GetSocialThoughts_SloadThrallFix(ref Pawn ___pawn, List<ISocialThought> outThoughts)
            {
                if (SloadUtility.PawnIsThrall(___pawn) && ModSettingsUtility_SloadThralls.ESCP_RaceTools_SloadThrallDisableMoods())
                {
                    outThoughts.Clear();
                    return false;
                }
                return true;
            }
        }

        /* Ideo certainty fix */

        [HarmonyPatch(typeof(Pawn_IdeoTracker))]
        class Pawn_IdeoTracker_CertaintyChangePerDay_Patch
        {
            [HarmonyPrefix]
            [HarmonyPatch("CertaintyChangePerDay", MethodType.Getter)]
            public static bool CertaintyChangePerDay_SloadThrallFix(ref Pawn ___pawn, ref float __result)
            {
                if (SloadUtility.PawnIsThrall(___pawn) && ModSettingsUtility_SloadThralls.ESCP_RaceTools_SloadThrallIdeoCertainty())
                {
                    __result = 1f;
                    return false;
                }
                return true;
            }
        }


        /* Skill fixes */

        //Skill learning
        [HarmonyPatch(typeof(SkillRecord))]
        [HarmonyPatch("Learn")]
        public static class Interval_Learn_Patch
        {
            [HarmonyPrefix]
            public static bool SkillRecord_Learn_SloadThrallFix(ref Pawn ___pawn)
            {
                if (SloadUtility.PawnIsThrall(___pawn) && ModSettingsUtility_SloadThralls.ESCP_RaceTools_SloadThrallSkillLearning())
                {
                    return false;
                }
                return true;
            }
        }

        //Skill decay
        [HarmonyPatch(typeof(SkillRecord))]
        [HarmonyPatch("Interval")]
        public static class Interval_Interval_Patch
        {
            [HarmonyPrefix]
            public static bool SkillRecord_Interval_SloadThrallFix(ref Pawn ___pawn)
            {
                if (SloadUtility.PawnIsThrall(___pawn) && ModSettingsUtility_SloadThralls.ESCP_RaceTools_SloadThrallSkillDecay())
                {
                    return false;
                }
                return true;
            }
        }

        /* Producing resources */

        [HarmonyPatch(typeof(CompMilkable))]
        class CompMilkable_Active_Patch
        {
            [HarmonyPrefix]
            [HarmonyPatch("Active", MethodType.Getter)]
            public static bool CompMilkable_Active_SloadThrallFix(ref CompMilkable __instance, ref bool __result)
            {
                if (SloadUtility.PawnIsThrall(__instance.parent as Pawn) && ModSettingsUtility_SloadThralls.ESCP_RaceTools_SloadThrallMilkable())
                {
                    __result = false;
                    return false;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(CompShearable))]
        class CompShearable_Active_Patch
        {
            [HarmonyPrefix]
            [HarmonyPatch("Active", MethodType.Getter)]
            public static bool CompShearable_Active_SloadThrallFix(ref CompShearable __instance, ref bool __result)
            {
                if (SloadUtility.PawnIsThrall(__instance.parent as Pawn) && ModSettingsUtility_SloadThralls.ESCP_RaceTools_SloadThrallShearable())
                {
                    __result = false;
                    return false;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(CompEggLayer))]
        class CompEggLayer_Active_Patch
        {
            [HarmonyPrefix]
            [HarmonyPatch("Active", MethodType.Getter)]
            public static bool CompEggLayer_Active_SloadThrallFix(ref CompEggLayer __instance, ref bool __result)
            {
                if (SloadUtility.PawnIsThrall(__instance.parent as Pawn) && ModSettingsUtility_SloadThralls.ESCP_RaceTools_SloadThrallEggLaying())
                {
                    __result = false;
                    return false;
                }
                return true;
            }
        }

        /* Animal training */

        [HarmonyPatch(typeof(Pawn_TrainingTracker))]
        [HarmonyPatch("CanBeTrained")]
        public static class Pawn_TrainingTracker_CanBeTrained_Patch
        {
            [HarmonyPrefix]
            public static bool CanBeTrained_SloadThrallFix(ref Pawn ___pawn, ref bool __result)
            {
                if (SloadUtility.PawnIsThrall(___pawn) && ModSettingsUtility_SloadThralls.ESCP_RaceTools_SloadThrallTrainable())
                {
                    __result = false;
                    return false;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(Pawn_TrainingTracker))]
        [HarmonyPatch("TrainingTrackerTickRare")]
        public static class Pawn_TrainingTrackerTickRare_CanBeTrained_Patch
        {
            [HarmonyPrefix]
            public static bool TrainingTrackerTickRare_SloadThrallFix(ref Pawn ___pawn)
            {
                if (SloadUtility.PawnIsThrall(___pawn) && ModSettingsUtility_SloadThralls.ESCP_RaceTools_SloadThrallTrainableDecay())
                {
                    return false;
                }
                return true;
            }
        }

        /* Mating */

        [HarmonyPatch(typeof(JobGiver_Mate))]
        [HarmonyPatch("TryGiveJob")]
        public static class JobGiver_Mate_TryGiveJob_CanBeTrained_Patch
        {
            [HarmonyPrefix]
            public static bool JobGiver_Mate_TryGiveJob_SloadThrallFix(Pawn pawn, ref Job __result)
            {
                if (SloadUtility.PawnIsThrall(pawn) && ModSettingsUtility_SloadThralls.ESCP_RaceTools_SloadThrallMating())
                {
                    __result = null;
                    return false;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(PawnUtility))]
        [HarmonyPatch("FertileMateTarget")]
        public static class PawnUtility_FertileMateTarget_CanBeTrained_Patch
        {
            [HarmonyPrefix]
            public static bool FertileMateTarget_SloadThrallFix(Pawn male, Pawn female, ref bool __result)
            {
                if ((SloadUtility.PawnIsThrall(male) || SloadUtility.PawnIsThrall(female)) && ModSettingsUtility_SloadThralls.ESCP_RaceTools_SloadThrallMating())
                {
                    __result = false;
                    return false;
                }
                return true;
            }
        }

        /* Meditation fix, not necessary anymore */
        /*
        [HarmonyPatch(typeof(MeditationUtility))]
        [HarmonyPatch("CanMeditateNow")]
        public static class MeditationUtility_CanMeditateNow_Patch
        {
            [HarmonyPrefix]
            public static bool ThrallmeditationPatch(Pawn pawn, ref bool __result)
            {
                if (SloadUtility.PawnIsThrall(pawn))
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
        */
    }
}

using HarmonyLib;
using RimWorld;
using Verse;

namespace ESCP_RaceTools
{
    public static class QuadrumNamesPatch
    {
        /// <summary>
        /// Patches that swap out the quadrum names to elder scrollsy ones
        /// Names made by Kriana
        /// </summary>

        [HarmonyPatch(typeof(QuadrumUtility))]
        [HarmonyPatch("Label")]
        public static class QuadrumUtility_Label_Patch
        {
            [HarmonyPrefix]
            public static bool QuadramNamePatch(Quadrum quadrum, ref string __result)
            {
                if (ESCP_RaceTools_ModSettings.ElderScrollsQuadrums)
                {
                    switch (quadrum)
                    {
                        case Quadrum.Aprimay:
                            __result = "ESCP_QuadrumAprimay".Translate();
                            return false;
                        case Quadrum.Jugust:
                            __result = "ESCP_QuadrumJugust".Translate();
                            return false;
                        case Quadrum.Septober:
                            __result = "ESCP_QuadrumSeptober".Translate();
                            return false;
                        case Quadrum.Decembary:
                            __result = "ESCP_QuadrumDecembary".Translate();
                            return false;
                        default:
                            __result = "Unknown quadrum";
                            return false;
                    }
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(QuadrumUtility))]
        [HarmonyPatch("LabelShort")]
        public static class QuadrumUtility_LabelShort_Patch
        {
            [HarmonyPrefix]
            public static bool QuadramNamePatch(Quadrum quadrum, ref string __result)
            {
                if (ESCP_RaceTools_ModSettings.ElderScrollsQuadrums)
                {
                    switch (quadrum)
                    {
                        case Quadrum.Aprimay:
                            __result = "ESCP_QuadrumAprimay_Short".Translate();
                            return false;
                        case Quadrum.Jugust:
                            __result = "ESCP_QuadrumJugust_Short".Translate();
                            return false;
                        case Quadrum.Septober:
                            __result = "ESCP_QuadrumSeptober_Short".Translate();
                            return false;
                        case Quadrum.Decembary:
                            __result = "ESCP_QuadrumDecembary_Short".Translate();
                            return false;
                        default:
                            __result = "Unknown quadrum";
                            return false;
                    }
                }
                return true;
            }

        }
    }
}

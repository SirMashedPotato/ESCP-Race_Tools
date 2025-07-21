using HarmonyLib;
using RimWorld;

namespace ESCP_Birthsigns
{
    public static class QuadrumNamesPatch
    {
        [HarmonyPatch(typeof(QuadrumUtility))]
        [HarmonyPatch("Label")]
        public static class QuadrumUtility_Label_Patch
        {
            [HarmonyPrefix]
            public static bool QuadramNamePatch(Quadrum quadrum, ref string __result)
            {
                if (!BirthSigns_ModSettings.DisableCustomQuadrumNames)
                {
                    BirthsignSetDef birthsignSetDef = BirthSigns_ModSettings.CurrentSetDef;
                    if (birthsignSetDef != null && birthsignSetDef.QuadrumNameReplacerValid())
                    {
                        __result = birthsignSetDef.overridenQuadrumNames[(int)quadrum];
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
                if (!BirthSigns_ModSettings.DisableCustomQuadrumNames)
                {
                    BirthsignSetDef birthsignSetDef = BirthSigns_ModSettings.CurrentSetDef;
                    if (birthsignSetDef != null && birthsignSetDef.QuadrumNameReplacerValid())
                    {
                        __result = birthsignSetDef.overridenQuadrumNamesShort[(int)quadrum];
                        return false;
                    }
                }
                return true;
            }

        }
    }
}

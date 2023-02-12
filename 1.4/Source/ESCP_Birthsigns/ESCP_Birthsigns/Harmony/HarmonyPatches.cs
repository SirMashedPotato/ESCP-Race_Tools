using HarmonyLib;
using Verse;
using System.Reflection;

namespace ESCP_Birthsigns
{
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.ESCP_Birthsigns");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(PawnGenerator))]
    [HarmonyPatch("GenerateInitialHediffs")]
    public static class PawnGenerator_GenerateInitialHediffs_Patch
    {
        [HarmonyPostfix]
        public static void BirthsignPatch(Pawn pawn)
        {
            if (!BirthSigns_ModSettings.DisableEntirely && BirthSigns_ModSettings.CurrentSetDef != null && Rand.Chance(BirthSigns_ModSettings.ChanceHasSign))
            {
                if (pawn.RaceProps.Humanlike && (BirthsignExclusion.Get(pawn.def) == null || BirthSigns_ModSettings.AllowDisabledRaces))
                {
                    BirthsignSetDef signs = BirthSigns_ModSettings.CurrentSetDef;
                    BirthSignUtility.GenerateBirthsign(pawn, signs);
                }
            }
        }
    }
}

using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;

namespace PreventWoundInfection
{
    //Setting the Harmony instance
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.PreventWoundInfection");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }


    [HarmonyPatch(typeof(HediffComp_Infecter))]
    [HarmonyPatch("CheckMakeInfection")]
    public static class HediffComp_Infecter_CheckMakeInfection_Patch
    {
        [HarmonyPrefix]
        public static bool PreventWoundInfectionPatch(ref HediffComp_Infecter __instance)
        {
            var props = PawnProperties.Get(__instance.Pawn.def);
            if (props != null && props.preventWoundInfection)
            {
                return false;
            }
            return true;
        }
    }
}


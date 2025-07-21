using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;

namespace PreventTrainingDecay
{
    //Setting the Harmony instance
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.PreventTrainingDecay");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    //training decay
    [HarmonyPatch(typeof(Pawn_TrainingTracker))]
    [HarmonyPatch("TrainingTrackerTickRare")]
    public static class Pawn_TrainingTrackerTickRare_Patch
    {
        [HarmonyPrefix]
        public static bool PreventTrainingDecayPatch(ref Pawn ___pawn)
        {
            var props = PawnProperties.Get(___pawn.def);
            if (props != null && props.preventTrainingDecay)
            {
                return false;
            }
            return true;
        }
    }
}


using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;
using System.Collections.Generic;
using System.Linq;

namespace PreventDisease
{
    //Setting the Harmony instance
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.PreventDisease");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(IncidentWorker_Disease))]
    [HarmonyPatch("PotentialVictims")]
    public static class IncidentWorker_Disease_PotentialVictims_Patch
    {
        [HarmonyPostfix]
        public static void IncidentWorker_Disease_DiseasePatch(ref IEnumerable<Pawn> __result)
        {
            List<Pawn> toRemove = new List<Pawn> { };
            foreach (Pawn p in __result)
            {
                var props = PawnProperties.Get(p.def);
                if (props != null && props.preventDisease)
                {
                    toRemove.Add(p);
                }
            }
            if (!toRemove.NullOrEmpty())
            {
                List<Pawn> temp = __result.ToList();
                foreach (Pawn p in toRemove)
                {
                    temp.Remove(p);
                }
                __result = temp;
            }
        }
    }
}


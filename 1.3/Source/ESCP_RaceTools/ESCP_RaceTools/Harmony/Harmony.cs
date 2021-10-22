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
    //Setting the Harmony instance
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.ESCP_RaceTools");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
        /* 
         * Patches to avoid issues with non-unique deity names 
         */
        /*
        [HarmonyPatch(typeof(IdeoFoundation_Deity))]
        [HarmonyPatch("<FillDeity>g__AllExistingDeities|18_0")]
        public static class IdeoFoundation_Deity_DuplicateNameFix
        {
            [HarmonyPostfix]
            public static void NameFix(ref IEnumerable<string> __result, ref List<IdeoFoundation_Deity.Deity> deities)
            {
                Log.Message("Beep boop");
                if (true)
                {
                    for(int i = 0; i >= __result.Count(); i++)
                    {
                        if (deities.ToString().Contains(__result.ElementAt(i)))
                        {
                            __result.ElementAt(i).Replace(__result.ElementAt(i), "null");
                            Log.Message(__result.ElementAt(i));
                        }
                    }
                }

            }
        }
        */

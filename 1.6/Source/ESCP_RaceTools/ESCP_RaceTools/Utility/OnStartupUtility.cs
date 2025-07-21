using Verse;
using System.Collections.Generic;
using System.Linq;

namespace ESCP_RaceTools
{
    [StaticConstructorOnStartup]
    public static class OnStartupUtility
    {
        static OnStartupUtility()
        {
            RemoveFacialAnimationComps();
        }

        public static void RemoveFacialAnimationComps()
        {
            if (!ModsConfig.IsActive("nals.facialanimation"))
            {
                return;
            }

            List<ThingDef> races = DefDatabase<ThingDef>.AllDefsListForReading.Where(x => x.race != null && NLFacialAnimationsBlocker.Get(x) != null).ToList();

            Log.Message("[ESCP RaceTools] detected [NL] Facial Animation. Removing FacialAnimation comps from select races");
            foreach (ThingDef race in races)
            {
                for (int i = race.comps.Count - 1; i >= 0; i--)
                {
                    if (race.comps[i].compClass.Namespace == "FacialAnimation")
                    {
                        race.comps.Remove(race.comps[i]);
                    }
                }
            }
        }
    }
}

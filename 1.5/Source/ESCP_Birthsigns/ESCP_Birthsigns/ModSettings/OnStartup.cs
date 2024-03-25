using Verse;
using System;
using System.Linq;
using System.Collections.Generic;
using RimWorld;

namespace ESCP_Birthsigns
{
    [StaticConstructorOnStartup]
    public static class OnStartup
    {
        public static List<BirthsignSetDef> defs = new List<BirthsignSetDef> { };
        public static string DisabledRaces;

        static OnStartup()
        {
            defs = DefDatabase<BirthsignSetDef>.AllDefsListForReading;
            SetInitialBirthsignSet();
            DisabledRaces = DisabledRaces_Init();
        }

        public static string DisabledRaces_Init()
        {
            string races = "";

            DefDatabase<ThingDef>.AllDefsListForReading.Where(x => BirthsignExclusion.Get(x) != null).ToList().ForEach(action: def =>
            {
                races += "\n - " + def.label;
            });

            if (races == "")
            {
                races = "\n - None";
            }

            return races;
        }

        public static void SetInitialBirthsignSet()
        {
            if (!defs.NullOrEmpty())
            {
                if (defs.Find(x=>x.defName.ToString() == BirthSigns_ModSettings.CurrentSetDef_String) != null)
                {
                    BirthSigns_ModSettings.CurrentSetDef = defs.Find(x => x.defName.ToString() == BirthSigns_ModSettings.CurrentSetDef_String);
                } 
                else
                {
                    BirthSigns_ModSettings.CurrentSetDef = defs.First();
                }
            }
        }
    }
}

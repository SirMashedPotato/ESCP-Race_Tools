using Verse;
using System.Collections.Generic;

namespace ESCP_RaceTools
{

    [StaticConstructorOnStartup]
    public static class LeatherListInit
    {
        public static List<ThingDef> LeatherList_Akaviri = new List<ThingDef> { };
        public static List<ThingDef> LeatherList_Beastfolk = new List<ThingDef> { };
        public static List<ThingDef> LeatherList_GoblinKen = new List<ThingDef> { };
        public static List<ThingDef> LeatherList_Mer = new List<ThingDef> { };

        /* 
         * Argonian - all argonian types
         * Khajiit - all khajiit types
         * Deadra - Only 'Humanlike daedra'
         */

        public static List<string> LeatherList_Akaviri_initial = new List<string>()
        {
            "ESCP_LeatherAkaviri", "ESCP_LeatherKaPoTun", "ESCP_LeatherKamal",
            "ESCP_LeatherTangMo", "ESCP_LeatherTsaesci"
        };

        public static List<string> LeatherList_Beastfolk_initial = new List<string>()
        {
            "ESCP_LeatherArgonian", "ESCP_LeatherKhajiit", "ESCP_LeatherImga",
            "ESCP_LeatherLamia", "ESCP_LeatherLilmothiit", "ESCP_LeatherMinotaur",
            "ESCP_LeatherCentaur"
        };

        public static List<string> LeatherList_GoblinKen_initial = new List<string>()
        {
            "ESCP_LeatherGoblin", "ESCP_LeatherRiekling", "ESCP_LeatherRiekr", "ESCP_LeatherOgre" , "ESCP_LeatherGremlin"
        };

        public static List<string> LeatherList_Mer_initial = new List<string>()
        {
            "ESCP_LeatherAldmer", "ESCP_LeatherAltmer", "ESCP_LeatherAylied", "ESCP_LeatherBosmer", "ESCP_LeatherChimer",
            "ESCP_LeatherDunmer", "ESCP_LeatherDwemer", "ESCP_LeatherFalmer", "ESCP_LeatherMaormer", "ESCP_SinistralMer"
        };

        /* 
         * Special cases:
         * Orsimer - can be mer or goblin-ken, handled through a check
         * Sload - entirely seperate thought worker in the sload mod
         */

        public static string Leather_Orsimer = "ESCP_LeatherOrsimer";

        static LeatherListInit()
        {
            LeatherList_Akaviri = LeatherList_Generic_Init(LeatherList_Akaviri_initial);
            LeatherList_Beastfolk = LeatherList_Generic_Init(LeatherList_Beastfolk_initial);
            LeatherList_GoblinKen = LeatherList_GoblinKen_Init(LeatherList_GoblinKen_initial);
            LeatherList_Mer = LeatherList_Mer_Init(LeatherList_Mer_initial);
        }

        /* Inits */

        public static List<ThingDef> LeatherList_Generic_Init(List<string> initial)
        {
            List<ThingDef> workingList = new List<ThingDef> { };

            foreach(string str in initial)
            {
                ThingDef temp = DefDatabase<ThingDef>.GetNamedSilentFail(str);
                if (temp?.label != null)
                {
                    workingList.Add(temp);
                }
            }

            return workingList;
        }

        public static List<ThingDef> LeatherList_Mer_Init(List<string> initial)
        {
            List<ThingDef> workingList = new List<ThingDef> { };

            foreach (string str in initial)
            {
                ThingDef temp = DefDatabase<ThingDef>.GetNamedSilentFail(str);
                if (temp?.label != null)
                {
                    workingList.Add(temp);
                }
            }

            if (ESCP_RaceTools_ModSettings.OrsimerAreMer)
            {
                ThingDef temp = DefDatabase<ThingDef>.GetNamedSilentFail(Leather_Orsimer);
                if (temp?.label != null)
                {
                    workingList.Add(temp);
                }
            }

            return workingList;
        }

        public static List<ThingDef> LeatherList_GoblinKen_Init(List<string> initial)
        {
            List<ThingDef> workingList = new List<ThingDef> { };

            foreach (string str in initial)
            {
                ThingDef temp = DefDatabase<ThingDef>.GetNamedSilentFail(str);
                if (temp?.label != null)
                {
                    workingList.Add(temp);
                }
            }

            if (!ESCP_RaceTools_ModSettings.OrsimerAreMer)
            {
                ThingDef temp = DefDatabase<ThingDef>.GetNamedSilentFail(Leather_Orsimer);
                if (temp?.label != null)
                {
                    workingList.Add(temp);
                }
            }

            return workingList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class IdeoCultureProperties : DefModExtension
    {
        public bool overrideDivines = false;
        public bool overrideNineDivines = false;
        public List<Divine> divinesList;

        public static IdeoCultureProperties Get(Def def)
        {
            return def.GetModExtension<IdeoCultureProperties>();
        }

        public class Divine
        {
            public string name = null;
            public string type = null;
            public Gender gender = Gender.None;
            public string iconPath = "UI/Deities/DeityGeneric";
        }
    }
}

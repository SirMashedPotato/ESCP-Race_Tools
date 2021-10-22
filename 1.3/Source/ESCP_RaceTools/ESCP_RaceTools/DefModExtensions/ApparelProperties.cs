using System;
using System.Collections.Generic;
using System.Linq;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class ApparelProperties : DefModExtension
    {
        public List<ThingDef> linkedApparel;    //requires these items to be worn too

        public int requiredItems = -1;  //-1 for requiring all

        public List<string> negatedThoughts;    //list of thoughts that are negated if conditions are met

        public static ApparelProperties Get(Def def)
        {
            return def.GetModExtension<ApparelProperties>();
        }
    }
}

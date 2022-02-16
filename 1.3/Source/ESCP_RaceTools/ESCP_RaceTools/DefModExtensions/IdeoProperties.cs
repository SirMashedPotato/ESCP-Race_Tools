using System;
using System.Collections.Generic;
using System.Linq;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    public class IdeoProperties : DefModExtension
    {
        public String preceptDef;

        public HediffDef hediffDef;
        public BodyPartDef partToApplyTo;

        public static IdeoProperties Get(Def def)
        {
            return def.GetModExtension<IdeoProperties>();
        }
    }
}

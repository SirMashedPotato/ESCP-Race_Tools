using System;
using System.Collections.Generic;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class CompProperties_AbilityMoteOnTargetConstant : CompProperties_AbilityEffect
    {
        public CompProperties_AbilityMoteOnTargetConstant()
        {
            this.compClass = typeof(CompAbilityEffect_MoteOnTargetConstant);
        }

        public ThingDef moteDef;

        public List<ThingDef> moteDefs;

        public float scale = 1f;

        public int preCastTicks;
    }
}

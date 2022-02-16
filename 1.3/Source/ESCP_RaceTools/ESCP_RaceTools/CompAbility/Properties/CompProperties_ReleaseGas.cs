using System;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class CompProperties_ReleaseGas : CompProperties_AbilityEffectWithDuration
    {
        public CompProperties_ReleaseGas()
        {
            this.compClass = typeof(CompAbilityEffect_ReleaseGas);
        }

        public ThingDef gasDef;
        public float radius = 3;
    }
}

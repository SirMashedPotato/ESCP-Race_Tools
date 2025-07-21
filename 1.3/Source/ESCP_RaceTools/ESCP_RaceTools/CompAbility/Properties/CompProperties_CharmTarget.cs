using System;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class CompProperties_CharmTarget : CompProperties_AbilityEffect
    {
        public CompProperties_CharmTarget()
        {
            this.compClass = typeof(CompEffect_AbilityCharmTarget);
        }
    }
}

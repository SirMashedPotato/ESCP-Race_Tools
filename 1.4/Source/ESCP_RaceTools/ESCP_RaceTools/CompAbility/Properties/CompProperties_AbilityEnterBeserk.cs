using System;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    public class CompProperties_AbilityEnterBeserk : CompProperties_AbilityEffect
    {
        public CompProperties_AbilityEnterBeserk()
        {
            this.compClass = typeof(CompEffect_AbilityEnterBeserk);
        }

        public bool applyToSelf = true;
        public ThingDef raceDef;
    }
}

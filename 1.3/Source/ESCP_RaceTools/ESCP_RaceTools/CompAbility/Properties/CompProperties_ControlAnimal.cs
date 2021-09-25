using System;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    public class CompProperties_ControlAnimal : CompProperties_AbilityEffectWithDuration
    {
        public CompProperties_ControlAnimal()
        {
            this.compClass = typeof(CompAbilityEffect_ControlAnimal);
        }

        public HediffDef hediffDef;
        public bool onlyBrain;
    }
}

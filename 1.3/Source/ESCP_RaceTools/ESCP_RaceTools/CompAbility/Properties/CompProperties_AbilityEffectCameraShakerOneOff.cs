using System;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    public class CompProperties_AbilityEffectCameraShakerOneOff : CompProperties_AbilityEffect
    {
        public CompProperties_AbilityEffectCameraShakerOneOff()
        {
            this.compClass = typeof(CompEffect_AbilityCameraShakerOneOff);
        }

        public float mag = 0.05f;

        public int preCastTicks;
    }
}

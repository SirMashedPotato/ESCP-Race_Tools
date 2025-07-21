using System;
using RimWorld;
using Verse;

namespace ESCP_RaceTools
{
    public class HediffCompProperties_GiveHediffsInRange : HediffCompProperties
    {
        public HediffCompProperties_GiveHediffsInRange()
        {
            this.compClass = typeof(ESCP_RaceTools.HediffComp_GiveHediffsInRange);
        }

		public float range;

		public TargetingParameters targetingParameters;

		public HediffDef hediff;

		public ThingDef mote;

		public bool hideMoteWhenNotDrafted;

		public float initialSeverity = 1f;

		public bool onlyPawnsInSameFaction = true;

		public bool allowAnimals = true;
	}
}

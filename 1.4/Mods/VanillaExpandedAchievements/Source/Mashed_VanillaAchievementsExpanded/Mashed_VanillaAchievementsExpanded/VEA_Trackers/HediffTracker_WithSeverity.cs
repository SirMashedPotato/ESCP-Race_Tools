using System;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;
using System.Collections.Generic;
using AchievementsExpanded;


namespace Mashed_VanillaAchievementsExpanded
{
    class HediffTracker_WithSeverity : HediffTracker
    {
        public HediffTracker_WithSeverity()
        {

        }

        public HediffTracker_WithSeverity(HediffTracker_WithSeverity reference) : base(reference)
        {
            minSeverity = reference.minSeverity;
        }


        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref minSeverity, "minSeverity");
        }

        public override bool Trigger(Hediff hediff)
        {
            if (hediff?.pawn != null && hediff.pawn.Faction == Faction.OfPlayerSilentFail && (def is null || def == hediff.def) && hediff.Severity >= minSeverity)
            {
                triggeredCount++;
            }
            return triggeredCount >= count;
        }

        public float minSeverity = 0f;
    }
}

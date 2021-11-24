using System;
using System.Collections.Generic;
using RimWorld;
using RimWorld.Planet;
using Verse;

namespace ESCP_RaceTools
{
    class HediffGiver_OnCreation : HediffGiver
    {
        public override void OnIntervalPassed(Pawn pawn, Hediff cause)
        {
            if (!HasHediff(pawn)/* && !PawnUtility.IsBiologicallyBlind(pawn)*/)
            {
                base.TryApply(pawn);
            }
        }

        public bool HasHediff(Pawn pawn)
        {
            return pawn.health.hediffSet.GetHediffCount(this.hediff) >= this.countToAffect;
        }
    }
}

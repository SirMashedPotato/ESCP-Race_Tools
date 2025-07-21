using System;
using System.Collections.Generic;
using RimWorld;
using RimWorld.Planet;
using Verse;

namespace ESCP_RaceTools
{

    /*
     * can't apply to specific body parts
     */

    class HediffGiver_ChanceOnCreation : HediffGiver
    {
        public override void OnIntervalPassed(Pawn pawn, Hediff cause)
        {
            if (!HasHediff(pawn))
            {
                if (Rand.Chance(chance))
                {
                    pawn.health.AddHediff(this.hediff).Severity = activatedSeverity;
                    if (abilityDef != null && pawn.abilities.GetAbility(abilityDef) == null)
                    {
                        pawn.abilities.GainAbility(abilityDef);
                    }
                } 
                else
                {
                    pawn.health.AddHediff(this.hediff).Severity = inactiveSeverity;

                }

            }
        }

        public bool HasHediff(Pawn pawn)
        {
            return pawn.health.hediffSet.GetFirstHediffOfDef(this.hediff) != null;
        }

        public float inactiveSeverity = 0.5f;
        public float activatedSeverity = 1f;
        public float chance = 0.5f;
        public AbilityDef abilityDef;
    }
}

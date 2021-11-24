using System;
using System.Collections.Generic;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    public class RitualAttachableOutcomeEffectWorker_DunmerAncestorKnowledge : RitualAttachableOutcomeEffectWorker
    {
        private List<HediffDef> hediffDefs = new List<HediffDef> 
        { 
            HediffDef.Named("ESCP_DunmerAncestralGuidance"), HediffDef.Named("ESCP_DunmerAncestralProtection"), HediffDef.Named("ESCP_DunmerAncestralSight"), HediffDef.Named("ESCP_DunmerAncestralWisdom"),
                HediffDef.Named("ESCP_DunmerAncestralHealing")
        };

        public override void Apply(Dictionary<Pawn, int> totalPresence, LordJob_Ritual jobRitual, OutcomeChance outcome, out string extraOutcomeDesc, ref LookTargets letterLookTargets)
        {
            int duration = ESCP_AbilityUtility.GetAncestorGiftDuration(jobRitual.PawnWithRole("ESCP_DunmerSpeaker").GetStatValue(StatDefOf.PsychicSensitivity), GetMaxDuration(outcome, jobRitual)).SecondsToTicks();
            foreach(Pawn p in totalPresence.Keys)
            {
                HediffDef hDef = hediffDefs.RandomElement();

                if (p.health.hediffSet.GetFirstHediffOfDef(hDef) != null)
                {
                    p.health.RemoveHediff(p.health.hediffSet.GetFirstHediffOfDef(hDef));
                }

                Hediff hediff = HediffMaker.MakeHediff(hDef, p, p.health.hediffSet.GetBrain());
                HediffComp_Disappears hediffComp_Disappears = hediff.TryGetComp<HediffComp_Disappears>();
                if (hediffComp_Disappears != null)
                {
                    hediffComp_Disappears.ticksToDisappear = duration;
                }
                p.health.AddHediff(hediff, null, null, null);
            }

            extraOutcomeDesc = this.def.letterInfoText + ESCP_AbilityUtility.GetAncestorGiftDuration_Display(duration) + ".";
        }


        public float GetMaxDuration(OutcomeChance outcome, LordJob_Ritual jobRitual)
        {
            return outcome.BestPositiveOutcome(jobRitual) ? 5000f : 3000f;
        }

        //private readonly float duration = 3000; //could make a setting
    }
}

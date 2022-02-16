using System;
using System.Collections.Generic;
using System.Linq;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class RitualOutcomeEffectWorker_GiveHediff_KillOnFail : RitualOutcomeEffectWorker_FromQuality
    {
        public RitualOutcomeEffectWorker_GiveHediff_KillOnFail()
        {
        }

        public RitualOutcomeEffectWorker_GiveHediff_KillOnFail(RitualOutcomeEffectDef def) : base(def)
        {
        }

		protected override void ApplyExtraOutcome(Dictionary<Pawn, int> totalPresence, LordJob_Ritual jobRitual, OutcomeChance outcome, out string extraOutcomeDesc, ref LookTargets letterLookTargets)
		{
			extraOutcomeDesc = null;
			if (!outcome.Positive)
			{
				Pawn pawn = ((LordJob_Ritual_Mutilation)jobRitual).mutilatedPawns[0];	//TODO
				extraOutcomeDesc = "ESCP_RitualOutcomeExtraDesc_KilledPawn".Translate(pawn.Named("PAWN"));
				pawn.Kill(null);
			}
		}
	}
}

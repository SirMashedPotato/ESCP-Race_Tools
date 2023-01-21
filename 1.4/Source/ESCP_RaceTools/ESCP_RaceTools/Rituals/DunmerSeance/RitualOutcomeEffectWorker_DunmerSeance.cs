using System.Collections.Generic;
using System.Linq;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class RitualOutcomeEffectWorker_DunmerSeance : RitualOutcomeEffectWorker_FromQuality
    {
        public RitualOutcomeEffectWorker_DunmerSeance()
        {
        }

        public RitualOutcomeEffectWorker_DunmerSeance(RitualOutcomeEffectDef def) : base(def)
        {
        }

		protected override void ApplyExtraOutcome(Dictionary<Pawn, int> totalPresence, LordJob_Ritual jobRitual, OutcomeChance outcome, out string extraOutcomeDesc, ref LookTargets letterLookTargets)
		{
			extraOutcomeDesc = null;
			if (ModsConfig.RoyaltyActive && outcome.Positive && outcome.BestPositiveOutcome(jobRitual) && Rand.Chance(ESCP_RaceTools_ModSettings.SeancePsylinkChance))
			{
				Pawn pawn = totalPresence.Where(x => x.Key.GetPsylinkLevel() < x.Key.GetMaxPsylinkLevel()).RandomElement().Key;
                if (pawn != null)
                {
					extraOutcomeDesc = "ESCP_DunmerRitualOutcomeExtraDesc_SeancePsylink".Translate(pawn.Named("PAWN"));
					List<Ability> existingAbils = pawn.abilities.AllAbilitiesForReading.ToList();
					pawn.ChangePsylinkLevel(1, true);
					Ability ability = pawn.abilities.AllAbilitiesForReading.FirstOrDefault((Ability a) => !existingAbils.Contains(a));
					if (ability != null)
					{
						extraOutcomeDesc += " " + "ESCP_DunmerRitualOutcomeExtraDesc_SeancePsylinkAbility".Translate(ability.def.LabelCap, pawn.Named("PAWN"));
					}
				}
			}

		}
	}
}

using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class CompAbilityEffect_ControlAnimal : CompAbilityEffect_WithDuration
	{
		public new CompProperties_ControlAnimal Props
		{
			get
			{
				return (CompProperties_ControlAnimal)props;
			}
		}

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
			if(target != null && CanApplyOn(target, dest))
			{
				Pawn pawn = target.Pawn;
				Hediff hediff = HediffMaker.MakeHediff(Props.hediffDef, pawn, Props.onlyBrain ? pawn.health.hediffSet.GetBrain() : null);
				HediffComp_Disappears hediffComp_Disappears = hediff.TryGetComp<HediffComp_Disappears>();
				if (hediffComp_Disappears != null)
				{
					hediffComp_Disappears.ticksToDisappear = GetDurationSeconds(pawn).SecondsToTicks();
				}
				HediffComp_Link hediffComp_Link = hediff.TryGetComp<HediffComp_Link>();
				if (hediffComp_Link != null)
				{
					hediffComp_Link.other = parent.pawn;
					hediffComp_Link.drawConnection = (target == parent.pawn);
				}
				pawn.SetFaction(Faction.OfPlayer, null);
				foreach (TrainableDef td in DefDatabase<TrainableDef>.AllDefs)
				{
					if (pawn.training.CanAssignToTrain(td))
					{
						pawn.training.Train(td, null, true);
					}
				}
				//add hediff last for achievement tracker
				pawn.health.AddHediff(hediff, null, null, null);
				Messages.Message("ESCP_BosmerControlAnimal".Translate(pawn), pawn, MessageTypeDefOf.PositiveEvent, true);
			}
		}

        public override bool Valid(LocalTargetInfo target, bool throwMessages = false)
		{
			Pawn pawn = target.Pawn;
			return pawn != null && AbilityUtility.ValidateMustBeAnimal(pawn, throwMessages, parent) && ESCP_AbilityUtility.ValidateMustBeFactionless(pawn, throwMessages)
				&& AbilityUtility.ValidateNoMentalState(pawn, throwMessages, parent) && AbilityUtility.ValidateIsAwake(pawn, throwMessages, parent);
		}

		public override bool CanApplyOn(LocalTargetInfo target, LocalTargetInfo dest)
		{
			return AbilityUtility.ValidateNoMentalState(target.Pawn, false, parent) && ESCP_AbilityUtility.ValidateMustBeFactionless(target.Pawn, false) && base.CanApplyOn(target, dest);
		}
	}
}

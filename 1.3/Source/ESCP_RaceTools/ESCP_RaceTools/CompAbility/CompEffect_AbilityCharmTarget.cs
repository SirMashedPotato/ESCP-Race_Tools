using System;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class CompEffect_AbilityCharmTarget : CompAbilityEffect
    {
		public new CompProperties_CharmTarget Props
		{
			get
			{
				return (CompProperties_CharmTarget)this.props;
			}
		}

		public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
		{
			if (target != null && CanApplyOn(target, dest))
			{
				Pawn pawn = target.Pawn;
				Pawn caster = parent.pawn;
				pawn.needs.mood.thoughts.memories.TryGainMemory(ThoughtDefOf.ESCP_Charmed, caster);
			}
		}

		public override bool Valid(LocalTargetInfo target, bool throwMessages = false)
		{
			Pawn pawn = target.Pawn;
			return pawn != null && target.Pawn.RaceProps.Humanlike
				&& AbilityUtility.ValidateNoMentalState(pawn, throwMessages) && AbilityUtility.ValidateIsAwake(pawn, throwMessages);
		}

		public override bool CanApplyOn(LocalTargetInfo target, LocalTargetInfo dest)
		{
			return AbilityUtility.ValidateNoMentalState(target.Pawn, false) && target.Pawn.RaceProps.Humanlike && base.CanApplyOn(target, dest);
		}
	}
}

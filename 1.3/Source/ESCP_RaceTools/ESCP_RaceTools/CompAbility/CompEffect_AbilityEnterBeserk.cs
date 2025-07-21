using System;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class CompEffect_AbilityEnterBeserk : CompAbilityEffect
    {

		public new CompProperties_AbilityEnterBeserk Props
		{
			get
			{
				return (CompProperties_AbilityEnterBeserk)this.props;
			}
		}
		
		public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
		{
			if (CanApplyOn(target, dest))
			{
				Pawn pawn = target.Pawn;
				Comp_BeserkerRage comp = pawn.GetComp<Comp_BeserkerRage>();
				comp.ResetRage(pawn);
				comp.ActivateRage(pawn);
			}
		}

		public override bool Valid(LocalTargetInfo target, bool throwMessages = false)
		{
			Pawn pawn = target.Pawn;
			return pawn != null && pawn.def == Props.raceDef;
		}

		public override bool CanApplyOn(LocalTargetInfo target, LocalTargetInfo dest)
		{
			return target.Pawn != null && target.Pawn.def == Props.raceDef && base.CanApplyOn(target, dest);
		}
	}
}

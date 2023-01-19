using System;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    //Basically just give hediff, but the duration scales based on the casters psychic sensitivity
    public class CompAbilityEffect_GiveAncestralHediff : CompAbilityEffect_WithDuration
	{
		public new CompProperties_AbilityGiveHediff Props
		{
			get
			{
				return (CompProperties_AbilityGiveHediff)this.props;
			}
		}

		public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
		{
			base.Apply(target, dest);
			if (!this.Props.onlyApplyToSelf && this.Props.applyToTarget)
			{
				this.ApplyInner(target.Pawn, this.parent.pawn);
			}
			if (this.Props.applyToSelf || this.Props.onlyApplyToSelf)
			{
				this.ApplyInner(this.parent.pawn, target.Pawn);
			}
		}

		protected void ApplyInner(Pawn target, Pawn other)
		{
			if (target != null)
			{
				if (this.Props.replaceExisting)
				{
					Hediff firstHediffOfDef = target.health.hediffSet.GetFirstHediffOfDef(this.Props.hediffDef, false);
					if (firstHediffOfDef != null)
					{
						target.health.RemoveHediff(firstHediffOfDef);
					}
				}
				Hediff hediff = HediffMaker.MakeHediff(this.Props.hediffDef, target, this.Props.onlyBrain ? target.health.hediffSet.GetBrain() : null);
				HediffComp_Disappears hediffComp_Disappears = hediff.TryGetComp<HediffComp_Disappears>();
				if (hediffComp_Disappears != null)
				{
					hediffComp_Disappears.ticksToDisappear = ESCP_AbilityUtility.GetAncestorGiftDuration(this.parent.pawn.GetStatValue(StatDefOf.PsychicSensitivity)).SecondsToTicks();
				}
				HediffComp_Link hediffComp_Link = hediff.TryGetComp<HediffComp_Link>();
				if (hediffComp_Link != null)
				{
					hediffComp_Link.other = other;
					hediffComp_Link.drawConnection = (target == this.parent.pawn);
				}
				target.health.AddHediff(hediff, null, null, null);
			}
		}

        public override string ExtraTooltipPart()
        {
			int num = ESCP_AbilityUtility.GetAncestorGiftDuration(this.parent.pawn.GetStatValue(StatDefOf.PsychicSensitivity)).SecondsToTicks();
			return ESCP_AbilityUtility.GetAncestorGiftDuration_Display(num);
		}
    }
}

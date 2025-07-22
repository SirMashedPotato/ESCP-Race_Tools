using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
	/// <summary>
	/// Basically just give hediff, but the duration scales based on the casters psychic sensitivity
	/// </summary>
	public class CompAbilityEffect_GiveAncestralHediff : CompAbilityEffect_WithDuration
	{
		public new CompProperties_AbilityGiveHediff Props => (CompProperties_AbilityGiveHediff)props;

		public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
		{
			base.Apply(target, dest);
			if (!Props.onlyApplyToSelf && Props.applyToTarget)
			{
				ApplyInner(target.Pawn, parent.pawn);
			}
			if (Props.applyToSelf || Props.onlyApplyToSelf)
			{
				ApplyInner(parent.pawn, target.Pawn);
			}
		}

		protected void ApplyInner(Pawn target, Pawn other)
		{
			if (target != null)
			{
				if (Props.replaceExisting)
				{
					Hediff firstHediffOfDef = target.health.hediffSet.GetFirstHediffOfDef(Props.hediffDef, false);
					if (firstHediffOfDef != null)
					{
						target.health.RemoveHediff(firstHediffOfDef);
					}
				}
				Hediff hediff = HediffMaker.MakeHediff(Props.hediffDef, target, Props.onlyBrain ? target.health.hediffSet.GetBrain() : null);
				HediffComp_Disappears hediffComp_Disappears = hediff.TryGetComp<HediffComp_Disappears>();
				if (hediffComp_Disappears != null)
				{
					hediffComp_Disappears.ticksToDisappear = ESCP_AbilityUtility.GetAncestorGiftDuration(parent.pawn.GetStatValue(StatDefOf.PsychicSensitivity)).SecondsToTicks();
				}
				HediffComp_Link hediffComp_Link = hediff.TryGetComp<HediffComp_Link>();
				if (hediffComp_Link != null)
				{
					hediffComp_Link.other = other;
					hediffComp_Link.drawConnection = (target == parent.pawn);
				}
				target.health.AddHediff(hediff, null, null, null);
			}
		}

        public override string ExtraTooltipPart()
        {
			int num = ESCP_AbilityUtility.GetAncestorGiftDuration(parent.pawn.GetStatValue(StatDefOf.PsychicSensitivity)).SecondsToTicks();
			return ESCP_AbilityUtility.GetAncestorGiftDuration_Display(num);
		}
    }
}

using Verse;
using RimWorld;

namespace ESCP_Birthsigns_Abilities
{
    public class CompAbilityEffect_FatigueSelf : CompAbilityEffect
	{
		public new CompProperties_AbilityFatigueSelf Props
		{
			get
			{
				return (CompProperties_AbilityFatigueSelf)this.props;
			}
		}

		public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
		{
			base.Apply(target, dest);
			if (target != null)
			{
				Need rest = this.parent.pawn.needs.TryGetNeed(NeedDefOf.Rest);
				if(rest != null)
                {
					rest.CurLevelPercentage -= Props.amount;
                }
			}
		}

        public override bool GizmoDisabled(out string reason)
        {
            if (Props.disableIfLow)
            {
				Need rest = this.parent.pawn.needs.TryGetNeed(NeedDefOf.Rest);
				if (rest != null)
				{
                    if (rest.CurLevelPercentage - Props.amount < 0)
                    {
						reason = "ESCP_BirthSigns_TipString_FatigueDisabled".Translate();
						return true;
                    }
				}
			}
            return base.GizmoDisabled(out reason);
        }

        public override string ExtraTooltipPart()
		{
			return "ESCP_BirthSigns_TipString_FatigueAmount".Translate(Props.amount.ToStringPercent());
		}
	}
}

using Verse;
using RimWorld;

namespace ESCP_Birthsigns_Abilities
{
	public class CompAbilityEffect_HealWounds : CompAbilityEffect
	{
		public new CompProperties_AbilityHealWounds Props
		{
			get
			{
				return (CompProperties_AbilityHealWounds)this.props;
			}
		}

		public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
		{
			base.Apply(target, dest);
			if (target != null)
			{
				Pawn p = target.Pawn;
				float healedAmount = 0;
				while(healedAmount <= Props.totalSeverityToHeal)
                {
					Hediff h = p.health.hediffSet.GetHediffsTendable().RandomElement();
                    if (h != null)
                    {
						h.Severity -= Props.healSeveriyty;
						healedAmount += Props.healSeveriyty;
                    }
					else
                    {
						return;
                    }
                }
			}
		}
		/*
		public override string ExtraTooltipPart()
		{
			return "ESCP_BirthSigns_TipString_AbilityDamage".Translate(Props.damageAmount, Props.damageDef.label);
		}
		*/
	}
}

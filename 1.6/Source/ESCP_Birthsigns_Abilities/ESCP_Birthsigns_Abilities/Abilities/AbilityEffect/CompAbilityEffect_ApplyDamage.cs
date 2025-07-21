using Verse;
using RimWorld;

namespace ESCP_Birthsigns_Abilities
{
    public class CompAbilityEffect_ApplyDamage : CompAbilityEffect
    {
		public new CompProperties_AbilityApplyDamage Props
		{
			get
			{
				return (CompProperties_AbilityApplyDamage)this.props;
			}
		}

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);
			if (target != null)
			{
				Pawn p = target.Pawn;
				DamageInfo dinfo = new DamageInfo(Props.damageDef, Props.damageAmount, Props.armourPenetration, -1, this.parent.pawn);
				p.TakeDamage(dinfo);
			}
		}

        public override string ExtraTooltipPart()
        {
			return "ESCP_BirthSigns_TipString_AbilityDamage".Translate(Props.damageAmount, Props.damageDef.label);
        }
    }
}

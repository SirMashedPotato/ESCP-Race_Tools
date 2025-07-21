using Verse;

namespace ESCP_Birthsigns_Abilities
{
    public class HediffComp_ScaledStatOffset : HediffComp
    {
		public HediffCompProperties_ScaledStatOffset Props
		{
			get
			{
				return (HediffCompProperties_ScaledStatOffset)this.props;
			}
		}

		public override string CompTipStringExtra => "ESCP_BirthSigns_TipString_ScaledStatOffset".Translate(Props.statDef.label.CapitalizeFirst(), Props.factor.ToStringPercent(), Props.skillDef.label.CapitalizeFirst());

	}
}

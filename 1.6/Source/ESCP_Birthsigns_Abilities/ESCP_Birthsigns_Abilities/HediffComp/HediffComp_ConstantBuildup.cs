using Verse;

namespace ESCP_Birthsigns_Abilities
{
    public class HediffComp_ConstantBuildup : HediffComp
    {
		public HediffCompProperties_ConstantBuildup Props
		{
			get
			{
				return (HediffCompProperties_ConstantBuildup)this.props;
			}
		}

        private int ticks;

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);
            if (ticks > Props.ticksPer)
            {
                Pawn p = this.parent.pawn;
                Hediff hediff = HediffMaker.MakeHediff(Props.hediffDef, p);
                hediff.Severity = Props.amountPerSecond * (1f / this.parent.pawn.BodySize);
                p.health.AddHediff(hediff);
                ticks = 0;
            }
            ticks++;
        }
    }
}

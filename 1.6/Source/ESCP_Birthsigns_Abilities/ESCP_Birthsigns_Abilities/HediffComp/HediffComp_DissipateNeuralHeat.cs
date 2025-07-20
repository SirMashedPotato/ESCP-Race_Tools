using Verse;

namespace ESCP_Birthsigns_Abilities
{
    public class HediffComp_DissipateNeuralHeat : HediffComp
	{
		public HediffCompProperties_DissipateNeuralHeat Props
		{
			get
			{
				return (HediffCompProperties_DissipateNeuralHeat)this.props;
			}
		}

        public override void Notify_PawnPostApplyDamage(DamageInfo dinfo, float totalDamageDealt)
        {
            base.Notify_PawnPostApplyDamage(dinfo, totalDamageDealt);

            if (ModsConfig.RoyaltyActive)
            {
                Pawn p = parent.pawn;
                if (p.HasPsylink)
                {
                    if (Rand.Chance(Props.chance))
                    {
                        /// * -1 turns the number into a negative, decreasing neural heat instead of adding to it
                        p.psychicEntropy.TryAddEntropy((totalDamageDealt * Props.factor) * -1);
                    }
                }
            }
        }

        public override string CompTipStringExtra => "ESCP_BirthSigns_TipString_DissipateNeuralHeat".Translate(Props.factor.ToStringPercent());
    }
}

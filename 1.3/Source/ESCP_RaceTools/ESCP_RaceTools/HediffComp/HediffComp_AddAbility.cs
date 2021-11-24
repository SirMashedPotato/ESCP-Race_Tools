using System;
using RimWorld;
using Verse;

namespace ESCP_RaceTools
{
    class HediffComp_AddAbility : HediffComp
	{
		public HediffCompProperties_AddAbility Props
		{
			get
			{
				return (HediffCompProperties_AddAbility)this.props;
			}
		}

        public override void CompPostPostAdd(DamageInfo? dinfo)
        {
            if(Props.abilityDef != null && this.Pawn.abilities.GetAbility(Props.abilityDef) == null)
            {
                this.Pawn.abilities.GainAbility(Props.abilityDef);
            }
        }

        public override void CompPostPostRemoved()
        {
            if (Props.abilityDef != null && this.Pawn.abilities.GetAbility(Props.abilityDef) != null)
            {
                this.Pawn.abilities.RemoveAbility(Props.abilityDef);
            }
        }
    }
}

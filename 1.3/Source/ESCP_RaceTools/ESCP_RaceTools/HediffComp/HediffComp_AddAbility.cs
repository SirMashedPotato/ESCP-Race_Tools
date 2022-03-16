using System;
using RimWorld;
using Verse;
using System.Collections.Generic;

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
            if(Props.abilityDef != null && this.Pawn.abilities.GetAbility(Props.abilityDef) == null
                && parent.Severity >= Props.severityRequired)
            {
                this.Pawn.abilities.GainAbility(Props.abilityDef);
                
            }

            if (Props.abilityDefList.Any())
            {
                foreach(AbilityDef ab in Props.abilityDefList)
                {
                    if (this.Pawn.abilities.GetAbility(Props.abilityDef) == null)
                    {
                        this.Pawn.abilities.GainAbility(ab);
                    }
                }
            }

            if (Props.removeHediffOnApply)
            {
                base.Pawn.health.RemoveHediff(this.parent);
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

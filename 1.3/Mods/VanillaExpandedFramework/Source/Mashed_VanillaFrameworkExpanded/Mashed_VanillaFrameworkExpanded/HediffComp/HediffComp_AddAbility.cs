using System;
using RimWorld;
using Verse;
using System.Collections.Generic;
using VFECore.Abilities;

namespace Mashed_VanillaFrameworkExpanded
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
            Pawn pawn = this.Pawn;
            if(pawn.GetComp<VFECore.Abilities.CompAbilities>() == null)
            {
                return;
            }
            if (Props.abilityDef != null && parent.Severity >= Props.severityRequired)
            {
                pawn.GetComp<VFECore.Abilities.CompAbilities>()?.GiveAbility(Props.abilityDef);

            }
            if (Props.abilityDefList.Any())
            {
                foreach (VFECore.Abilities.AbilityDef ab in Props.abilityDefList)
                {

                        pawn.GetComp<VFECore.Abilities.CompAbilities>()?.GiveAbility(ab);

                }
            }
            if (Props.removeHediffOnApply)
            {
                base.Pawn.health.RemoveHediff(this.parent);
            }
        }
    }
}

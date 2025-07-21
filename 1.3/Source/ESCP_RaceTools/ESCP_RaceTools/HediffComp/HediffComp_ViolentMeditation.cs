using System;
using System.Collections.Generic;
using Verse;
using RimWorld;
using System.Linq;

namespace ESCP_RaceTools
{
    class HediffComp_ViolentMeditation : HediffComp
    {

        public HediffCompProperties_ViolentMeditation Props
        {
            get
            {
                return (HediffCompProperties_ViolentMeditation)this.props;
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
                    p.psychicEntropy.OffsetPsyfocusDirectly(totalDamageDealt/1000f);
                }
            }
        }
    }
}

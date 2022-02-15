using System;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class CompAbilityEffect_ReleaseGas : CompAbilityEffect
    {
        public new CompProperties_ReleaseGas Props
        {
            get
            {
                return (CompProperties_ReleaseGas)this.props;
            }
        }

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            if(Props.gasDef != null)
            {
                GenExplosion.DoExplosion(target.Cell, parent.pawn.Map, Props.radius, DamageDefOf.Extinguish, parent.pawn, -1, -1f, null, null, null, null, Props.gasDef, 1f, 1, false, null, 0f, 1, 0f, false, null, null);
            }
        }
    }
}

using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class CompAbilityEffect_ReleaseGas : CompAbilityEffect
    {
        public new CompProperties_ReleaseGas Props => (CompProperties_ReleaseGas)props;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            if(Props.gasDef != null)
            {
                GenExplosion.DoExplosion(target.Cell, parent.pawn.Map, Props.radius, DamageDefOf.Extinguish, parent.pawn, -1, -1, null, null, null, null, Props.gasDef, 1, 1);
            }
        }
    }
}

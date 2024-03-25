using Verse;
using RimWorld;

namespace ESCP_Birthsigns_Abilities
{
    public class CompAbilityEffect_GiveHediff_StarCurse : CompAbilityEffect_GiveHediff
    {
        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);
            ApplySelf(this.parent.pawn);
        }

        protected void ApplySelf(Pawn self)
        {
            Hediff hediff = HediffMaker.MakeHediff(this.Props.hediffDef, self, this.Props.onlyBrain ? self.health.hediffSet.GetBrain() : null);
            HediffComp_Disappears hediffComp_Disappears = hediff.TryGetComp<HediffComp_Disappears>();
            if (hediffComp_Disappears != null)
            {
                hediffComp_Disappears.ticksToDisappear = base.GetDurationSeconds(self).SecondsToTicks() / 3;
            }

            self.health.AddHediff(hediff, null, null, null);
        }

        public override string ExtraTooltipPart()
        {
            return "ESCP_BirthSigns_TipString_AbilityDurationSelf".Translate((base.GetDurationSeconds(this.parent.pawn).SecondsToTicks() / 60) / 3);
        }
    }
}

using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    public class CompProperties_AbilityDoDamage : CompProperties_AbilityEffect
    {
        public DamageDef damageDef;
        public float damageAmount = 10f;
        public bool onlyHostile = false;

        public CompProperties_AbilityDoDamage()
        {
            compClass = typeof(CompAbilityEffect_DoDamage);
        }
    }
}

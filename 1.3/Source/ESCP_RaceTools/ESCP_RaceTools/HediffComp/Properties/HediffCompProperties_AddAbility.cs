using System;
using RimWorld;
using Verse;


namespace ESCP_RaceTools
{
    class HediffCompProperties_AddAbility : HediffCompProperties
    {
        public HediffCompProperties_AddAbility()
        {
            this.compClass = typeof(HediffComp_AddAbility);
        }

        public AbilityDef abilityDef;
    }
}

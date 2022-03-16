using System;
using RimWorld;
using Verse;
using System.Collections.Generic;


namespace ESCP_RaceTools
{
    class HediffCompProperties_AddAbility : HediffCompProperties
    {
        public HediffCompProperties_AddAbility()
        {
            this.compClass = typeof(HediffComp_AddAbility);
        }

        public AbilityDef abilityDef;
        public List<AbilityDef> abilityDefList;
        public float severityRequired = 0f;
        public bool removeHediffOnApply = false;
    }
}

using System;
using RimWorld;
using Verse;
using System.Collections.Generic;
using VFECore.Abilities;

namespace Mashed_VanillaFrameworkExpanded
{
    class HediffCompProperties_AddAbility : HediffCompProperties
    {
        public HediffCompProperties_AddAbility()
        {
            this.compClass = typeof(HediffComp_AddAbility);
        }

        public VFECore.Abilities.AbilityDef abilityDef;
        public List<VFECore.Abilities.AbilityDef> abilityDefList;
        public float severityRequired = 0f;
        public bool removeHediffOnApply = false;
    }
}

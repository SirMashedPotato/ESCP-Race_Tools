using System;
using Verse;
using RimWorld;
using System.Linq;
using System.Collections.Generic;

namespace ESCP_RaceTools
{
    class CompProperties_SloadThrallCreate : CompProperties_AbilityEffect
    {
        public CompProperties_SloadThrallCreate()
        {
            this.compClass = typeof(CompAbilityEffect_SloadThrallCreate);
        }

        public SkillDef skill;
        public HediffDef hediff = null;
        //two linked lists, as such the count in each should match
        public List<int> thrallLimit;
        public List<int> levelRequirement;
    }
}

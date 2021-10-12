using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class RoleRequirement_RaceMulti : RoleRequirement
    {
        public override string GetLabel(Precept_Role role)
        {
            if (this.labelCached == null)
            {
                this.labelCached = "ESCP_IdeoRequirementRace".Translate() + ": " + races[0].label;
            }
            return labelCached;
        }

        public override bool Met(Pawn p, Precept_Role role)
        {
            return races.Contains(p.def);
        }

        public List<ThingDef> races;

        [NoTranslate]
        private string labelCached;
    }
}

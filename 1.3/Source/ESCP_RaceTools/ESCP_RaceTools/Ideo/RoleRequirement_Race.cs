using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class RoleRequirement_Race : RoleRequirement
    {
        public override string GetLabel(Precept_Role role)
        {
            if (this.labelCached == null)
            {
                 this.labelCached = "ESCP_RaceRequirementRace".Translate() + ": " + race.label;
            }
            return labelCached;
        }

        public override bool Met(Pawn p, Precept_Role role)
        {
            return p.def == race;
        }

        public ThingDef race;

        [NoTranslate]
        private string labelCached;
    }
}

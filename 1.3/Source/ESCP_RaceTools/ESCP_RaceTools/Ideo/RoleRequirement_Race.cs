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
                if (ModSettingsUtility_Ideo.ESCP_RaceTools_IdeologyOverrideRace())
                {
                    this.labelCached = "ESCP_IdeoRequirementRace".Translate() + ": " + "ESCP_IdeoRequirementRaceAny".Translate();
                } 
                else
                {
                    this.labelCached = "ESCP_IdeoRequirementRace".Translate() + ": " + race.label;
                }
            }
            return labelCached;
        }

        public override bool Met(Pawn p, Precept_Role role)
        {
            return p.def == race || ModSettingsUtility_Ideo.ESCP_RaceTools_IdeologyOverrideRace();
        }

        public ThingDef race;

        [NoTranslate]
        private string labelCached;
    }
}

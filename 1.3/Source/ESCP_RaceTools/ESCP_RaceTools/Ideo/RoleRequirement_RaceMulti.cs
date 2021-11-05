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
                if (ModSettingsUtility_Ideo.ESCP_RaceTools_IdeologyOverrideRace())
                {
                    this.labelCached = "ESCP_IdeoRequirementRace".Translate() + ": " + "ESCP_IdeoRequirementRaceAny".Translate();
                }
                else
                {
                    this.labelCached = "ESCP_IdeoRequirementRace".Translate() + ": ";
                    foreach(ThingDef def in races)
                    {
                        this.labelCached.Concat(races[0].label + ", ");
                    }
                }
            }
            return labelCached;
        }

        public override bool Met(Pawn p, Precept_Role role)
        {
            return races.Contains(p.def) || ModSettingsUtility_Ideo.ESCP_RaceTools_IdeologyOverrideRace();
        }

        public List<ThingDef> races;

        [NoTranslate]
        private string labelCached;
    }
}

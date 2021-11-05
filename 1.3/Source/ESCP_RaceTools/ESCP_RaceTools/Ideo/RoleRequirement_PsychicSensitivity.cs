using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class RoleRequirement_PsychicSensitivity : RoleRequirement
    {
        public override string GetLabel(Precept_Role role)
        {
            if (this.labelCached == null)
            {
                this.labelCached = "ESCP_IdeoRequirementPsychic".Translate() + ": " + sensitivity*100 +"%";
            }
            return labelCached;
        }

        public override bool Met(Pawn p, Precept_Role role)
        {
            return p.GetStatValue(StatDefOf.PsychicSensitivity) >= sensitivity;
        }

        public float sensitivity;

        [NoTranslate]
        private string labelCached;
    }
}

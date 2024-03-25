using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class RoleRequirement_PsychicSensitivity : RoleRequirement
    {
        public override string GetLabel(Precept_Role role)
        {
            if (labelCached == null)
            {
                if (ESCP_RaceTools_ModSettings.IdeologyOverridePsychSens)
                {
                    labelCached = "ESCP_IdeoRequirementRace".Translate() + ": " + ESCP_RaceTools_ModSettings.IdeologyOverridePsychSensValue * 100 + "%";
                }
                else
                {
                    labelCached = "ESCP_IdeoRequirementPsychic".Translate() + ": " + sensitivity * 100 + "%";
                }

            }
            return labelCached;
        }

        public override bool Met(Pawn p, Precept_Role role)
        {
            return p.GetStatValue(StatDefOf.PsychicSensitivity) >= sensitivity 
                || (ESCP_RaceTools_ModSettings.IdeologyOverridePsychSens 
                && p.GetStatValue(StatDefOf.PsychicSensitivity) >= ESCP_RaceTools_ModSettings.IdeologyOverridePsychSensValue);
        }

        public float sensitivity;

        [NoTranslate]
        private string labelCached;
    }
}

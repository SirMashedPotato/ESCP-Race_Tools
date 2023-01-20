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
                if (ModSettingsUtility_Ideo.ESCP_RaceTools_IdeologyOverridePsychSens())
                {
                    labelCached = "ESCP_IdeoRequirementRace".Translate() + ": " + ModSettingsUtility_Ideo.ESCP_RaceTools_IdeologyOverridePsychSensValue() * 100 + "%";
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
                || (ModSettingsUtility_Ideo.ESCP_RaceTools_IdeologyOverridePsychSens() 
                && p.GetStatValue(StatDefOf.PsychicSensitivity) >= ModSettingsUtility_Ideo.ESCP_RaceTools_IdeologyOverridePsychSensValue());
        }

        public float sensitivity;

        [NoTranslate]
        private string labelCached;
    }
}

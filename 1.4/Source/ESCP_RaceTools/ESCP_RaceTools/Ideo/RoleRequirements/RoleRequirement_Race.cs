using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class RoleRequirement_Race : RoleRequirement
    {
        public override string GetLabel(Precept_Role role)
        {
            if (labelCached == null)
            {
                if (ModSettingsUtility_Ideo.ESCP_RaceTools_IdeologyOverrideRace())
                {
                    labelCached = "ESCP_IdeoRequirementRace".Translate() + ": " + "ESCP_IdeoRequirementRaceAny".Translate();
                } 
                else
                {
                    labelCached = "ESCP_IdeoRequirementRace".Translate() + ": " + race.label;
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

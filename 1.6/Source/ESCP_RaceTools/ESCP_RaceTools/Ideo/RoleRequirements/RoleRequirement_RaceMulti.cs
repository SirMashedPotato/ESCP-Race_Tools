using System.Collections.Generic;
using Verse;
using RimWorld;
using System.Text;

namespace ESCP_RaceTools
{
    class RoleRequirement_RaceMulti : RoleRequirement
    {
        public override string GetLabel(Precept_Role role)
        {
            if (labelCached == null)
            {
                if (ESCP_RaceTools_ModSettings.IdeologyOverrideRace)
                {
                    labelCached = "ESCP_IdeoRequirementRace".Translate() + ": " + "ESCP_IdeoRequirementRaceAny".Translate();
                }
                else
                {
                    if (races.Count == 1)
                    {
                        labelCached = "ESCP_IdeoRequirementRace".Translate() + ": " + races[0].label;
                    }
                    else
                    {
                        labelCached = "ESCP_IdeoRequirementRace".Translate() + ": ";
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.AppendLine(races[0].label);
                        for (int i = 1; i < races.Count; i++)
                        {
                            stringBuilder.AppendLine(", " + races[i].label);
                        }
                        labelCached += stringBuilder.ToString();
                    }
                }
            }
            return labelCached;
        }

        public override bool Met(Pawn p, Precept_Role role)
        {
            return races.Contains(p.def) || ESCP_RaceTools_ModSettings.IdeologyOverrideRace;
        }

        public List<ThingDef> races;

        [NoTranslate]
        private string labelCached;
    }
}

using Verse;
using System;
using System.Linq;
using System.Collections.Generic;
using RimWorld;

namespace ESCP_RaceTools
{
    public static class ModSettingsUtility_Tooltips
    {
        /* General stuff */

        public static string General_ApparelThoughtProtection()
        {
            string races = "";

            DefDatabase<ThingDef>.AllDefsListForReading.Where(x => ApparelProperties.Get(x) != null && ApparelProperties.Get(x).negatedThoughts != null).ToList().ForEach(action: def =>
            {
                races += "\n - " + def.label;
            });

            if (races == "")
            {
                races = "\n - None";
            }

            return races;
        }

        public static string General_HeatstrokeSwitch()
        {
            string races = "";

            DefDatabase<ThingDef>.AllDefsListForReading.Where(x => RaceProperties.Get(x) != null && RaceProperties.Get(x).heatstrokeResistant).ToList().ForEach(action: def =>
            {
                races += "\n - " + def.label;
            });

            if (races == "")
            {
                races = "\n - None";
            }

            return races;
        }

        public static string General_HypothermiaSwitch()
        {
            string races = "";

            DefDatabase<ThingDef>.AllDefsListForReading.Where(x => RaceProperties.Get(x) != null && RaceProperties.Get(x).hypothermiaResistant).ToList().ForEach(action: def =>
            {
                races += "\n - " + def.label;
            });

            if (races == "")
            {
                races = "\n - None";
            }

            return races;
        }

        public static string General_DecreasedExpectations()
        {
            string races = "";

            DefDatabase<ThingDef>.AllDefsListForReading.Where(x => RaceProperties.Get(x) != null && RaceProperties.Get(x).modifiedExpectations && RaceProperties.Get(x).expectationOffset < 0).ToList().ForEach(action: def =>
            {
                races += "\n - " + def.label + " (offset by " + RaceProperties.Get(def).expectationOffset + ")";
            });

            if (races == "")
            {
                races = "\n - None";
            }

            return races;
        }

        public static string General_IncreasedExpectations()
        {
            string races = "";

            DefDatabase<ThingDef>.AllDefsListForReading.Where(x => RaceProperties.Get(x) != null && RaceProperties.Get(x).modifiedExpectations && RaceProperties.Get(x).expectationOffset > 0).ToList().ForEach(action: def =>
            {
                races += "\n - " + def.label + " (offset by " + RaceProperties.Get(def).expectationOffset + ")";
            });

            if (races == "")
            {
                races = "\n - None";
            }

            return races;
        }

        public static string General_StuffKnowledge()
        {
            string races = "";

            DefDatabase<ThingDef>.AllDefsListForReading.Where(x => StuffKnowledge.Get(x) != null).ToList().ForEach(action: def =>
            {
                races += "\n - " + def.label;
            });

            if (races == "")
            {
                races = "\n - None";
            }

            return races;
        }

        /* Resuling output is: - [MODNAME] (x faction/s) */
        public static string General_SettlementPreference()
        {
            string factions = "";
            List<string> mods = new List<string> { };
            List<int> duplications = new List<int> { };
            int other = 0;

            DefDatabase<FactionDef>.AllDefsListForReading.Where(x => SettlementPreference.Get(x) != null).ToList().ForEach(action: def =>
            {
                if (def.modContentPack != null)
                {
                    if (!mods.Contains(def.modContentPack.Name))
                    {
                        mods.Add(def.modContentPack.Name);
                        duplications.Add(1);
                    }
                    else
                    {
                        duplications[duplications.Count - 1]++;
                    }
                }
                else
                {
                    other++;
                }
              
            });

            if (!mods.NullOrEmpty())
            {
                for(int i = 0; i < mods.Count; i++)
                {
                    factions += "\n - " + mods[i] + " (" + duplications[i] + " faction/s)";
                }
            }

            if (factions == "")
            {
                factions = "\n - None";
            }

            if(other > 0)
            {
                factions += "\n - " + "Other" + " (" + other + " faction/s)";
            }

            return factions;
        }

        public static string General_BeastMaster()
        {
            string races = "";

            DefDatabase<PawnKindDef>.AllDefsListForReading.Where(x => BeastMaster.Get(x) != null).ToList().ForEach(action: def =>
            {
                races += "\n - " + def.race.label + " " + def.label;
            });

            if (races == "")
            {
                races = "\n - None";
            }

            return races;
        }

        /* Ideo stuff */

        public static string IdeoOrigin_DeityName()
        {
            string origins = "";

            DefDatabase<MemeDef>.AllDefsListForReading.Where(x => IdeoOrginProperties.Get(x) != null && IdeoOrginProperties.Get(x).IgnoreDuplicateDeityNames).ToList().ForEach(action: def =>
            {
                origins += "\n - " + def.label;
            });

            if (origins == "")
            {
                origins = "\n - None";
            }

            return origins;
        }

        public static string IdeoRole_Race()
        {
            string roles = "";

            DefDatabase<PreceptDef>.AllDefsListForReading.Where(x => x.roleRequirements != null && x.roleRequirements.Any(y => y is RoleRequirement_Race || y is RoleRequirement_RaceMulti)).ToList().ForEach(action : def =>
            {
                roles += "\n - " + def.label;
            });

            if (roles == "")
            {
                roles = "\n - None";
            }

            return roles;
        }

        public static string IdeoRole_PsychSens()
        {
            string roles = "";

            DefDatabase<PreceptDef>.AllDefsListForReading.Where(x => x.roleRequirements != null && x.roleRequirements.Any(y => y is RoleRequirement_PsychicSensitivity)).ToList().ForEach(action: def =>
            {
                roles += "\n - " + def.label;
            });

            if (roles == "")
            {
                roles = "\n - None";
            }

            return roles;
        }
    }
}

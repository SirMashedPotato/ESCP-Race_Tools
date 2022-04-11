using Verse;
using System;
using System.Linq;
using System.Collections.Generic;
using RimWorld;

namespace ESCP_RaceTools
{
    [StaticConstructorOnStartup]
    public static class TooltipStringInit
    {

        public static string General_BackstoryOpinion;
        public static string General_ApparelThoughtProtection;
        public static string General_HeatstrokeSwitch;
        public static string General_HypothermiaSwitch;
        public static string General_DecreasedExpectations;
        public static string General_IncreasedExpectations;
        public static string General_StuffKnowledge;
        public static string General_SettlementPreference;
        public static string General_BeastMaster;

        public static string IdeoOrigin_DeityName;
        public static string IdeoOrigin_DivinesName;
        public static string IdeoRole_Race;
        public static string IdeoRole_PsychSens;
        public static string IdeoGoodwill_FactionTag;

        static TooltipStringInit()
        {
            General_BackstoryOpinion = General_BackstoryOpinion_Init();
            General_ApparelThoughtProtection = General_ApparelThoughtProtection_Init();
            General_HeatstrokeSwitch = General_HeatstrokeSwitch_Init();
            General_HypothermiaSwitch = General_HypothermiaSwitch_Init();
            General_DecreasedExpectations = General_DecreasedExpectations_Init();
            General_IncreasedExpectations = General_IncreasedExpectations_Init();
            General_StuffKnowledge = General_StuffKnowledge_Init();
            General_SettlementPreference = General_SettlementPreference_Init();
            General_BeastMaster = General_BeastMaster_Init();

            IdeoOrigin_DeityName = IdeoOrigin_DeityName_Init();
            IdeoOrigin_DivinesName = IdeoOrigin_DivinesName_Init();
            IdeoRole_Race = IdeoRole_Race_Init();
            IdeoRole_PsychSens = IdeoRole_PsychSens_Init();
            IdeoGoodwill_FactionTag = IdeoGoodwill_FactionTag_Init();
            Log.Message("[ESCP - Race Tools] - Finished generating mod settings menu tooltips. Have a good day!");
        }

        /* General stuff */

        public static string General_BackstoryOpinion_Init()
        {
            string thoughts = "";

            DefDatabase<ThoughtDef>.AllDefsListForReading.Where(x => ThoughtDefProperties.Get(x) != null && 
            (ThoughtDefProperties.Get(x).backstoryCategoryA != null || ThoughtDefProperties.Get(x).sharedBackstoryCategories != null)).ToList().ForEach(action: def =>
            {
                thoughts += "\n - " + def.stages.First().label + " (" + def.stages.First().baseOpinionOffset + ")";
            });

            if (thoughts == "")
            {
                thoughts = "\n - None";
            }

            return thoughts;
        }

        public static string General_ApparelThoughtProtection_Init()
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

        public static string General_HeatstrokeSwitch_Init()
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

        public static string General_HypothermiaSwitch_Init()
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

        public static string General_DecreasedExpectations_Init()
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

        public static string General_IncreasedExpectations_Init()
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

        public static string General_StuffKnowledge_Init()
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

        /* Resulting output is: - [MODNAME] (x faction/s) */
        public static string General_SettlementPreference_Init()
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

        public static string General_BeastMaster_Init()
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

        public static string IdeoOrigin_DeityName_Init()
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

        public static string IdeoOrigin_DivinesName_Init()
        {
            string cultures = "";

            DefDatabase<CultureDef>.AllDefsListForReading.Where(x => IdeoCultureProperties.Get(x) != null && IdeoCultureProperties.Get(x).overrideDivines).ToList().ForEach(action: def =>
            {
                cultures += "\n - " + def.label;
            });

            if (cultures == "")
            {
                cultures = "\n - None";
            }

            return cultures;
        }

        public static string IdeoRole_Race_Init()
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

        public static string IdeoRole_PsychSens_Init()
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

        public static string IdeoGoodwill_FactionTag_Init()
        {
            string offsets = "";

            DefDatabase<GoodwillSituationDef>.AllDefsListForReading.Where(x => FactionGoodwillProperties.Get(x) != null && FactionGoodwillProperties.Get(x).FactionTagA != null).ToList().ForEach(action: def =>
            {
                offsets += "\n - " + def.label + " (" + def.naturalGoodwillOffset + ")";
            });

            if (offsets == "")
            {
                offsets = "\n - None";
            }

            return offsets;
        }
    }
}

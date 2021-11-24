﻿using Verse;
using System;
using System.Linq;
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

        public static string General_SettlementPreference()
        {
            string races = "";

            DefDatabase<FactionDef>.AllDefsListForReading.Where(x => SettlementPreference.Get(x) != null).ToList().ForEach(action: def =>
            {
                races += "\n - " + def.label;
            });

            if (races == "")
            {
                races = "\n - None";
            }

            return races;
        }

        public static string General_BeastMaster()
        {
            string races = "";

            //DefDatabase<ThingDef>.AllDefsListForReading.Where(x => x.comps.Any(y => y is CompProperties_BeastMasterInit)).ToList().ForEach(action: race =>
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

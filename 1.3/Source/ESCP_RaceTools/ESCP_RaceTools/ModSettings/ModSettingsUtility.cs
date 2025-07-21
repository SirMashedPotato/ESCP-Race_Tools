﻿using Verse;

namespace ESCP_RaceTools
{
    public static class ModSettingsUtility
    {
        /* stuff knowledge */
        public static bool ESCP_RaceTools_EnableStuffKnowledge()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_EnableStuffKnowledge;
        }

        public static bool ESCP_StuffKnowledgeLogging()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_StuffKnowledgeLogging && Prefs.DevMode;
        }

        /* settlement preference */
        public static bool ESCP_EnableSettlementPreference()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_EnableSettlementPreference;
        }

        public static bool ESCP_SettlementPreferenceLogging()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_SettlementPreferenceLogging && Prefs.DevMode;
        }

        public static bool ESCP_SettlementPreferenceLoggingExtended()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_SettlementPreferenceLoggingExtended && Prefs.DevMode;
        }

        public static float ESCP_RaceTools_SettlementPreferenceIterations()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_SettlementPreferenceIterations;
        }

        /* beast master */
        public static bool ESCP_RaceTools_EnableBeastMaster()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_EnableBeastMaster;
        }

        public static bool ESCP_BeastMasterLogging()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_BeastMasterLogging && Prefs.DevMode;
        }

        /* misc */

        public static bool ESCP_RaceTools_ElderScrollsQuadrums()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_ElderScrollsQuadrums;
        }

        public static bool ESCP_RaceTools_EnableApparelThoughtProtection()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_EnableApparelThoughtProtection;
        }

        public static bool ESCP_RaceTools_EnableHeatstrokeSwitch()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_EnableHeatstrokeSwitch;
        }

        public static bool ESCP_RaceTools_EnableHypothermiaSwitch()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_EnableHypothermiaSwitch;
        }

        public static bool ESCP_RaceTools_EnableArgoStomachFoodPoisoningResist()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_EnableArgoStomachFoodPoisoningResist;
        }

        public static bool ESCP_RaceTools_EnableDecreasedExpecations()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_EnableDecreasedExpecations;
        }

        public static bool ESCP_RaceTools_EnableIncreasedExpecations()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_EnableIncreasedExpecations;
        }

        public static bool ESCP_RaceTools_EnableBackstoryOpinions()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_EnableBackstoryOpinions;
        }

        public static bool ESCP_RaceTools_EnableTraitOpinions()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_EnableTraitOpinions;
        }

        /* leather thoughts */

        //akaviri

        public static bool ESCP_RaceTools_LeatherThoughtAkaviri()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtAkaviri;
        }

        //mer

        public static bool ESCP_RaceTools_LeatherThoughtMer()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtMer;
        }

        //beastfolk

        public static bool ESCP_RaceTools_LeatherThoughtBeastfolk()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtBeastfolk;
        }

        //Goblin-ken

        public static bool ESCP_RaceTools_LeatherThoughtGoblinKen()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtGoblinKen;
        }

        //extra

        public static bool ESCP_RaceTools_OrsimerAreMer()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_OrsimerAreMer &&
                RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Orsimer", "ESCP - Orsimer");
        }
    }
}

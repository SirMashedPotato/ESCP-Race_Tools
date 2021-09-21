using Verse;

namespace ESCP_RaceTools
{
    static class ModSettingsUtility
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
        public static bool ESCP_SettlementPreference()
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

        /* beat master */
        public static bool ESCP_RaceTools_EnableBeastMaster()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_EnableBeastMaster;
        }

        public static bool ESCP_BeastMasterLogging()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_BeastMasterLogging && Prefs.DevMode;
        }
    }
}

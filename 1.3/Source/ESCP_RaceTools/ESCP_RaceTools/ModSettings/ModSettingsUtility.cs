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
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_StuffKnowledgeLogging && Prefs.DevMode;
        }
    }
}

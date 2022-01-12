using Verse;

namespace ESCP_RaceTools
{
    public static class ModSettingsUtility_Ideo
    {

        public static bool ESCP_RaceTools_IdeologyOverrideRace()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_IdeologyOverrideRace;
        }

        public static bool ESCP_RaceTools_IdeologyOverridePsychSens()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_IdeologyOverridePsychSens;
        }

        public static float ESCP_RaceTools_IdeologyOverridePsychSensValue()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_IdeologyOverridePsychSensValue;
        }

        public static bool ESCP_RaceTools_DeityNameFix()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_DeityNameFix;
        }

    }
}

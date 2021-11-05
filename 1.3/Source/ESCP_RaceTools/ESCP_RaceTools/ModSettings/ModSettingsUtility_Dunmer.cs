using Verse;

namespace ESCP_RaceTools
{
    static class ModSettingsUtility_Dunmer
    {
   
        public static bool ESCP_RaceTools_DunmerGraveWhispering()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_DunmerGraveWhispering;
        }

        public static float ESCP_RaceTools_SeancePsylinkChance()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_SeancePsylinkChance;
        }

    }
}

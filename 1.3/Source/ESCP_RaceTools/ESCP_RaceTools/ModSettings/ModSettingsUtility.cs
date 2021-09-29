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

        /* leather thoughts */

        //mer

        public static bool ESCP_RaceTools_LeatherThoughtMer()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtMer;
        }

        public static bool ESCP_RaceTools_LeatherThoughtAltmer()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtAltmer &&
                RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Altmer", "ESCP - Altmer");
        }

        public static bool ESCP_RaceTools_LeatherThoughtAylied()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtAylied &&
                RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Aylied", "ESCP - Aylied");
        }

        public static bool ESCP_RaceTools_LeatherThoughtBosmer()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtBosmer &&
                RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Bosmer", "ESCP - Bosmer");
        }

        public static bool ESCP_RaceTools_LeatherThoughtChimer()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtChimer &&
                RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Chimer", "ESCP - Chimer");
        }

        public static bool ESCP_RaceTools_LeatherThoughtDunmer()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtDunmer &&
                RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Dunmer", "ESCP - Dunmer");
        }

        public static bool ESCP_RaceTools_LeatherThoughtDwemer()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtDwemer &&
                RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Dwemer", "ESCP - Dwemer");
        }

        public static bool ESCP_RaceTools_LeatherThoughtFalmer()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtFalmer &&
                RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Falmer", "ESCP - Falmer");
        }

        public static bool ESCP_RaceTools_LeatherThoughtMaomer()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtMaomer &&
                RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Maomer", "ESCP - Maomer");
        }

        public static bool ESCP_RaceTools_LeatherThoughtOrsimer()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtOrsimer &&
                RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Orsimer", "ESCP - Orsimer");
        }

        //beastfolk

        public static bool ESCP_RaceTools_LeatherThoughtBeastfolk()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtBeastfolk;
        }

        public static bool ESCP_RaceTools_LeatherThoughtArgonian()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtArgonian &&
                RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Argonian", "ESCP - Argonian");
        }

        public static bool ESCP_RaceTools_LeatherThoughtKhajiit()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtKhajiit &&
                RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Khajiit", "ESCP - Khajiit");
        }

        public static bool ESCP_RaceTools_LeatherThoughtImga()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtImga &&
                RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Imga", "ESCP - Imga");
        }

        public static bool ESCP_RaceTools_LeatherThoughtLamia()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtLamia &&
                RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Lamia", "ESCP - Lamia");
        }

        public static bool ESCP_RaceTools_LeatherThoughtLilmothiit()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtLilmothiit &&
                RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Lilmothiit", "ESCP - Lilmothiit");
        }

        public static bool ESCP_RaceTools_LeatherThoughtNaga()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtNaga &&
                RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Naga", "ESCP - Naga");
        }


        //Goblin-ken

        public static bool ESCP_RaceTools_LeatherThoughtGoblinKen()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtGoblinKen;
        }

        public static bool ESCP_RaceTools_LeatherThoughtGoblin()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtGoblin &&
                RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Goblin", "ESCP - Goblin");
        }

        public static bool ESCP_RaceTools_LeatherThoughtRiekling()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtRiekling &&
                RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Riekling", "ESCP - Riekling");
        }

        public static bool ESCP_RaceTools_LeatherThoughtRiekr()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtRiekr &&
                RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Riekr", "ESCP - Riekr");
        }

        //extra

        public static bool ESCP_RaceTools_LeatherThoughtSload()
        {
            return LoadedModManager.GetMod<ESCP_RaceTools_Mod>().GetSettings<ESCP_RaceTools_ModSettings>().ESCP_RaceTools_LeatherThoughtSload &&
                RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Sload", "ESCP - Sload");
        }

    }
}

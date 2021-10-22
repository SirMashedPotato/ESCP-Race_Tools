using Verse;

namespace ESCP_RaceTools
{
    class ESCP_RaceTools_ModSettings : ModSettings
    {
        //settings

        /* stuff knowledge */
        public bool ESCP_RaceTools_EnableStuffKnowledge = ESCP_RaceTools_EnableStuffKnowledge_def;
        public bool ESCP_RaceTools_StuffKnowledgeLogging = ESCP_RaceTools_StuffKnowledgeLogging_def;

        /* settlement preference */
        public bool ESCP_RaceTools_EnableSettlementPreference = ESCP_RaceTools_EnableSettlementPreference_def;
        public bool ESCP_RaceTools_SettlementPreferenceLogging = ESCP_RaceTools_SettlementPreferenceLogging_def;
        public bool ESCP_RaceTools_SettlementPreferenceLoggingExtended = ESCP_SettlementPreferenceLoggingExtended_def;
        public float ESCP_RaceTools_SettlementPreferenceIterations = ESCP_RaceTools_SettlementPreferenceIterations_def;

        /* beast master */
        public bool ESCP_RaceTools_EnableBeastMaster = ESCP_RaceTools_EnableBeastMaster_def;
        public bool ESCP_RaceTools_BeastMasterLogging = ESCP_RaceTools_BeastMasterLogging_def;

        /* misc */
        public bool ESCP_RaceTools_ElderScrollsQuadrums = ESCP_RaceTools_ElderScrollsQuadrums_def;
        public bool ESCP_RaceTools_EnableApparelThoughtProtection = ESCP_RaceTools_EnableApparelThoughtProtection_def;

        /* leather thoughts */
        //mer
        public bool ESCP_RaceTools_LeatherThoughtMer = ESCP_RaceTools_LeatherThoughtMer_def;
        public bool ESCP_RaceTools_LeatherThoughtAltmer = ESCP_RaceTools_LeatherThoughtAltmer_def;
        public bool ESCP_RaceTools_LeatherThoughtAylied = ESCP_RaceTools_LeatherThoughtAylied_def;
        public bool ESCP_RaceTools_LeatherThoughtBosmer = ESCP_RaceTools_LeatherThoughtBosmer_def;
        public bool ESCP_RaceTools_LeatherThoughtChimer = ESCP_RaceTools_LeatherThoughtChimer_def;
        public bool ESCP_RaceTools_LeatherThoughtDunmer = ESCP_RaceTools_LeatherThoughtDunmer_def;
        public bool ESCP_RaceTools_LeatherThoughtDwemer = ESCP_RaceTools_LeatherThoughtDwemer_def;
        public bool ESCP_RaceTools_LeatherThoughtFalmer = ESCP_RaceTools_LeatherThoughtFalmer_def;
        public bool ESCP_RaceTools_LeatherThoughtMaomer = ESCP_RaceTools_LeatherThoughtMaomer_def;
        public bool ESCP_RaceTools_LeatherThoughtOrsimer = ESCP_RaceTools_LeatherThoughtOrsimer_def;

        //beastfolk
        public bool ESCP_RaceTools_LeatherThoughtBeastfolk = ESCP_RaceTools_LeatherThoughtBeastfolk_def;
        public bool ESCP_RaceTools_LeatherThoughtArgonian = ESCP_RaceTools_LeatherThoughtArgonian_def;
        public bool ESCP_RaceTools_LeatherThoughtKhajiit = ESCP_RaceTools_LeatherThoughtKhajiit_def;
        public bool ESCP_RaceTools_LeatherThoughtImga = ESCP_RaceTools_LeatherThoughtImga_def;
        public bool ESCP_RaceTools_LeatherThoughtLamia = ESCP_RaceTools_LeatherThoughtLamia_def;
        public bool ESCP_RaceTools_LeatherThoughtLilmothiit = ESCP_RaceTools_LeatherThoughtLilmothiit_def;
        public bool ESCP_RaceTools_LeatherThoughtNaga = ESCP_RaceTools_LeatherThoughtNaga_def;

        //Goblin-ken
        public bool ESCP_RaceTools_LeatherThoughtGoblinKen = ESCP_RaceTools_LeatherThoughtGoblinKen_def;
        public bool ESCP_RaceTools_LeatherThoughtGoblin = ESCP_RaceTools_LeatherThoughtGoblin_def;
        public bool ESCP_RaceTools_LeatherThoughtRiekling = ESCP_RaceTools_LeatherThoughtRiekling_def;
        public bool ESCP_RaceTools_LeatherThoughtRiekr = ESCP_RaceTools_LeatherThoughtRiekr_def;

        //extra
        public bool ESCP_RaceTools_LeatherThoughtSload = ESCP_RaceTools_LeatherThoughtSload_def;

        /* Dunmer */
        public bool ESCP_RaceTools_DunmerGraveWhispering = ESCP_RaceTools_DunmerGraveWhispering_def;

        //defaults

        /* stuff knowledge */
        private static readonly bool ESCP_RaceTools_EnableStuffKnowledge_def = true;
        private static readonly bool ESCP_RaceTools_StuffKnowledgeLogging_def = false;

        /* settlement preference */
        private static readonly bool ESCP_RaceTools_EnableSettlementPreference_def = true;
        private static readonly bool ESCP_RaceTools_SettlementPreferenceLogging_def = false;
        private static readonly bool ESCP_SettlementPreferenceLoggingExtended_def = false;
        private static readonly float ESCP_RaceTools_SettlementPreferenceIterations_def = 500f;

        /* beast master */
        private static readonly bool ESCP_RaceTools_EnableBeastMaster_def = true;
        private static readonly bool ESCP_RaceTools_BeastMasterLogging_def = false;

        /* misc */
        private static readonly bool ESCP_RaceTools_ElderScrollsQuadrums_def = false;
        private static readonly bool ESCP_RaceTools_EnableApparelThoughtProtection_def = true;

        /* leather thoughts */
        //mer
        private static readonly bool ESCP_RaceTools_LeatherThoughtMer_def = false;
        private static readonly bool ESCP_RaceTools_LeatherThoughtAltmer_def = true;
        private static readonly bool ESCP_RaceTools_LeatherThoughtAylied_def = true;
        private static readonly bool ESCP_RaceTools_LeatherThoughtBosmer_def = true;
        private static readonly bool ESCP_RaceTools_LeatherThoughtChimer_def = true;
        private static readonly bool ESCP_RaceTools_LeatherThoughtDunmer_def = true;
        private static readonly bool ESCP_RaceTools_LeatherThoughtDwemer_def = true;
        private static readonly bool ESCP_RaceTools_LeatherThoughtFalmer_def = true;
        private static readonly bool ESCP_RaceTools_LeatherThoughtMaomer_def = true;
        private static readonly bool ESCP_RaceTools_LeatherThoughtOrsimer_def = true;

        //beastfolk
        private static readonly bool ESCP_RaceTools_LeatherThoughtBeastfolk_def = false;
        private static readonly bool ESCP_RaceTools_LeatherThoughtArgonian_def = true;
        private static readonly bool ESCP_RaceTools_LeatherThoughtKhajiit_def = true;
        private static readonly bool ESCP_RaceTools_LeatherThoughtImga_def = true;
        private static readonly bool ESCP_RaceTools_LeatherThoughtLamia_def = true;
        private static readonly bool ESCP_RaceTools_LeatherThoughtLilmothiit_def = true;
        private static readonly bool ESCP_RaceTools_LeatherThoughtNaga_def = true;

        //Goblin-ken
        private static readonly bool ESCP_RaceTools_LeatherThoughtGoblinKen_def = false;
        private static readonly bool ESCP_RaceTools_LeatherThoughtGoblin_def = true;
        private static readonly bool ESCP_RaceTools_LeatherThoughtRiekling_def = true;
        private static readonly bool ESCP_RaceTools_LeatherThoughtRiekr_def = true;

        //extra
        private static readonly bool ESCP_RaceTools_LeatherThoughtSload_def = true;

        /* Dunmer */
        private static readonly bool ESCP_RaceTools_DunmerGraveWhispering_def = true;

        //save settings
        public override void ExposeData()
        {

            /* stuff knowledge */
            Scribe_Values.Look(ref ESCP_RaceTools_EnableStuffKnowledge, "ESCP_RaceTools_EnableStuffKnowledge", ESCP_RaceTools_EnableStuffKnowledge_def);
            Scribe_Values.Look(ref ESCP_RaceTools_StuffKnowledgeLogging, "ESCP_RaceTools_StuffKnowledgeLogging", ESCP_RaceTools_StuffKnowledgeLogging_def);
            /* settlement preference */
            Scribe_Values.Look(ref ESCP_RaceTools_EnableSettlementPreference, "ESCP_RaceTools_EnableSettlementPreference", ESCP_RaceTools_EnableSettlementPreference_def);
            Scribe_Values.Look(ref ESCP_RaceTools_SettlementPreferenceLogging, "ESCP_RaceTools_SettlementPreferenceLogging", ESCP_RaceTools_SettlementPreferenceLogging_def);
            Scribe_Values.Look(ref ESCP_RaceTools_SettlementPreferenceLoggingExtended, "ESCP_RaceTools_SettlementPreferenceLoggingExtended", ESCP_SettlementPreferenceLoggingExtended_def);
            Scribe_Values.Look(ref ESCP_RaceTools_SettlementPreferenceIterations, "ESCP_RaceTools_SettlementPreferenceIterations", ESCP_RaceTools_SettlementPreferenceIterations_def);
            /* beast master */
            Scribe_Values.Look(ref ESCP_RaceTools_EnableBeastMaster, "ESCP_RaceTools_EnableBeastMaster", ESCP_RaceTools_EnableBeastMaster_def);
            Scribe_Values.Look(ref ESCP_RaceTools_BeastMasterLogging, "ESCP_RaceTools_BeastMasterLogging", ESCP_RaceTools_BeastMasterLogging_def);

            /* misc */
            Scribe_Values.Look(ref ESCP_RaceTools_ElderScrollsQuadrums, "ESCP_RaceTools_ElderScrollsQuadrums", ESCP_RaceTools_ElderScrollsQuadrums_def);
            Scribe_Values.Look(ref ESCP_RaceTools_EnableApparelThoughtProtection, "ESCP_RaceTools_EnableApparelThoughtProtection", ESCP_RaceTools_EnableApparelThoughtProtection_def);

            /* leather thoughts */
            //mer
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtMer, "ESCP_RaceTools_LeatherThoughtMer", ESCP_RaceTools_LeatherThoughtMer_def);
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtAltmer, "ESCP_RaceTools_LeatherThoughtAltmer", ESCP_RaceTools_LeatherThoughtAltmer_def);
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtAylied, "ESCP_RaceTools_LeatherThoughtAylied", ESCP_RaceTools_LeatherThoughtAylied_def);
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtBosmer, "ESCP_RaceTools_LeatherThoughtBosmer", ESCP_RaceTools_LeatherThoughtBosmer_def);
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtChimer, "ESCP_RaceTools_LeatherThoughtChimer", ESCP_RaceTools_LeatherThoughtChimer_def);
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtDunmer, "ESCP_RaceTools_LeatherThoughtDunmer", ESCP_RaceTools_LeatherThoughtDunmer_def);
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtDwemer, "ESCP_RaceTools_LeatherThoughtDwemer", ESCP_RaceTools_LeatherThoughtDwemer_def);
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtFalmer, "ESCP_RaceTools_LeatherThoughtFalmer", ESCP_RaceTools_LeatherThoughtFalmer_def);
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtMaomer, "ESCP_RaceTools_LeatherThoughtMaomer", ESCP_RaceTools_LeatherThoughtMaomer_def);
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtOrsimer, "ESCP_RaceTools_LeatherThoughtOrsimer", ESCP_RaceTools_LeatherThoughtOrsimer_def);
            //beastfolk
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtBeastfolk, "ESCP_RaceTools_LeatherThoughtMer", ESCP_RaceTools_LeatherThoughtBeastfolk_def);
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtArgonian, "ESCP_RaceTools_LeatherThoughtArgonian", ESCP_RaceTools_LeatherThoughtArgonian_def);
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtKhajiit, "ESCP_RaceTools_LeatherThoughtKhajiit", ESCP_RaceTools_LeatherThoughtKhajiit_def);
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtImga, "ESCP_RaceTools_LeatherThoughtImga", ESCP_RaceTools_LeatherThoughtImga_def);
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtLamia, "ESCP_RaceTools_LeatherThoughtLamia", ESCP_RaceTools_LeatherThoughtLamia_def);
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtLilmothiit, "ESCP_RaceTools_LeatherThoughtLilmothiit", ESCP_RaceTools_LeatherThoughtLilmothiit_def);
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtNaga, "ESCP_RaceTools_LeatherThoughtNaga", ESCP_RaceTools_LeatherThoughtNaga_def);
            //Goblin-ken
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtGoblinKen, "ESCP_RaceTools_LeatherThoughtGoblinKen", ESCP_RaceTools_LeatherThoughtGoblinKen_def);
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtGoblin, "ESCP_RaceTools_LeatherThoughtGoblin", ESCP_RaceTools_LeatherThoughtGoblin_def);
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtRiekling, "ESCP_RaceTools_LeatherThoughtRiekling", ESCP_RaceTools_LeatherThoughtRiekling_def);
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtRiekr, "ESCP_RaceTools_LeatherThoughtRiekr", ESCP_RaceTools_LeatherThoughtRiekr_def);
            //extra
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtSload, "ESCP_RaceTools_LeatherThoughtSload", ESCP_RaceTools_LeatherThoughtSload_def);

            /* Dunmer */
            Scribe_Values.Look(ref ESCP_RaceTools_DunmerGraveWhispering, "ESCP_RaceTools_DunmerGraveWhispering", ESCP_RaceTools_DunmerGraveWhispering_def);

            base.ExposeData();
        }

        //rest settings
        public static void ResetSettings(ESCP_RaceTools_ModSettings settings)
        {
            ResetSettings_General(settings);
            ResetSettings_Leather(settings);
            ResetSettings_Dunmer(settings);
        }

        public static void ResetSettings_General(ESCP_RaceTools_ModSettings settings)
        {
            /* stuff knowledge */
            settings.ESCP_RaceTools_EnableStuffKnowledge = ESCP_RaceTools_EnableStuffKnowledge_def;
            settings.ESCP_RaceTools_StuffKnowledgeLogging = ESCP_RaceTools_StuffKnowledgeLogging_def;
            /* settlement preference */
            settings.ESCP_RaceTools_EnableSettlementPreference = ESCP_RaceTools_EnableSettlementPreference_def;
            settings.ESCP_RaceTools_SettlementPreferenceLogging = ESCP_RaceTools_SettlementPreferenceLogging_def;
            settings.ESCP_RaceTools_SettlementPreferenceLoggingExtended = ESCP_SettlementPreferenceLoggingExtended_def;
            settings.ESCP_RaceTools_SettlementPreferenceIterations = ESCP_RaceTools_SettlementPreferenceIterations_def;
            /* beast master */
            settings.ESCP_RaceTools_EnableBeastMaster = ESCP_RaceTools_EnableBeastMaster_def;
            settings.ESCP_RaceTools_BeastMasterLogging = ESCP_RaceTools_BeastMasterLogging_def;
            /* misc */
            settings.ESCP_RaceTools_ElderScrollsQuadrums = ESCP_RaceTools_ElderScrollsQuadrums_def;
            settings.ESCP_RaceTools_EnableApparelThoughtProtection = ESCP_RaceTools_EnableApparelThoughtProtection_def;
        }

        public static void ResetSettings_Leather(ESCP_RaceTools_ModSettings settings)
        {
            //mer
            settings.ESCP_RaceTools_LeatherThoughtMer = ESCP_RaceTools_LeatherThoughtMer_def;
            settings.ESCP_RaceTools_LeatherThoughtAltmer = ESCP_RaceTools_LeatherThoughtAltmer_def;
            settings.ESCP_RaceTools_LeatherThoughtAylied = ESCP_RaceTools_LeatherThoughtAylied_def;
            settings.ESCP_RaceTools_LeatherThoughtBosmer = ESCP_RaceTools_LeatherThoughtBosmer_def;
            settings.ESCP_RaceTools_LeatherThoughtChimer = ESCP_RaceTools_LeatherThoughtChimer_def;
            settings.ESCP_RaceTools_LeatherThoughtDunmer = ESCP_RaceTools_LeatherThoughtDunmer_def;
            settings.ESCP_RaceTools_LeatherThoughtDwemer = ESCP_RaceTools_LeatherThoughtDwemer_def;
            settings.ESCP_RaceTools_LeatherThoughtFalmer = ESCP_RaceTools_LeatherThoughtFalmer_def;
            settings.ESCP_RaceTools_LeatherThoughtMaomer = ESCP_RaceTools_LeatherThoughtMaomer_def;
            settings.ESCP_RaceTools_LeatherThoughtNaga = ESCP_RaceTools_LeatherThoughtNaga_def;

            //beastfolk
            settings.ESCP_RaceTools_LeatherThoughtBeastfolk = ESCP_RaceTools_LeatherThoughtBeastfolk_def;
            settings.ESCP_RaceTools_LeatherThoughtArgonian = ESCP_RaceTools_LeatherThoughtArgonian_def;
            settings.ESCP_RaceTools_LeatherThoughtKhajiit = ESCP_RaceTools_LeatherThoughtKhajiit_def;
            settings.ESCP_RaceTools_LeatherThoughtImga = ESCP_RaceTools_LeatherThoughtImga_def;
            settings.ESCP_RaceTools_LeatherThoughtLamia = ESCP_RaceTools_LeatherThoughtLamia_def;
            settings.ESCP_RaceTools_LeatherThoughtLilmothiit = ESCP_RaceTools_LeatherThoughtLilmothiit_def;
            settings.ESCP_RaceTools_LeatherThoughtNaga = ESCP_RaceTools_LeatherThoughtNaga_def;

            //Goblin-ken
            settings.ESCP_RaceTools_LeatherThoughtGoblinKen = ESCP_RaceTools_LeatherThoughtGoblinKen_def;
            settings.ESCP_RaceTools_LeatherThoughtGoblin = ESCP_RaceTools_LeatherThoughtGoblin_def;
            settings.ESCP_RaceTools_LeatherThoughtRiekling = ESCP_RaceTools_LeatherThoughtRiekling_def;
            settings.ESCP_RaceTools_LeatherThoughtRiekr = ESCP_RaceTools_LeatherThoughtRiekr_def;

            //extra
            settings.ESCP_RaceTools_LeatherThoughtSload = ESCP_RaceTools_LeatherThoughtSload_def;
        }

        public static void ResetSettings_Dunmer(ESCP_RaceTools_ModSettings settings)
        {
            settings.ESCP_RaceTools_DunmerGraveWhispering = ESCP_RaceTools_DunmerGraveWhispering_def;
        }
    }
}

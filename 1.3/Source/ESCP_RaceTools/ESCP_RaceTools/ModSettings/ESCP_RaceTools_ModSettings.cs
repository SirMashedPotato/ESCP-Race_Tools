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
        private static readonly bool ESCP_RaceTools_EnableBeastMaster_def = false;
        private static readonly bool ESCP_RaceTools_BeastMasterLogging_def = false;

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
            base.ExposeData();
        }

        //rest settings
        public static void ResetSettings(ESCP_RaceTools_ModSettings settings)
        {
            ResetSettings_General(settings);
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
        }
    }
}

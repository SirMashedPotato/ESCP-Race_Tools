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
        public bool ESCP_RaceTools_EnableHeatstrokeSwitch = ESCP_RaceTools_EnableHeatstrokeSwitch_def;
        public bool ESCP_RaceTools_EnableHypothermiaSwitch = ESCP_RaceTools_EnableHypothermiaSwitch_def;

        /* Ideology */
        public bool ESCP_RaceTools_IdeologyOverrideRace = ESCP_RaceTools_IdeologyOverrideRace_def;
        public bool ESCP_RaceTools_IdeologyOverridePsychSens = ESCP_RaceTools_IdeologyOverridePsychSens_def;
        public float ESCP_RaceTools_IdeologyOverridePsychSensValue = ESCP_RaceTools_IdeologyOverridePsychSensValue_def;
        public bool ESCP_RaceTools_DeityNameFix = ESCP_RaceTools_DeityNameFix_def;

        /* leather thoughts */
        //mer
        public bool ESCP_RaceTools_LeatherThoughtMer = ESCP_RaceTools_LeatherThoughtMer_def;

        //beastfolk
        public bool ESCP_RaceTools_LeatherThoughtBeastfolk = ESCP_RaceTools_LeatherThoughtBeastfolk_def;

        //Goblin-ken
        public bool ESCP_RaceTools_LeatherThoughtGoblinKen = ESCP_RaceTools_LeatherThoughtGoblinKen_def;

        //extra
        public bool ESCP_RaceTools_OrsimerAreMer = ESCP_RaceTools_OrsimerAreMer_def;
        public bool ESCP_RaceTools_LeatherThoughtSload = ESCP_RaceTools_LeatherThoughtSload_def;

        /* Dunmer */
        public bool ESCP_RaceTools_DunmerGraveWhispering = ESCP_RaceTools_DunmerGraveWhispering_def;
        public float ESCP_RaceTools_SeancePsylinkChance = ESCP_RaceTools_SeancePsylinkChance_def;

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
        private static readonly bool ESCP_RaceTools_EnableHeatstrokeSwitch_def = true;
        private static readonly bool ESCP_RaceTools_EnableHypothermiaSwitch_def = true;

        /* Ideology */
        private static readonly bool ESCP_RaceTools_IdeologyOverrideRace_def = false;
        private static readonly bool ESCP_RaceTools_IdeologyOverridePsychSens_def = false;
        private static readonly float ESCP_RaceTools_IdeologyOverridePsychSensValue_def = 1.2f;
        private static readonly bool ESCP_RaceTools_DeityNameFix_def = true;

        /* leather thoughts */
        //mer
        private static readonly bool ESCP_RaceTools_LeatherThoughtMer_def = true;

        //beastfolk
        private static readonly bool ESCP_RaceTools_LeatherThoughtBeastfolk_def = true;

        //Goblin-ken
        private static readonly bool ESCP_RaceTools_LeatherThoughtGoblinKen_def = true;

        //extra
        private static readonly bool ESCP_RaceTools_OrsimerAreMer_def = true;
        private static readonly bool ESCP_RaceTools_LeatherThoughtSload_def = true;

        /* Dunmer */
        private static readonly bool ESCP_RaceTools_DunmerGraveWhispering_def = true;
        private static readonly float ESCP_RaceTools_SeancePsylinkChance_def = 0.5f;

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
            Scribe_Values.Look(ref ESCP_RaceTools_EnableHeatstrokeSwitch, "ESCP_RaceTools_EnableHeatstrokeSwitch", ESCP_RaceTools_EnableHeatstrokeSwitch_def);
            Scribe_Values.Look(ref ESCP_RaceTools_EnableHypothermiaSwitch, "ESCP_RaceTools_EnableHypothermiaSwitch", ESCP_RaceTools_EnableHypothermiaSwitch_def);

            /* Ideology */
            Scribe_Values.Look(ref ESCP_RaceTools_IdeologyOverrideRace, "ESCP_RaceTools_IdeologyOverrideRace", ESCP_RaceTools_IdeologyOverrideRace_def);
            Scribe_Values.Look(ref ESCP_RaceTools_IdeologyOverridePsychSens, "ESCP_RaceTools_IdeologyOverridePsychSens", ESCP_RaceTools_IdeologyOverridePsychSens_def);
            Scribe_Values.Look(ref ESCP_RaceTools_IdeologyOverridePsychSensValue, "ESCP_RaceTools_IdeologyOverridePsychSensValue", ESCP_RaceTools_IdeologyOverridePsychSensValue_def);
            Scribe_Values.Look(ref ESCP_RaceTools_DeityNameFix, "ESCP_RaceTools_DeityNameFix", ESCP_RaceTools_DeityNameFix_def);

            /* leather thoughts */
            //mer
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtMer, "ESCP_RaceTools_LeatherThoughtMer", ESCP_RaceTools_LeatherThoughtMer_def);
            //beastfolk
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtBeastfolk, "ESCP_RaceTools_LeatherThoughtMer", ESCP_RaceTools_LeatherThoughtBeastfolk_def);
            //Goblin-ken
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtGoblinKen, "ESCP_RaceTools_LeatherThoughtGoblinKen", ESCP_RaceTools_LeatherThoughtGoblinKen_def);
            //extra
            Scribe_Values.Look(ref ESCP_RaceTools_OrsimerAreMer, "ESCP_RaceTools_OrsimerAreMer", ESCP_RaceTools_OrsimerAreMer_def);
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtSload, "ESCP_RaceTools_LeatherThoughtSload", ESCP_RaceTools_LeatherThoughtSload_def);

            /* Dunmer */
            Scribe_Values.Look(ref ESCP_RaceTools_DunmerGraveWhispering, "ESCP_RaceTools_DunmerGraveWhispering", ESCP_RaceTools_DunmerGraveWhispering_def);
            Scribe_Values.Look(ref ESCP_RaceTools_SeancePsylinkChance, "ESCP_RaceTools_SeancePsylinkChance", ESCP_RaceTools_SeancePsylinkChance_def);

            base.ExposeData();
        }

        //rest settings
        public static void ResetSettings(ESCP_RaceTools_ModSettings settings)
        {
            ResetSettings_General(settings);
            ResetSettings_Ideology(settings);
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
            settings.ESCP_RaceTools_EnableHeatstrokeSwitch = ESCP_RaceTools_EnableHeatstrokeSwitch_def;
            settings.ESCP_RaceTools_EnableHypothermiaSwitch = ESCP_RaceTools_EnableHypothermiaSwitch_def;
        }

        public static void ResetSettings_Ideology(ESCP_RaceTools_ModSettings settings)
        {
            settings.ESCP_RaceTools_IdeologyOverrideRace = ESCP_RaceTools_IdeologyOverrideRace_def;
            settings.ESCP_RaceTools_IdeologyOverridePsychSens = ESCP_RaceTools_IdeologyOverridePsychSens_def;
            settings.ESCP_RaceTools_IdeologyOverridePsychSensValue = ESCP_RaceTools_IdeologyOverridePsychSensValue_def;
            settings.ESCP_RaceTools_DeityNameFix = ESCP_RaceTools_DeityNameFix_def;
        }

        public static void ResetSettings_Leather(ESCP_RaceTools_ModSettings settings)
        {
            //mer
            settings.ESCP_RaceTools_LeatherThoughtMer = ESCP_RaceTools_LeatherThoughtMer_def;

            //beastfolk
            settings.ESCP_RaceTools_LeatherThoughtBeastfolk = ESCP_RaceTools_LeatherThoughtBeastfolk_def;

            //Goblin-ken
            settings.ESCP_RaceTools_LeatherThoughtGoblinKen = ESCP_RaceTools_LeatherThoughtGoblinKen_def;

            //extra
            settings.ESCP_RaceTools_OrsimerAreMer = ESCP_RaceTools_OrsimerAreMer_def;
            settings.ESCP_RaceTools_LeatherThoughtSload = ESCP_RaceTools_LeatherThoughtSload_def;
        }

        public static void ResetSettings_Dunmer(ESCP_RaceTools_ModSettings settings)
        {
            settings.ESCP_RaceTools_DunmerGraveWhispering = ESCP_RaceTools_DunmerGraveWhispering_def;
            settings.ESCP_RaceTools_SeancePsylinkChance = ESCP_RaceTools_SeancePsylinkChance_def;
        }
    }
}

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
        public bool ESCP_RaceTools_EnableArgoStomachFoodPoisoningResist = ESCP_RaceTools_EnableArgoStomachFoodPoisoningResist_def;
        public bool ESCP_RaceTools_EnableDecreasedExpecations = ESCP_RaceTools_EnableDecreasedExpecations_def;
        public bool ESCP_RaceTools_EnableIncreasedExpecations = ESCP_RaceTools_EnableIncreasedExpecations_def;

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

        /* Race */
        public bool ESCP_RaceTools_DunmerGraveWhispering = ESCP_RaceTools_DunmerGraveWhispering_def;
        public float ESCP_RaceTools_SeancePsylinkChance = ESCP_RaceTools_SeancePsylinkChance_def;
        public float ESCP_RaceTools_MaormerLeviathanChance = ESCP_RaceTools_MaormerLeviathanChance_def;
        public bool ESCP_RaceTools_SloadThrassianPlagueIncident = ESCP_RaceTools_SloadThrassianPlagueIncident_def;

        //Sload thralls
        public bool ESCP_RaceTools_SloadThrallDisableNeeds = ESCP_RaceTools_SloadThrallDisableNeeds_def;
        public bool ESCP_RaceTools_SloadThrallDisableMoods = ESCP_RaceTools_SloadThrallDisableMoods_def;
        public bool ESCP_RaceTools_SloadThrallIdeoCertainty = ESCP_RaceTools_SloadThrallIdeoCertainty_def;
        public bool ESCP_RaceTools_SloadThrallSkillLearning = ESCP_RaceTools_SloadThrallSkillLearning_def;
        public bool ESCP_RaceTools_SloadThrallSkillDecay = ESCP_RaceTools_SloadThrallSkillDecay_def;

        public bool ESCP_RaceTools_SloadThrallMilkable = ESCP_RaceTools_SloadThrallMilkable_def;
        public bool ESCP_RaceTools_SloadThrallShearable = ESCP_RaceTools_SloadThrallShearable_def;
        public bool ESCP_RaceTools_SloadThrallEggLaying = ESCP_RaceTools_SloadThrallEggLaying_def;
        public bool ESCP_RaceTools_SloadThrallTrainable = ESCP_RaceTools_SloadThrallTrainable_def;
        public bool ESCP_RaceTools_SloadThrallTrainableDecay = ESCP_RaceTools_SloadThrallTrainableDecay_def;
        public bool ESCP_RaceTools_SloadThrallMating = ESCP_RaceTools_SloadThrallMating_def;

        public bool ESCP_RaceTools_SloadThrallNamesArePurple = ESCP_RaceTools_SloadThrallNamesArePurple_def;

        //defaults

        /* stuff knowledge */
        private static readonly bool ESCP_RaceTools_EnableStuffKnowledge_def = true;
        private static readonly bool ESCP_RaceTools_StuffKnowledgeLogging_def = false;

        /* settlement preference */
        private static readonly bool ESCP_RaceTools_EnableSettlementPreference_def = true;
        private static readonly bool ESCP_RaceTools_SettlementPreferenceLogging_def = false;
        private static readonly bool ESCP_SettlementPreferenceLoggingExtended_def = false;
        private static readonly float ESCP_RaceTools_SettlementPreferenceIterations_def = 100f;

        /* beast master */
        private static readonly bool ESCP_RaceTools_EnableBeastMaster_def = true;
        private static readonly bool ESCP_RaceTools_BeastMasterLogging_def = false;

        /* misc */
        private static readonly bool ESCP_RaceTools_ElderScrollsQuadrums_def = false;
        private static readonly bool ESCP_RaceTools_EnableApparelThoughtProtection_def = true;
        private static readonly bool ESCP_RaceTools_EnableHeatstrokeSwitch_def = true;
        private static readonly bool ESCP_RaceTools_EnableHypothermiaSwitch_def = true;
        private static readonly bool ESCP_RaceTools_EnableArgoStomachFoodPoisoningResist_def = true;
        private static readonly bool ESCP_RaceTools_EnableDecreasedExpecations_def = true;
        private static readonly bool ESCP_RaceTools_EnableIncreasedExpecations_def = true;

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

        /* Race */
        private static readonly bool ESCP_RaceTools_DunmerGraveWhispering_def = true;
        private static readonly float ESCP_RaceTools_SeancePsylinkChance_def = 0.5f;
        private static readonly float ESCP_RaceTools_MaormerLeviathanChance_def = 0.05f;
        private static readonly bool ESCP_RaceTools_SloadThrassianPlagueIncident_def = true;

        //Sload thralls
        private static readonly bool ESCP_RaceTools_SloadThrallDisableNeeds_def = true;
        private static readonly bool ESCP_RaceTools_SloadThrallDisableMoods_def = true;
        private static readonly bool ESCP_RaceTools_SloadThrallIdeoCertainty_def = true;
        private static readonly bool ESCP_RaceTools_SloadThrallSkillLearning_def = true;
        private static readonly bool ESCP_RaceTools_SloadThrallSkillDecay_def = true;

        private static readonly bool ESCP_RaceTools_SloadThrallMilkable_def = true;
        private static readonly bool ESCP_RaceTools_SloadThrallShearable_def = true;
        private static readonly bool ESCP_RaceTools_SloadThrallEggLaying_def = true;
        private static readonly bool ESCP_RaceTools_SloadThrallTrainable_def = true;
        private static readonly bool ESCP_RaceTools_SloadThrallTrainableDecay_def = true;
        private static readonly bool ESCP_RaceTools_SloadThrallMating_def = true;

        private static readonly bool ESCP_RaceTools_SloadThrallNamesArePurple_def = true;

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
            Scribe_Values.Look(ref ESCP_RaceTools_EnableArgoStomachFoodPoisoningResist, "ESCP_RaceTools_EnableArgoStomachFoodPoisoningResist", ESCP_RaceTools_EnableArgoStomachFoodPoisoningResist_def);
            Scribe_Values.Look(ref ESCP_RaceTools_EnableDecreasedExpecations, "ESCP_RaceTools_EnableDecreasedExpecations", ESCP_RaceTools_EnableDecreasedExpecations_def);
            Scribe_Values.Look(ref ESCP_RaceTools_EnableIncreasedExpecations, "ESCP_RaceTools_EnableIncreasedExpecations", ESCP_RaceTools_EnableIncreasedExpecations_def);

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

            /* Race */
            Scribe_Values.Look(ref ESCP_RaceTools_DunmerGraveWhispering, "ESCP_RaceTools_DunmerGraveWhispering", ESCP_RaceTools_DunmerGraveWhispering_def);
            Scribe_Values.Look(ref ESCP_RaceTools_SeancePsylinkChance, "ESCP_RaceTools_SeancePsylinkChance", ESCP_RaceTools_SeancePsylinkChance_def);
            Scribe_Values.Look(ref ESCP_RaceTools_MaormerLeviathanChance, "ESCP_RaceTools_MaormerLeviathanChance", ESCP_RaceTools_MaormerLeviathanChance_def);
            Scribe_Values.Look(ref ESCP_RaceTools_SloadThrassianPlagueIncident, "ESCP_RaceTools_SloadThrassianPlagueIncident", ESCP_RaceTools_SloadThrassianPlagueIncident_def);

            //Sload thralls
            Scribe_Values.Look(ref ESCP_RaceTools_SloadThrallDisableNeeds, "ESCP_RaceTools_SloadThrallDisableNeeds", ESCP_RaceTools_SloadThrallDisableNeeds_def);
            Scribe_Values.Look(ref ESCP_RaceTools_SloadThrallDisableMoods, "ESCP_RaceTools_SloadThrallDisableMoods", ESCP_RaceTools_SloadThrallDisableMoods_def);
            Scribe_Values.Look(ref ESCP_RaceTools_SloadThrallIdeoCertainty, "ESCP_RaceTools_SloadThrallIdeoCertainty", ESCP_RaceTools_SloadThrallIdeoCertainty_def);
            Scribe_Values.Look(ref ESCP_RaceTools_SloadThrallSkillLearning, "ESCP_RaceTools_SloadThrallSkillLearning", ESCP_RaceTools_SloadThrallSkillLearning_def);
            Scribe_Values.Look(ref ESCP_RaceTools_SloadThrallSkillDecay, "ESCP_RaceTools_SloadThrallSkillDecay", ESCP_RaceTools_SloadThrallSkillDecay_def);

            Scribe_Values.Look(ref ESCP_RaceTools_SloadThrallMilkable, "ESCP_RaceTools_SloadThrallMilkable", ESCP_RaceTools_SloadThrallMilkable_def);
            Scribe_Values.Look(ref ESCP_RaceTools_SloadThrallShearable, "ESCP_RaceTools_SloadThrallShearable", ESCP_RaceTools_SloadThrallShearable_def);
            Scribe_Values.Look(ref ESCP_RaceTools_SloadThrallEggLaying, "ESCP_RaceTools_SloadThrallEggLaying", ESCP_RaceTools_SloadThrallEggLaying_def);
            Scribe_Values.Look(ref ESCP_RaceTools_SloadThrallTrainable, "ESCP_RaceTools_SloadThrallTrainable", ESCP_RaceTools_SloadThrallTrainable_def);
            Scribe_Values.Look(ref ESCP_RaceTools_SloadThrallTrainableDecay, "ESCP_RaceTools_SloadThrallTrainableDecay", ESCP_RaceTools_SloadThrallTrainableDecay_def);
            Scribe_Values.Look(ref ESCP_RaceTools_SloadThrallMating, "ESCP_RaceTools_SloadThrallMating", ESCP_RaceTools_SloadThrallMating_def);

            Scribe_Values.Look(ref ESCP_RaceTools_SloadThrallNamesArePurple, "ESCP_RaceTools_SloadThrallNamesArePurple", ESCP_RaceTools_SloadThrallNamesArePurple_def);

            base.ExposeData();
        }

        //rest settings
        public static void ResetSettings(ESCP_RaceTools_ModSettings settings)
        {
            ResetSettings_General(settings);
            ResetSettings_Ideology(settings);
            ResetSettings_Leather(settings);
            ResetSettings_Race(settings);
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
            settings.ESCP_RaceTools_EnableArgoStomachFoodPoisoningResist = ESCP_RaceTools_EnableArgoStomachFoodPoisoningResist_def;
            settings.ESCP_RaceTools_EnableDecreasedExpecations = ESCP_RaceTools_EnableDecreasedExpecations_def;
            settings.ESCP_RaceTools_EnableIncreasedExpecations = ESCP_RaceTools_EnableIncreasedExpecations_def;
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

        public static void ResetSettings_Race(ESCP_RaceTools_ModSettings settings)
        {
            settings.ESCP_RaceTools_DunmerGraveWhispering = ESCP_RaceTools_DunmerGraveWhispering_def;
            settings.ESCP_RaceTools_SeancePsylinkChance = ESCP_RaceTools_SeancePsylinkChance_def;
            settings.ESCP_RaceTools_MaormerLeviathanChance = ESCP_RaceTools_MaormerLeviathanChance_def;
            settings.ESCP_RaceTools_SloadThrassianPlagueIncident = ESCP_RaceTools_SloadThrassianPlagueIncident_def;

            //Sload thralls
            settings.ESCP_RaceTools_SloadThrallDisableNeeds = ESCP_RaceTools_SloadThrallDisableNeeds_def;
            settings.ESCP_RaceTools_SloadThrallDisableMoods = ESCP_RaceTools_SloadThrallDisableMoods_def;
            settings.ESCP_RaceTools_SloadThrallIdeoCertainty = ESCP_RaceTools_SloadThrallIdeoCertainty_def;
            settings.ESCP_RaceTools_SloadThrallSkillLearning = ESCP_RaceTools_SloadThrallSkillLearning_def;
            settings.ESCP_RaceTools_SloadThrallSkillDecay = ESCP_RaceTools_SloadThrallSkillDecay_def;

            settings.ESCP_RaceTools_SloadThrallMilkable = ESCP_RaceTools_SloadThrallMilkable_def;
            settings.ESCP_RaceTools_SloadThrallShearable = ESCP_RaceTools_SloadThrallShearable_def;
            settings.ESCP_RaceTools_SloadThrallEggLaying = ESCP_RaceTools_SloadThrallEggLaying_def;
            settings.ESCP_RaceTools_SloadThrallTrainable = ESCP_RaceTools_SloadThrallTrainable_def;
            settings.ESCP_RaceTools_SloadThrallTrainableDecay = ESCP_RaceTools_SloadThrallTrainableDecay_def;
            settings.ESCP_RaceTools_SloadThrallMating = ESCP_RaceTools_SloadThrallMating_def;

            settings.ESCP_RaceTools_SloadThrallNamesArePurple = ESCP_RaceTools_SloadThrallNamesArePurple_def;
        }
    }
}

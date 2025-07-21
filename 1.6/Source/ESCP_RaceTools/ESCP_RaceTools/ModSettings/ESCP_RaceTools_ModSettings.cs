using Verse;

namespace ESCP_RaceTools
{
    class ESCP_RaceTools_ModSettings : ModSettings
    {

        private static ESCP_RaceTools_ModSettings _instance;

        /* ========== Getters ========== */

        /* settlement preference */
        public static bool EnableSettlementPreference => _instance.ESCP_RaceTools_EnableSettlementPreference;
        public static bool SettlementPreferenceLogging => _instance.ESCP_RaceTools_SettlementPreferenceLogging;
        public static bool SettlementPreferenceLoggingExtended => _instance.ESCP_RaceTools_SettlementPreferenceLoggingExtended;
        public static float SettlementPreferenceIterations => _instance.ESCP_RaceTools_SettlementPreferenceIterations;

        /* beast master */
        public static bool EnableBeastMaster => _instance.ESCP_RaceTools_EnableBeastMaster;
        public static bool BeastMasterLogging => _instance.ESCP_RaceTools_BeastMasterLogging;

        /* misc */

        public static bool EnableHeatstrokeSwitch => _instance.ESCP_RaceTools_EnableHeatstrokeSwitch;
        public static bool EnableHypothermiaSwitch => _instance.ESCP_RaceTools_EnableHypothermiaSwitch;
        public static bool EnableDecreasedExpecations => _instance.ESCP_RaceTools_EnableDecreasedExpecations;
        public static bool EnableIncreasedExpecations => _instance.ESCP_RaceTools_EnableIncreasedExpecations;
        public static bool EnableBackstoryOpinions => _instance.ESCP_RaceTools_EnableBackstoryOpinions;
        public static bool EnableTraitOpinions => _instance.ESCP_RaceTools_EnableTraitOpinions;
        public static bool EnableRestrictedApparel => _instance.ESCP_RaceTools_EnableRestrictedApparel;

        /* Ideology */
        public static bool IdeologyOverrideRace => _instance.ESCP_RaceTools_IdeologyOverrideRace;
        public static bool IdeologyOverridePsychSens => _instance.ESCP_RaceTools_IdeologyOverridePsychSens;
        public static float IdeologyOverridePsychSensValue => _instance.ESCP_RaceTools_IdeologyOverridePsychSensValue;
        public static bool DeityNameFix => _instance.ESCP_RaceTools_DeityNameFix;
        public static bool IdeologyDivinesNames => _instance.ESCP_RaceTools_IdeologyDivinesNames;
        public static bool IdeologyFactionGoodwill => _instance.ESCP_RaceTools_IdeologyFactionGoodwill;

        /* leather thoughts */
        public static bool LeatherThoughtAkaviri => _instance.ESCP_RaceTools_LeatherThoughtAkaviri;
        public static bool LeatherThoughtMer => _instance.ESCP_RaceTools_LeatherThoughtMer;
        public static bool LeatherThoughtBeastfolk => _instance.ESCP_RaceTools_LeatherThoughtBeastfolk;
        public static bool LeatherThoughtGoblinKen => _instance.ESCP_RaceTools_LeatherThoughtGoblinKen;
        public static bool OrsimerAreMer => _instance.ESCP_RaceTools_OrsimerAreMer;

        /* Race */
        public static bool DunmerGraveWhispering => _instance.ESCP_RaceTools_DunmerGraveWhispering;
        public static float SeancePsylinkChance => _instance.ESCP_RaceTools_SeancePsylinkChance;

        /* ========== Variables ========== */

        /* settlement preference */
        public bool ESCP_RaceTools_EnableSettlementPreference = ESCP_RaceTools_EnableSettlementPreference_def;
        public bool ESCP_RaceTools_SettlementPreferenceLogging = ESCP_RaceTools_SettlementPreferenceLogging_def;
        public bool ESCP_RaceTools_SettlementPreferenceLoggingExtended = ESCP_SettlementPreferenceLoggingExtended_def;
        public float ESCP_RaceTools_SettlementPreferenceIterations = ESCP_RaceTools_SettlementPreferenceIterations_def;

        /* beast master */
        public bool ESCP_RaceTools_EnableBeastMaster = ESCP_RaceTools_EnableBeastMaster_def;
        public bool ESCP_RaceTools_BeastMasterLogging = ESCP_RaceTools_BeastMasterLogging_def;

        /* misc */
        public bool ESCP_RaceTools_EnableHeatstrokeSwitch = ESCP_RaceTools_EnableHeatstrokeSwitch_def;
        public bool ESCP_RaceTools_EnableHypothermiaSwitch = ESCP_RaceTools_EnableHypothermiaSwitch_def;
        public bool ESCP_RaceTools_EnableDecreasedExpecations = ESCP_RaceTools_EnableDecreasedExpecations_def;
        public bool ESCP_RaceTools_EnableIncreasedExpecations = ESCP_RaceTools_EnableIncreasedExpecations_def;
        public bool ESCP_RaceTools_EnableBackstoryOpinions = ESCP_RaceTools_EnableBackstoryOpinions_def;
        public bool ESCP_RaceTools_EnableTraitOpinions = ESCP_RaceTools_EnableTraitOpinions_def;
        public bool ESCP_RaceTools_EnableRestrictedApparel = ESCP_RaceTools_EnableRestrictedApparel_def;

        /* Ideology */
        public bool ESCP_RaceTools_IdeologyOverrideRace = ESCP_RaceTools_IdeologyOverrideRace_def;
        public bool ESCP_RaceTools_IdeologyOverridePsychSens = ESCP_RaceTools_IdeologyOverridePsychSens_def;
        public float ESCP_RaceTools_IdeologyOverridePsychSensValue = ESCP_RaceTools_IdeologyOverridePsychSensValue_def;
        public bool ESCP_RaceTools_DeityNameFix = ESCP_RaceTools_DeityNameFix_def;
        public bool ESCP_RaceTools_IdeologyDivinesNames = ESCP_RaceTools_IdeologyDivinesNames_def;
        public bool ESCP_RaceTools_IdeologyFactionGoodwill = ESCP_RaceTools_IdeologyFactionGoodwill_def;

        /* leather thoughts */
        public bool ESCP_RaceTools_LeatherThoughtAkaviri = ESCP_RaceTools_LeatherThoughtAkaviri_def;
        public bool ESCP_RaceTools_LeatherThoughtMer = ESCP_RaceTools_LeatherThoughtMer_def;
        public bool ESCP_RaceTools_LeatherThoughtBeastfolk = ESCP_RaceTools_LeatherThoughtBeastfolk_def;
        public bool ESCP_RaceTools_LeatherThoughtGoblinKen = ESCP_RaceTools_LeatherThoughtGoblinKen_def;
        public bool ESCP_RaceTools_OrsimerAreMer = ESCP_RaceTools_OrsimerAreMer_def;

        /* Race */
        public bool ESCP_RaceTools_DunmerGraveWhispering = ESCP_RaceTools_DunmerGraveWhispering_def;
        public float ESCP_RaceTools_SeancePsylinkChance = ESCP_RaceTools_SeancePsylinkChance_def;

        public ESCP_RaceTools_ModSettings()
        {
            _instance = this;
        }

        /* ========== Defaults ========== */

        /* settlement preference */
        private static readonly bool ESCP_RaceTools_EnableSettlementPreference_def = true;
        private static readonly bool ESCP_RaceTools_SettlementPreferenceLogging_def = false;
        private static readonly bool ESCP_SettlementPreferenceLoggingExtended_def = false;
        private static readonly float ESCP_RaceTools_SettlementPreferenceIterations_def = 100f;

        /* beast master */
        private static readonly bool ESCP_RaceTools_EnableBeastMaster_def = true;
        private static readonly bool ESCP_RaceTools_BeastMasterLogging_def = false;

        /* misc */
        private static readonly bool ESCP_RaceTools_EnableHeatstrokeSwitch_def = true;
        private static readonly bool ESCP_RaceTools_EnableHypothermiaSwitch_def = true;
        private static readonly bool ESCP_RaceTools_EnableDecreasedExpecations_def = true;
        private static readonly bool ESCP_RaceTools_EnableIncreasedExpecations_def = true;
        private static readonly bool ESCP_RaceTools_EnableBackstoryOpinions_def = true;
        private static readonly bool ESCP_RaceTools_EnableTraitOpinions_def = true;
        private static readonly bool ESCP_RaceTools_EnableRestrictedApparel_def = true;

        /* Ideology */
        private static readonly bool ESCP_RaceTools_IdeologyOverrideRace_def = false;
        private static readonly bool ESCP_RaceTools_IdeologyOverridePsychSens_def = false;
        private static readonly float ESCP_RaceTools_IdeologyOverridePsychSensValue_def = 1.2f;
        private static readonly bool ESCP_RaceTools_DeityNameFix_def = true;
        private static readonly bool ESCP_RaceTools_IdeologyDivinesNames_def = true;
        private static readonly bool ESCP_RaceTools_IdeologyFactionGoodwill_def = true;

        /* leather thoughts */
        private static readonly bool ESCP_RaceTools_LeatherThoughtAkaviri_def = true;
        private static readonly bool ESCP_RaceTools_LeatherThoughtMer_def = true;
        private static readonly bool ESCP_RaceTools_LeatherThoughtBeastfolk_def = true;
        private static readonly bool ESCP_RaceTools_LeatherThoughtGoblinKen_def = true;
        private static readonly bool ESCP_RaceTools_OrsimerAreMer_def = true;

        /* Race */
        private static readonly bool ESCP_RaceTools_DunmerGraveWhispering_def = true;
        private static readonly float ESCP_RaceTools_SeancePsylinkChance_def = 0.5f;

        /* ========== Saving ========== */
        public override void ExposeData()
        {
            /* settlement preference */
            Scribe_Values.Look(ref ESCP_RaceTools_EnableSettlementPreference, "ESCP_RaceTools_EnableSettlementPreference", ESCP_RaceTools_EnableSettlementPreference_def);
            Scribe_Values.Look(ref ESCP_RaceTools_SettlementPreferenceLogging, "ESCP_RaceTools_SettlementPreferenceLogging", ESCP_RaceTools_SettlementPreferenceLogging_def);
            Scribe_Values.Look(ref ESCP_RaceTools_SettlementPreferenceLoggingExtended, "ESCP_RaceTools_SettlementPreferenceLoggingExtended", ESCP_SettlementPreferenceLoggingExtended_def);
            Scribe_Values.Look(ref ESCP_RaceTools_SettlementPreferenceIterations, "ESCP_RaceTools_SettlementPreferenceIterations", ESCP_RaceTools_SettlementPreferenceIterations_def);
            /* beast master */
            Scribe_Values.Look(ref ESCP_RaceTools_EnableBeastMaster, "ESCP_RaceTools_EnableBeastMaster", ESCP_RaceTools_EnableBeastMaster_def);
            Scribe_Values.Look(ref ESCP_RaceTools_BeastMasterLogging, "ESCP_RaceTools_BeastMasterLogging", ESCP_RaceTools_BeastMasterLogging_def);

            /* misc */
            Scribe_Values.Look(ref ESCP_RaceTools_EnableHeatstrokeSwitch, "ESCP_RaceTools_EnableHeatstrokeSwitch", ESCP_RaceTools_EnableHeatstrokeSwitch_def);
            Scribe_Values.Look(ref ESCP_RaceTools_EnableHypothermiaSwitch, "ESCP_RaceTools_EnableHypothermiaSwitch", ESCP_RaceTools_EnableHypothermiaSwitch_def);
            Scribe_Values.Look(ref ESCP_RaceTools_EnableDecreasedExpecations, "ESCP_RaceTools_EnableDecreasedExpecations", ESCP_RaceTools_EnableDecreasedExpecations_def);
            Scribe_Values.Look(ref ESCP_RaceTools_EnableIncreasedExpecations, "ESCP_RaceTools_EnableIncreasedExpecations", ESCP_RaceTools_EnableIncreasedExpecations_def);
            Scribe_Values.Look(ref ESCP_RaceTools_EnableBackstoryOpinions, "ESCP_RaceTools_EnableBackstoryOpinions", ESCP_RaceTools_EnableBackstoryOpinions_def);
            Scribe_Values.Look(ref ESCP_RaceTools_EnableTraitOpinions, "ESCP_RaceTools_EnableTraitOpinions", ESCP_RaceTools_EnableTraitOpinions_def);
            Scribe_Values.Look(ref ESCP_RaceTools_EnableRestrictedApparel, "ESCP_RaceTools_EnableRestrictedApparel", ESCP_RaceTools_EnableRestrictedApparel_def);

            /* Ideology */
            Scribe_Values.Look(ref ESCP_RaceTools_IdeologyOverrideRace, "ESCP_RaceTools_IdeologyOverrideRace", ESCP_RaceTools_IdeologyOverrideRace_def);
            Scribe_Values.Look(ref ESCP_RaceTools_IdeologyOverridePsychSens, "ESCP_RaceTools_IdeologyOverridePsychSens", ESCP_RaceTools_IdeologyOverridePsychSens_def);
            Scribe_Values.Look(ref ESCP_RaceTools_IdeologyOverridePsychSensValue, "ESCP_RaceTools_IdeologyOverridePsychSensValue", ESCP_RaceTools_IdeologyOverridePsychSensValue_def);
            Scribe_Values.Look(ref ESCP_RaceTools_DeityNameFix, "ESCP_RaceTools_DeityNameFix", ESCP_RaceTools_DeityNameFix_def);
            Scribe_Values.Look(ref ESCP_RaceTools_IdeologyDivinesNames, "ESCP_RaceTools_IdeologyDivinesNames", ESCP_RaceTools_IdeologyDivinesNames_def);
            Scribe_Values.Look(ref ESCP_RaceTools_IdeologyFactionGoodwill, "ESCP_RaceTools_IdeologyFactionGoodwill", ESCP_RaceTools_IdeologyFactionGoodwill_def);

            /* leather thoughts */
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtAkaviri, "ESCP_RaceTools_LeatherThoughtAkaviri", ESCP_RaceTools_LeatherThoughtAkaviri_def);
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtMer, "ESCP_RaceTools_LeatherThoughtMer", ESCP_RaceTools_LeatherThoughtMer_def);
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtBeastfolk, "ESCP_RaceTools_LeatherThoughtMer", ESCP_RaceTools_LeatherThoughtBeastfolk_def);
            Scribe_Values.Look(ref ESCP_RaceTools_LeatherThoughtGoblinKen, "ESCP_RaceTools_LeatherThoughtGoblinKen", ESCP_RaceTools_LeatherThoughtGoblinKen_def);
            Scribe_Values.Look(ref ESCP_RaceTools_OrsimerAreMer, "ESCP_RaceTools_OrsimerAreMer", ESCP_RaceTools_OrsimerAreMer_def);

            /* Race */
            Scribe_Values.Look(ref ESCP_RaceTools_DunmerGraveWhispering, "ESCP_RaceTools_DunmerGraveWhispering", ESCP_RaceTools_DunmerGraveWhispering_def);
            Scribe_Values.Look(ref ESCP_RaceTools_SeancePsylinkChance, "ESCP_RaceTools_SeancePsylinkChance", ESCP_RaceTools_SeancePsylinkChance_def);

            base.ExposeData();
        }

        /* ========== Reseting ========== */
        public static void ResetSettings(ESCP_RaceTools_ModSettings settings)
        {
            ResetSettings_General(settings);
            ResetSettings_Ideology(settings);
            ResetSettings_Leather(settings);
            ResetSettings_Race(settings);
        }

        public static void ResetSettings_General(ESCP_RaceTools_ModSettings settings)
        {
            /* settlement preference */
            settings.ESCP_RaceTools_EnableSettlementPreference = ESCP_RaceTools_EnableSettlementPreference_def;
            settings.ESCP_RaceTools_SettlementPreferenceLogging = ESCP_RaceTools_SettlementPreferenceLogging_def;
            settings.ESCP_RaceTools_SettlementPreferenceLoggingExtended = ESCP_SettlementPreferenceLoggingExtended_def;
            settings.ESCP_RaceTools_SettlementPreferenceIterations = ESCP_RaceTools_SettlementPreferenceIterations_def;
            /* beast master */
            settings.ESCP_RaceTools_EnableBeastMaster = ESCP_RaceTools_EnableBeastMaster_def;
            settings.ESCP_RaceTools_BeastMasterLogging = ESCP_RaceTools_BeastMasterLogging_def;
            /* misc */
            settings.ESCP_RaceTools_EnableHeatstrokeSwitch = ESCP_RaceTools_EnableHeatstrokeSwitch_def;
            settings.ESCP_RaceTools_EnableHypothermiaSwitch = ESCP_RaceTools_EnableHypothermiaSwitch_def;
            settings.ESCP_RaceTools_EnableDecreasedExpecations = ESCP_RaceTools_EnableDecreasedExpecations_def;
            settings.ESCP_RaceTools_EnableIncreasedExpecations = ESCP_RaceTools_EnableIncreasedExpecations_def;
            settings.ESCP_RaceTools_EnableBackstoryOpinions = ESCP_RaceTools_EnableBackstoryOpinions_def;
            settings.ESCP_RaceTools_EnableTraitOpinions = ESCP_RaceTools_EnableTraitOpinions_def;
            settings.ESCP_RaceTools_EnableRestrictedApparel = ESCP_RaceTools_EnableRestrictedApparel_def;
        }

        public static void ResetSettings_Ideology(ESCP_RaceTools_ModSettings settings)
        {
            settings.ESCP_RaceTools_IdeologyOverrideRace = ESCP_RaceTools_IdeologyOverrideRace_def;
            settings.ESCP_RaceTools_IdeologyOverridePsychSens = ESCP_RaceTools_IdeologyOverridePsychSens_def;
            settings.ESCP_RaceTools_IdeologyOverridePsychSensValue = ESCP_RaceTools_IdeologyOverridePsychSensValue_def;
            settings.ESCP_RaceTools_DeityNameFix = ESCP_RaceTools_DeityNameFix_def;
            settings.ESCP_RaceTools_IdeologyDivinesNames = ESCP_RaceTools_IdeologyDivinesNames_def;
            settings.ESCP_RaceTools_IdeologyFactionGoodwill = ESCP_RaceTools_IdeologyFactionGoodwill_def;
        }

        public static void ResetSettings_Leather(ESCP_RaceTools_ModSettings settings)
        {
            settings.ESCP_RaceTools_LeatherThoughtAkaviri = ESCP_RaceTools_LeatherThoughtAkaviri_def;
            settings.ESCP_RaceTools_LeatherThoughtMer = ESCP_RaceTools_LeatherThoughtMer_def;
            settings.ESCP_RaceTools_LeatherThoughtBeastfolk = ESCP_RaceTools_LeatherThoughtBeastfolk_def;
            settings.ESCP_RaceTools_LeatherThoughtGoblinKen = ESCP_RaceTools_LeatherThoughtGoblinKen_def;
            settings.ESCP_RaceTools_OrsimerAreMer = ESCP_RaceTools_OrsimerAreMer_def;
        }

        public static void ResetSettings_Race(ESCP_RaceTools_ModSettings settings)
        {
            settings.ESCP_RaceTools_DunmerGraveWhispering = ESCP_RaceTools_DunmerGraveWhispering_def;
            settings.ESCP_RaceTools_SeancePsylinkChance = ESCP_RaceTools_SeancePsylinkChance_def;
        }
    }
}

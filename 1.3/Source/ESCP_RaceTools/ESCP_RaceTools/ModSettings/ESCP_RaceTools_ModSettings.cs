using Verse;

namespace ESCP_RaceTools
{
    class ESCP_RaceTools_ModSettings : ModSettings
    {
        //settings

        /* stuff knowledge */
        public bool ESCP_RaceTools_EnableStuffKnowledge = ESCP_RaceTools_EnableStuffKnowledge_def;
        public bool ESCP_StuffKnowledgeLogging = ESCP_StuffKnowledgeLogging_def;

        //defaults

        /* stuff knowledge */
        private static readonly bool ESCP_RaceTools_EnableStuffKnowledge_def = true;
        private static readonly bool ESCP_StuffKnowledgeLogging_def = false;

        //save settings
        public override void ExposeData()
        {

            /* stuff knowledge */
            Scribe_Values.Look(ref ESCP_RaceTools_EnableStuffKnowledge, "ESCP_RaceTools_EnableStuffKnowledge", ESCP_RaceTools_EnableStuffKnowledge_def);
            Scribe_Values.Look(ref ESCP_StuffKnowledgeLogging, "ESCP_StuffKnowledgeLogging", ESCP_StuffKnowledgeLogging_def);
            base.ExposeData();
        }

        //rest settings
        public static void ResetSettings(ESCP_RaceTools_ModSettings settings)
        {
            ResetSettings_General(settings);
        }

        public static void ResetSettings_General(ESCP_RaceTools_ModSettings settings)
        {
            settings.ESCP_RaceTools_EnableStuffKnowledge = ESCP_RaceTools_EnableStuffKnowledge_def;
            settings.ESCP_StuffKnowledgeLogging = ESCP_StuffKnowledgeLogging_def;
        }
    }
}

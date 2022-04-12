using UnityEngine;
using Verse;
using System;

namespace ESCP_RaceTools
{
    class ESCP_RaceTools_Mod : Mod
    {
        ESCP_RaceTools_ModSettings settings;
        public ESCP_RaceTools_Mod(ModContentPack contentPack) : base(contentPack)
        {
            this.settings = GetSettings<ESCP_RaceTools_ModSettings>();
        }

        public override string SettingsCategory() => "ESCP_RaceTools_ModName".Translate();

        private int page = 0;

        private static Vector2 scrollPosition = Vector2.zero;

        public override void DoSettingsWindowContents(Rect inRect)
        {

            var firstColumnWidth = (inRect.width - Listing.ColumnSpacing) * 3.5f / 5f;
            var secondColumnWidth = inRect.width - Listing.ColumnSpacing - firstColumnWidth;

            var outerRect = new Rect(inRect.x, inRect.y, firstColumnWidth, inRect.height);
            var innerRect = new Rect(0f, 0f, firstColumnWidth - 24f, inRect.height * 2);
            Widgets.BeginScrollView(outerRect, ref scrollPosition, innerRect, true);

            var listing_Standard = new Listing_Standard();
            listing_Standard.Begin(innerRect);

            //get page
            switch (page)
            {
                case 0:
                    listing_Standard = SettingsPage_General(listing_Standard);
                    break;
                case 1:
                    listing_Standard = SettingsPage_Ideology(listing_Standard);
                    break;
                case 2:
                    listing_Standard = SettingsPage_Leather(listing_Standard);
                    break;
                case 3:
                    listing_Standard = SettingsPage_Race(listing_Standard);
                    break;


                default:
                    listing_Standard = SettingsPage_General(listing_Standard);
                    break;
            }

            listing_Standard.End();
            Widgets.EndScrollView();
            base.DoSettingsWindowContents(inRect);

            //buttons pane
            outerRect.x += firstColumnWidth + Listing.ColumnSpacing;
            outerRect.width = secondColumnWidth;

            listing_Standard = new Listing_Standard();
            listing_Standard.Begin(outerRect);
            SettingsButtons(listing_Standard);
            listing_Standard.End();
        }

        private Listing_Standard SettingsButtons(Listing_Standard listing_Standard)
        {
            listing_Standard.Gap();

            Rect rectPageDefault = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectPageDefault, "ESCP_PageGeneral".Translate());
            if (Widgets.ButtonText(rectPageDefault, "ESCP_PageGeneral".Translate(), true, true, true))
            {
                page = 0;
            }
            listing_Standard.Gap();

            Rect rectPageIdeology = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectPageIdeology, "ESCP_PageIdeology".Translate());
            if (Widgets.ButtonText(rectPageIdeology, "ESCP_PageIdeology".Translate(), true, true, true))
            {
                page = 1;
            }
            listing_Standard.Gap();

            Rect rectPageLeather = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectPageLeather, "ESCP_PageLeather".Translate());
            if (Widgets.ButtonText(rectPageLeather, "ESCP_PageLeather".Translate(), true, true, true))
            {
                page = 2;
            }
            listing_Standard.Gap();

            Rect rectPageRace = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectPageRace, "ESCP_PageRace".Translate());
            if (Widgets.ButtonText(rectPageRace, "ESCP_PageRace".Translate(), true, true, true))
            {
                page = 3;
            }
            listing_Standard.Gap();

            listing_Standard.GapLine();

            //reset
            Rect rectDefault = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectDefault, "ESCP_Reset".Translate());
            if (Widgets.ButtonText(rectDefault, "ESCP_Reset".Translate(), true, true, true))
            {
                ESCP_RaceTools_ModSettings.ResetSettings(settings);
            }
            listing_Standard.Gap();
            ResetButtonForPage(listing_Standard);

            return listing_Standard;
        }

        private void ResetButtonForPage(Listing_Standard listing_Standard)
        {
            Rect rectDefault = listing_Standard.GetRect(30f);
            switch (page)
            {
                case 0:
                    listing_Standard.Gap();
                    TooltipHandler.TipRegion(rectDefault, "ESCP_PageGeneralReset".Translate());
                    if (Widgets.ButtonText(rectDefault, "ESCP_PageGeneralReset".Translate(), true, true, true))
                    {
                        ESCP_RaceTools_ModSettings.ResetSettings_General(settings);
                    }
                    break;

                case 1:
                    listing_Standard.Gap();
                    TooltipHandler.TipRegion(rectDefault, "ESCP_PageIdeologyReset".Translate());
                    if (Widgets.ButtonText(rectDefault, "ESCP_PageIdeologyReset".Translate(), true, true, true))
                    {
                        ESCP_RaceTools_ModSettings.ResetSettings_Ideology(settings);
                    }
                    break;

                case 2:
                    listing_Standard.Gap();
                    TooltipHandler.TipRegion(rectDefault, "ESCP_PageLeatherReset".Translate());
                    if (Widgets.ButtonText(rectDefault, "ESCP_PageLeatherReset".Translate(), true, true, true))
                    {
                        ESCP_RaceTools_ModSettings.ResetSettings_Leather(settings);
                    }
                    break;

                case 3:
                    listing_Standard.Gap();
                    TooltipHandler.TipRegion(rectDefault, "ESCP_PageRaceReset".Translate());
                    if (Widgets.ButtonText(rectDefault, "ESCP_PageRaceReset".Translate(), true, true, true))
                    {
                        ESCP_RaceTools_ModSettings.ResetSettings_Race(settings);
                    }
                    break;


                default:
                    break;
            }
        }

        /* specific pages */

        private Listing_Standard SettingsPage_General(Listing_Standard listing_Standard)
        {
            listing_Standard.Label("ESCP_PageGeneral".Translate());
            listing_Standard.GapLine();
            listing_Standard.Gap();

            //settings

            /* misc */
            listing_Standard.CheckboxLabeled("ESCP_RaceTools_ElderScrollsQuadrums".Translate(), ref settings.ESCP_RaceTools_ElderScrollsQuadrums, "ESCP_RaceTools_ElderScrollsQuadrumsTooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("ESCP_RaceTools_EnableBackstoryOpinions".Translate(), ref settings.ESCP_RaceTools_EnableBackstoryOpinions, "ESCP_RaceTools_EnableBackstoryOpinionsTooltip".Translate() + TooltipStringInit.General_BackstoryOpinion);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("ESCP_RaceTools_EnableTraitOpinions".Translate(), ref settings.ESCP_RaceTools_EnableTraitOpinions, "ESCP_RaceTools_EnableTraitOpinionsTooltip".Translate() + TooltipStringInit.General_TraitOpinion);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("ESCP_RaceTools_EnableApparelThoughtProtection".Translate(), ref settings.ESCP_RaceTools_EnableApparelThoughtProtection, "ESCP_RaceTools_EnableApparelThoughtProtection_Tooltip".Translate() + TooltipStringInit.General_ApparelThoughtProtection);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("ESCP_RaceTools_EnableHeatstrokeSwitch".Translate(), ref settings.ESCP_RaceTools_EnableHeatstrokeSwitch, "ESCP_RaceTools_EnableHeatstrokeSwitchTooltip".Translate() + TooltipStringInit.General_HeatstrokeSwitch);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("ESCP_RaceTools_EnableHypothermiaSwitch".Translate(), ref settings.ESCP_RaceTools_EnableHypothermiaSwitch, "ESCP_RaceTools_EnableHypothermiaSwitchTooltip".Translate() + TooltipStringInit.General_HypothermiaSwitch);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("ESCP_RaceTools_EnableDecreasedExpecations".Translate(), ref settings.ESCP_RaceTools_EnableDecreasedExpecations, "ESCP_RaceTools_EnableDecreasedExpecationsTooltip".Translate() + TooltipStringInit.General_DecreasedExpectations);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("ESCP_RaceTools_EnableIncreasedExpecations".Translate(), ref settings.ESCP_RaceTools_EnableIncreasedExpecations, "ESCP_RaceTools_EnableIncreasedExpecationsTooltip".Translate() + TooltipStringInit.General_IncreasedExpectations);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("ESCP_RaceTools_EnableArgoStomachFoodPoisoningResist".Translate(), ref settings.ESCP_RaceTools_EnableArgoStomachFoodPoisoningResist);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            /* stuff knowledge */
            listing_Standard.CheckboxLabeled("ESCP_RaceTools_EnableStuffKnowledge".Translate(), ref settings.ESCP_RaceTools_EnableStuffKnowledge, "ESCP_RaceTools_EnableStuffKnowledgeTooltip".Translate() + TooltipStringInit.General_StuffKnowledge);
            listing_Standard.Gap();

            if (Prefs.DevMode)
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_StuffKnowledgeLogging".Translate(), ref settings.ESCP_RaceTools_StuffKnowledgeLogging, "ESCP_RaceTools_StuffKnowledgeLoggingTooltip".Translate());
                listing_Standard.Gap();
            }

            listing_Standard.GapLine();
            listing_Standard.Gap();

            /* settlement preference */
            listing_Standard.CheckboxLabeled("ESCP_RaceTools_EnableSettlementPreference".Translate(), ref settings.ESCP_RaceTools_EnableSettlementPreference, "ESCP_RaceTools_EnableSettlementPreferenceTooltip".Translate() + TooltipStringInit.General_SettlementPreference);
            listing_Standard.Gap();

            listing_Standard.Label("ESCP_RaceTools_SettlementPreferenceIterations".Translate() + " (" + settings.ESCP_RaceTools_SettlementPreferenceIterations + ")", -1, "ESCP_RaceTools_SettlementPreferenceIterationsTooltip".Translate());
            settings.ESCP_RaceTools_SettlementPreferenceIterations = (float)Math.Round(listing_Standard.Slider(settings.ESCP_RaceTools_SettlementPreferenceIterations, 10, 5000) / 10) * 10;
            listing_Standard.Gap();

            if (Prefs.DevMode)
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_SettlementPreferenceLogging".Translate(), ref settings.ESCP_RaceTools_SettlementPreferenceLogging, "ESCP_RaceTools_SettlementPreferenceLoggingTooltip".Translate());
                listing_Standard.Gap();

                listing_Standard.CheckboxLabeled("ESCP_RaceTools_SettlementPreferenceLoggingExtended".Translate(), ref settings.ESCP_RaceTools_SettlementPreferenceLoggingExtended, "ESCP_RaceTools_SettlementPreferenceLoggingExtendedTooltip".Translate());
                listing_Standard.Gap();
            }

            listing_Standard.GapLine();
            listing_Standard.Gap();

            /* beast master */
            listing_Standard.CheckboxLabeled("ESCP_RaceTools_EnableBeastMaster".Translate(), ref settings.ESCP_RaceTools_EnableBeastMaster, "ESCP_RaceTools_EnableBeastMasterTooltip".Translate() + TooltipStringInit.General_BeastMaster);
            listing_Standard.Gap();

            if (Prefs.DevMode)
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_BeastMasterLogging".Translate(), ref settings.ESCP_RaceTools_BeastMasterLogging, "ESCP_RaceTools_BeastMasterLoggingTooltip".Translate());
                listing_Standard.Gap();
            }

            listing_Standard.GapLine();
            listing_Standard.Gap();

            return listing_Standard;
        }

        private Listing_Standard SettingsPage_Ideology(Listing_Standard listing_Standard)
        {
            listing_Standard.Label("ESCP_PageIdeology".Translate());
            listing_Standard.GapLine();
            listing_Standard.Gap();

            //settings

            listing_Standard.CheckboxLabeled("ESCP_RaceTools_IdeologyFactionGoodwill".Translate(), ref settings.ESCP_RaceTools_IdeologyFactionGoodwill, "ESCP_RaceTools_IdeologyFactionGoodwillTooltip".Translate() + TooltipStringInit.IdeoGoodwill_FactionTag);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("ESCP_RaceTools_DeityNameFix".Translate(), ref settings.ESCP_RaceTools_DeityNameFix, "ESCP_RaceTools_DeityNameFix_Tooltip".Translate() + TooltipStringInit.IdeoOrigin_DeityName);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("ESCP_RaceTools_IdeologyDivinesNames".Translate(), ref settings.ESCP_RaceTools_IdeologyDivinesNames, "ESCP_RaceTools_IdeologyDivinesNamesTooltip".Translate() + TooltipStringInit.IdeoOrigin_DivinesName);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            /* ideo role stuff */
            listing_Standard.CheckboxLabeled("ESCP_RaceTools_IdeologyOverrideRace".Translate(), ref settings.ESCP_RaceTools_IdeologyOverrideRace, "ESCP_RaceTools_IdeologyOverrideTooltip".Translate() + TooltipStringInit.IdeoRole_Race);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("ESCP_RaceTools_IdeologyOverridePsychSens".Translate(), ref settings.ESCP_RaceTools_IdeologyOverridePsychSens, "ESCP_RaceTools_IdeologyOverrideTooltip".Translate() + TooltipStringInit.IdeoRole_PsychSens);
            listing_Standard.Gap();

            listing_Standard.Label("ESCP_RaceTools_IdeologyOverridePsychSensValue".Translate() + " (" + settings.ESCP_RaceTools_IdeologyOverridePsychSensValue * 100 + "%)");
            settings.ESCP_RaceTools_IdeologyOverridePsychSensValue = (float)Math.Round(listing_Standard.Slider(settings.ESCP_RaceTools_IdeologyOverridePsychSensValue, 0f, 10f) * 20) / 20;
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            return listing_Standard;
        }

        private Listing_Standard SettingsPage_Leather(Listing_Standard listing_Standard)
        {
            listing_Standard.Label("ESCP_PageLeather".Translate());
            listing_Standard.GapLine();
            listing_Standard.Gap();

            //settings

            /* Mer */
            listing_Standard.CheckboxLabeled("ESCP_RaceTools_LeatherThoughtMer".Translate(), ref settings.ESCP_RaceTools_LeatherThoughtMer, "ESCP_RaceTools_LeatherThoughtMerTooltip".Translate());
            listing_Standard.Gap();

            /* Beastfolk */

            listing_Standard.CheckboxLabeled("ESCP_RaceTools_LeatherThoughtBeastfolk".Translate(), ref settings.ESCP_RaceTools_LeatherThoughtBeastfolk, "ESCP_RaceTools_LeatherThoughtBeastfolkTooltip".Translate());
            listing_Standard.Gap();

            /* Goblin-ken */

            listing_Standard.CheckboxLabeled("ESCP_RaceTools_LeatherThoughtGoblinKen".Translate(), ref settings.ESCP_RaceTools_LeatherThoughtGoblinKen, "ESCP_RaceTools_LeatherThoughtGoblinKenTooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            /* Special settings */

            if (RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Orsimer", "ESCP - Orsimer"))
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_OrsimerAreMer".Translate(), ref settings.ESCP_RaceTools_OrsimerAreMer);
                listing_Standard.Gap();
            }

            listing_Standard.GapLine();
            listing_Standard.Gap();

            /* Extra */

            return listing_Standard;
        }

        private Listing_Standard SettingsPage_Race(Listing_Standard listing_Standard)
        {
            listing_Standard.Label("ESCP_PageRace".Translate());
            listing_Standard.GapLine();
            listing_Standard.Gap();

            //settings

            /* Dunmer */
            listing_Standard.Label("ESCP_SubpageDunmer".Translate());
            listing_Standard.Gap();
            listing_Standard.CheckboxLabeled("ESCP_RaceTools_DunmerGraveWhispering".Translate(), ref settings.ESCP_RaceTools_DunmerGraveWhispering);
            listing_Standard.Gap();

            /* only if ideo and royalty are enabled */
            if (ModsConfig.RoyaltyActive && ModsConfig.IdeologyActive)
            {
                listing_Standard.Label("ESCP_RaceTools_SeancePsylinkChance".Translate() + " (" + settings.ESCP_RaceTools_SeancePsylinkChance * 100 + "%)");
                settings.ESCP_RaceTools_SeancePsylinkChance = (float)Math.Round(listing_Standard.Slider(settings.ESCP_RaceTools_SeancePsylinkChance, 0f, 1f) * 20) / 20;
                listing_Standard.Gap();
            }


            listing_Standard.GapLine();
            listing_Standard.Gap();

            /* Maormer */
            listing_Standard.Label("ESCP_SubpageMaormer".Translate());
            listing_Standard.Gap();
            listing_Standard.Label("ESCP_RaceTools_MaormerLeviathanChance".Translate() + " (" + settings.ESCP_RaceTools_MaormerLeviathanChance * 100 + "%)");
            settings.ESCP_RaceTools_MaormerLeviathanChance = (float)Math.Round(listing_Standard.Slider(settings.ESCP_RaceTools_MaormerLeviathanChance, 0f, 1f) * 20) / 20;
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            return listing_Standard;
        }
    }
}

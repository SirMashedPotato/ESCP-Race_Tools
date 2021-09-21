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

            /* stuff knowledge */
            listing_Standard.CheckboxLabeled("ESCP_RaceTools_EnableStuffKnowledge".Translate(), ref settings.ESCP_RaceTools_EnableStuffKnowledge, "ESCP_RaceTools_EnableStuffKnowledgeTooltip".Translate());
            listing_Standard.Gap();

            if (Prefs.DevMode)
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_StuffKnowledgeLogging".Translate(), ref settings.ESCP_RaceTools_StuffKnowledgeLogging, "ESCP_RaceTools_StuffKnowledgeLoggingTooltip".Translate());
                listing_Standard.Gap();
            }

            listing_Standard.GapLine();

            /* settlement preference */
            listing_Standard.CheckboxLabeled("ESCP_RaceTools_EnableSettlementPreference".Translate(), ref settings.ESCP_RaceTools_EnableSettlementPreference, "ESCP_RaceTools_EnableSettlementPreferenceTooltip".Translate());
            listing_Standard.Gap();

            if (Prefs.DevMode)
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_SettlementPreferenceLogging".Translate(), ref settings.ESCP_RaceTools_SettlementPreferenceLogging, "ESCP_RaceTools_SettlementPreferenceLoggingTooltip".Translate());
                listing_Standard.Gap();

                listing_Standard.CheckboxLabeled("ESCP_RaceTools_SettlementPreferenceLoggingExtended".Translate(), ref settings.ESCP_RaceTools_SettlementPreferenceLoggingExtended, "ESCP_RaceTools_SettlementPreferenceLoggingExtendedTooltip".Translate());
                listing_Standard.Gap();
            }

            listing_Standard.GapLine();

            /* beast master */
            listing_Standard.CheckboxLabeled("ESCP_RaceTools_EnableBeastMaster".Translate(), ref settings.ESCP_RaceTools_EnableBeastMaster, "ESCP_RaceTools_EnableBeastMasterTooltip".Translate());
            listing_Standard.Gap();

            if (Prefs.DevMode)
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_BeastMasterLogging".Translate(), ref settings.ESCP_RaceTools_BeastMasterLogging, "ESCP_RaceTools_BeastMasterLoggingTooltip".Translate());
                listing_Standard.Gap();
            }

            listing_Standard.GapLine();

            return listing_Standard;
        }
    }
}

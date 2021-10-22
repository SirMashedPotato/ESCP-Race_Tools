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
                    listing_Standard = SettingsPage_Leather(listing_Standard);
                    break;
                case 2:
                    listing_Standard = SettingsPage_Dunmer(listing_Standard);
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

            Rect rectPageLeather = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectPageLeather, "ESCP_PageLeather".Translate());
            if (Widgets.ButtonText(rectPageLeather, "ESCP_PageLeather".Translate(), true, true, true))
            {
                page = 1;
            }
            listing_Standard.Gap();

            Rect rectPageDunmer = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectPageDunmer, "ESCP_PageDunmer".Translate());
            if (Widgets.ButtonText(rectPageDunmer, "ESCP_PageDunmer".Translate(), true, true, true))
            {
                page = 2;
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
                    TooltipHandler.TipRegion(rectDefault, "ESCP_PageLeatherReset".Translate());
                    if (Widgets.ButtonText(rectDefault, "ESCP_PageLeatherReset".Translate(), true, true, true))
                    {
                        ESCP_RaceTools_ModSettings.ResetSettings_Leather(settings);
                    }
                    break;

                case 2:
                    listing_Standard.Gap();
                    TooltipHandler.TipRegion(rectDefault, "ESCP_PageDunmerReset".Translate());
                    if (Widgets.ButtonText(rectDefault, "ESCP_PageDunmerReset".Translate(), true, true, true))
                    {
                        ESCP_RaceTools_ModSettings.ResetSettings_Dunmer(settings);
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

            listing_Standard.CheckboxLabeled("ESCP_RaceTools_EnableApparelThoughtProtection".Translate(), ref settings.ESCP_RaceTools_EnableApparelThoughtProtection);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            /* stuff knowledge */
            listing_Standard.CheckboxLabeled("ESCP_RaceTools_EnableStuffKnowledge".Translate(), ref settings.ESCP_RaceTools_EnableStuffKnowledge, "ESCP_RaceTools_EnableStuffKnowledgeTooltip".Translate());
            listing_Standard.Gap();

            if (Prefs.DevMode)
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_StuffKnowledgeLogging".Translate(), ref settings.ESCP_RaceTools_StuffKnowledgeLogging, "ESCP_RaceTools_StuffKnowledgeLoggingTooltip".Translate());
                listing_Standard.Gap();
            }

            listing_Standard.GapLine();
            listing_Standard.Gap();

            /* settlement preference */
            listing_Standard.CheckboxLabeled("ESCP_RaceTools_EnableSettlementPreference".Translate(), ref settings.ESCP_RaceTools_EnableSettlementPreference, "ESCP_RaceTools_EnableSettlementPreferenceTooltip".Translate());
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
            listing_Standard.CheckboxLabeled("ESCP_RaceTools_EnableBeastMaster".Translate(), ref settings.ESCP_RaceTools_EnableBeastMaster, "ESCP_RaceTools_EnableBeastMasterTooltip".Translate());
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

        private Listing_Standard SettingsPage_Leather(Listing_Standard listing_Standard)
        {
            listing_Standard.Label("ESCP_PageLeather".Translate());
            listing_Standard.GapLine();
            listing_Standard.Gap();

            //settings

            /* Mer */
            listing_Standard.CheckboxLabeled("ESCP_RaceTools_LeatherThoughtMer".Translate(), ref settings.ESCP_RaceTools_LeatherThoughtMer, "ESCP_RaceTools_LeatherThoughtMerTooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.Gap();

            /* individual mer checks */

            if (RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Altmer", "ESCP - Altmer"))
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_LeatherThought".Translate(DefDatabase<ThingDef>.GetNamedSilentFail("ESCP_LeatherAltmer").label), ref settings.ESCP_RaceTools_LeatherThoughtAltmer);
                listing_Standard.Gap();
            }

            if (RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Aylied", "ESCP - Aylied"))
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_LeatherThought".Translate(DefDatabase<ThingDef>.GetNamedSilentFail("ESCP_LeatherAylied").label), ref settings.ESCP_RaceTools_LeatherThoughtAylied);
                listing_Standard.Gap();
            }

            if (RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Bosmer", "ESCP - Bosmer"))
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_LeatherThought".Translate(DefDatabase<ThingDef>.GetNamedSilentFail("ESCP_LeatherBosmer").label), ref settings.ESCP_RaceTools_LeatherThoughtBosmer);
                listing_Standard.Gap();
            }

            if (RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Chimer", "ESCP - Chimer"))
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_LeatherThought".Translate(DefDatabase<ThingDef>.GetNamedSilentFail("ESCP_LeatherChimer").label), ref settings.ESCP_RaceTools_LeatherThoughtChimer);
                listing_Standard.Gap();
            }

            if (RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Dunmer", "ESCP - Dunmer"))
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_LeatherThought".Translate(DefDatabase<ThingDef>.GetNamedSilentFail("ESCP_LeatherDunmer").label), ref settings.ESCP_RaceTools_LeatherThoughtDunmer);
                listing_Standard.Gap();
            }

            if (RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Dwemer", "ESCP - Dwemer"))
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_LeatherThought".Translate(DefDatabase<ThingDef>.GetNamedSilentFail("ESCP_LeatherDwemer").label), ref settings.ESCP_RaceTools_LeatherThoughtDwemer);
                listing_Standard.Gap();
            }

            if (RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Falmer", "ESCP - Falmer"))
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_LeatherThought".Translate(DefDatabase<ThingDef>.GetNamedSilentFail("ESCP_LeatherFalmer").label), ref settings.ESCP_RaceTools_LeatherThoughtFalmer);
                listing_Standard.Gap();
            }

            if (RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Maomer", "ESCP - Maomer"))
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_LeatherThought".Translate(DefDatabase<ThingDef>.GetNamedSilentFail("ESCP_LeatherMaomer").label), ref settings.ESCP_RaceTools_LeatherThoughtMaomer);
                listing_Standard.Gap();
            }

            if (RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Orsimer", "ESCP - Orsimer"))
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_LeatherThought".Translate(DefDatabase<ThingDef>.GetNamedSilentFail("ESCP_LeatherOrsimer").label), ref settings.ESCP_RaceTools_LeatherThoughtOrsimer);
                listing_Standard.Gap();
            }

            listing_Standard.GapLine();
            listing_Standard.Gap();

            /* Beastfolk */

            listing_Standard.CheckboxLabeled("ESCP_RaceTools_LeatherThoughtBeastfolk".Translate(), ref settings.ESCP_RaceTools_LeatherThoughtBeastfolk, "ESCP_RaceTools_LeatherThoughtBeastfolkTooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.Gap();

            /* individual bestfolk checks */

            if (RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Argonian", "ESCP - Argonian"))
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_LeatherThought".Translate(DefDatabase<ThingDef>.GetNamedSilentFail("ESCP_LeatherArgonian").label), ref settings.ESCP_RaceTools_LeatherThoughtArgonian);
                listing_Standard.Gap();
            }

            if (RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Khajiit", "ESCP - Khajiit"))
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_LeatherThought".Translate(DefDatabase<ThingDef>.GetNamedSilentFail("ESCP_LeatherKhajiit").label), ref settings.ESCP_RaceTools_LeatherThoughtKhajiit);
                listing_Standard.Gap();
            }

            if (RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Imga", "ESCP - Imga"))
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_LeatherThought".Translate(DefDatabase<ThingDef>.GetNamedSilentFail("ESCP_LeatherImga").label), ref settings.ESCP_RaceTools_LeatherThoughtImga);
                listing_Standard.Gap();
            }

            if (RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Lamia", "ESCP - Lamia"))
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_LeatherThought".Translate(DefDatabase<ThingDef>.GetNamedSilentFail("ESCP_LeatherLamia").label), ref settings.ESCP_RaceTools_LeatherThoughtLamia);
                listing_Standard.Gap();
            }

            if (RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Lilmothiit", "ESCP - Lilmothiit"))
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_LeatherThought".Translate(DefDatabase<ThingDef>.GetNamedSilentFail("ESCP_LeatherLilmothiit").label), ref settings.ESCP_RaceTools_LeatherThoughtLilmothiit);
                listing_Standard.Gap();
            }

            if (RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Naga", "ESCP - Naga"))
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_LeatherThought".Translate(DefDatabase<ThingDef>.GetNamedSilentFail("ESCP_LeatherNaga").label), ref settings.ESCP_RaceTools_LeatherThoughtNaga);
                listing_Standard.Gap();
            }

            listing_Standard.GapLine();
            listing_Standard.Gap();

            /* Goblin-ken */

            listing_Standard.CheckboxLabeled("ESCP_RaceTools_LeatherThoughtGoblinKen".Translate(), ref settings.ESCP_RaceTools_LeatherThoughtGoblinKen, "ESCP_RaceTools_LeatherThoughtGoblinKenTooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.Gap();

            /* individual goblin-ken checks */

            if (RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Goblin", "ESCP - Goblin"))
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_LeatherThought".Translate(DefDatabase<ThingDef>.GetNamedSilentFail("ESCP_LeatherGoblin").label), ref settings.ESCP_RaceTools_LeatherThoughtGoblin);
                listing_Standard.Gap();
            }

            if (RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Riekling", "ESCP - Riekling"))
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_LeatherThought".Translate(DefDatabase<ThingDef>.GetNamedSilentFail("ESCP_LeatherRiekling").label), ref settings.ESCP_RaceTools_LeatherThoughtRiekling);
                listing_Standard.Gap();
            }

            if (RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Riekr", "ESCP - Riekr"))
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_LeatherThought".Translate(DefDatabase<ThingDef>.GetNamedSilentFail("ESCP_LeatherRiekr").label), ref settings.ESCP_RaceTools_LeatherThoughtRiekr);
                listing_Standard.Gap();
            }

            listing_Standard.GapLine();
            listing_Standard.Gap();

            /* Extra */

            if (RaceToolsUtility.ModLoaded("SirMashedPotato.ESCP.Sload", "ESCP - Sload"))
            {
                listing_Standard.CheckboxLabeled("ESCP_RaceTools_LeatherThought".Translate(DefDatabase<ThingDef>.GetNamedSilentFail("ESCP_LeatherSload").label), ref settings.ESCP_RaceTools_LeatherThoughtSload);
                listing_Standard.Gap();
            }

            return listing_Standard;
        }

        private Listing_Standard SettingsPage_Dunmer(Listing_Standard listing_Standard)
        {
            listing_Standard.Label("ESCP_PageDunmer".Translate());
            listing_Standard.GapLine();
            listing_Standard.Gap();

            //settings

            /* misc */
            listing_Standard.CheckboxLabeled("ESCP_RaceTools_DunmerGraveWhispering".Translate(), ref settings.ESCP_RaceTools_DunmerGraveWhispering);
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();

            return listing_Standard;
        }
    }
}

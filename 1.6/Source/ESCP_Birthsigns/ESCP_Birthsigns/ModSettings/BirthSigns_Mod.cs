using UnityEngine;
using Verse;
using System.Collections.Generic;
using System.Linq;
using System;
using RimWorld;

namespace ESCP_Birthsigns
{
    public class BirthSigns_Mod : Mod
    {
        BirthSigns_ModSettings settings;

        public BirthSigns_Mod(ModContentPack contentPack) : base(contentPack)
        {
            this.settings = GetSettings<BirthSigns_ModSettings>();
        }

        public override string SettingsCategory() => "ESCP_BirthsignsFramework_ModName".Translate();

        private static Vector2 scrollPosition = Vector2.zero;

        public override void DoSettingsWindowContents(Rect inRect)
        {

            Rect outerRect = new Rect(inRect.x, inRect.y, inRect.width, inRect.height);
            Rect innerRect = new Rect(0f, 0f, inRect.width - 30, inRect.height * 2);
            Widgets.BeginScrollView(outerRect, ref scrollPosition, innerRect, true);

            var listing_Standard = new Listing_Standard();
            listing_Standard.Begin(innerRect);

            listing_Standard.Gap();
            bool flag = OnStartup.defs.NullOrEmpty();
            if (listing_Standard.ButtonTextLabeled("ESCP_BirthSigns_ActiveSet".Translate(), flag ? "None" : settings.ESCP_BirthSigns_CurrentSetDef.label))
            {
                if (!flag)
                {
                    List<FloatMenuOption> list = GetSetOptions().ToList();
                    Find.WindowStack.Add(new FloatMenu(list));
                }
            }

            listing_Standard.GapLine();
            listing_Standard.Gap();

            listing_Standard.Label("ESCP_BirthSigns_ChanceHasSign".Translate() + " (" + settings.ESCP_BirthSigns_ChanceHasSign * 100 + "%)");
            settings.ESCP_BirthSigns_ChanceHasSign = (float)Math.Round(listing_Standard.Slider(settings.ESCP_BirthSigns_ChanceHasSign, 0f, 1f) * 20) / 20;

            listing_Standard.CheckboxLabeled("ESCP_BirthSigns_DisableEntirely".Translate(), ref settings.ESCP_BirthSigns_DisableEntirely);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("ESCP_BirthSigns_DisableCustomQuadrumNames".Translate(), ref settings.ESCP_BirthSigns_DisableCustomQuadrumNames, "ESCP_BirthSigns_DisableCustomQuadrumNames_Tooltip".Translate());
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("ESCP_BirthSigns_AllowDisabledRaces".Translate(), ref settings.ESCP_BirthSigns_AllowDisabledRaces,
                "ESCP_BirthSigns_AllowDisabledRacesAndXenos_Tooltip".Translate(OnStartup.DisabledRaces, OnStartup.DisabledXenotypes));
            listing_Standard.Gap();

            listing_Standard.GapLine();
            if (!flag)
            {
                listing_Standard.Label("ESCP_Birthsigns_ActiveDetails_A".Translate(settings.ESCP_BirthSigns_CurrentSetDef.label + " (" + settings.ESCP_BirthSigns_CurrentSetDef.modContentPack.Name + ")"));
                listing_Standard.Label(settings.ESCP_BirthSigns_CurrentSetDef.description);
                listing_Standard.GapLine();
                BirthsignSetDetails_StandardSigns(listing_Standard);
                listing_Standard.GapLine();
                BirthsignSetDetails_AdditionalSigns(listing_Standard);
                listing_Standard.GapLine();
                listing_Standard.Label("ESCP_Birthsigns_ActiveDetails_E".Translate(settings.ESCP_BirthSigns_CurrentSetDef.hasBirthsign_DefaultChance.ToStringPercent()));
                listing_Standard.GapLine();
                if (settings.ESCP_BirthSigns_CurrentSetDef.QuadrumNameReplacerValid())
                {
                    BirthsignSetDetails_QuadrumNameReplacers(listing_Standard);
                    listing_Standard.GapLine();
                }
            }

            listing_Standard.End();
            Widgets.EndScrollView();
            base.DoSettingsWindowContents(inRect);
        }

        public IEnumerable<FloatMenuOption> GetSetOptions()
        {
            foreach (BirthsignSetDef bdef in OnStartup.defs)
            {
                yield return new FloatMenuOption(
                    bdef.label,
                    delegate ()
                    {
                        settings.ESCP_BirthSigns_CurrentSetDef = bdef;
                        settings.ESCP_BirthSigns_ChanceHasSign = bdef.hasBirthsign_DefaultChance;
                    });
            }
        }
        /// <summary>
        /// Functions to fill out the birthsign set details
        /// </summary>
        public static void BirthsignSetDetails_StandardSigns(Listing_Standard listing_Standard)
        {
            listing_Standard.Label("ESCP_Birthsigns_ActiveDetails_B".Translate());

            for (int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    HediffDef hd = BirthSigns_ModSettings.CurrentSetDef.birthsignHediffs[i][j];
                    listing_Standard.Label(new TaggedString(" - " + hd.label), -1f, hd.description);
                }
            }
        }

        public static void BirthsignSetDetails_AdditionalSigns(Listing_Standard listing_Standard)
        {
            listing_Standard.Label("ESCP_Birthsigns_ActiveDetails_C".Translate());
            string signs = "";
            bool flag = false;
            foreach(HediffDef hd in BirthSigns_ModSettings.CurrentSetDef.additionalSigns)
            {
                listing_Standard.Label(new TaggedString(" - " + hd.label), -1f, hd.description);
                flag = true;
            }

            if (!flag)
            {
                listing_Standard.Label(signs += " - none");
            }
            else
            {
                listing_Standard.Label("ESCP_Birthsigns_ActiveDetails_D".Translate(BirthSigns_ModSettings.CurrentSetDef.additionalSignsChance.ToStringPercent()));
            }
        }

        public static void BirthsignSetDetails_QuadrumNameReplacers(Listing_Standard listing_Standard)
        {
            listing_Standard.Label("ESCP_Birthsigns_ActiveDetails_F".Translate());
            BirthsignSetDef setDef = BirthSigns_ModSettings.CurrentSetDef;
            for (int i = 0; i <= 3; i++)
            {
                listing_Standard.Label(" - " + setDef.overridenQuadrumNames[i] + " (" + setDef.overridenQuadrumNamesShort[i] + ")");
            }
        }
    }
}

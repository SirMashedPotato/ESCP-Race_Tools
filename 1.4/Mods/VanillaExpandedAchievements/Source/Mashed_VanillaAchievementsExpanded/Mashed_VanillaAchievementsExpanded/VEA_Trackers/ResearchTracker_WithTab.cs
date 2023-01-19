using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Verse;
using RimWorld;
using AchievementsExpanded;

namespace Mashed_VanillaAchievementsExpanded
{
    public class ResearchTracker_WithTab : ResearchTracker
    {

        /* Notes:
         * Checks if all research on a tab is completed.
         * Can limit to a certain tech level, haven't actually tested but should work.
         * Should not use with specific defs, kind of defeats the purpose.
         * Doesn't check coreModsOnly, there is no point.
         */

        //Don't include this, it breaks the tracker, leaving this as a reminder
        //public override string Key => "ResearchTracker__WithTab";

        protected override string[] DebugText => new string[] { $"Tech: {tech}", $"Project: {def?.defName ?? "None"}", $"CoreOnly: {coreModsOnly}", $"researchTabDef: {researchTabDef}" };

        public ResearchTracker_WithTab()
        {

        }

        public ResearchTracker_WithTab(ResearchTracker_WithTab reference) : base(reference)
        {
            researchTabDef = reference.researchTabDef;
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Defs.Look(ref researchTabDef, "researchTabDef");
        }

        public override bool Trigger(ResearchProjectDef proj)
        {
            if (def is null || def == proj)
            {
                if (researchTabDef != null)
                {
                    var researchProjs = (Dictionary<ResearchProjectDef, float>)AccessTools.Field(typeof(ResearchManager), "progress").GetValue(Current.Game.researchManager);

                    foreach (var research in researchProjs.Where(r => r.Key.tab == researchTabDef))
                    {
                        if (tech is null || research.Key.techLevel == tech.Value)
                        {
                            if (research.Value < research.Key.baseCost /*&& coreModsOnly && research.Key.modContentPack.IsCoreMod*/)
                                return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        public override bool UnlockOnStartup
        {
            get
            {
                if (def is null && researchTabDef != null)
                {
                    foreach (ResearchProjectDef research in DefDatabase<ResearchProjectDef>.AllDefsListForReading)
                    {
                        if (research.tab == researchTabDef && Find.ResearchManager.GetProgress(research) < 1)
                        {
                            if (tech is null || research.techLevel == tech)
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
                else if (def != null && researchTabDef is null)
                {
                    return Find.ResearchManager.GetProgress(def) >= 1;
                }
                return false;
            }
        }

        public ResearchTabDef researchTabDef;
    }
}

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
    public class ResearchTracker_FactionRequirement : ResearchTracker
    {

        /* Notes:
         * Checks if all research on a tab is completed.
         * Can limit to a certain tech level, haven't actually tested but should work.
         * Should not use with specific defs, kind of defeats the purpose.
         * Doesn't check coreModsOnly, there is no point.
         */

        //Don't include this, it breaks the tracker, leaving this as a reminder
        //public override string Key => "ResearchTracker__WithTab";

        //protected override string[] DebugText => new string[] { $"Tech: {tech}", $"Project: {def?.defName ?? "None"}", $"CoreOnly: {coreModsOnly}"};

        public ResearchTracker_FactionRequirement()
        {
            
        }

        public ResearchTracker_FactionRequirement(ResearchTracker_FactionRequirement reference) : base(reference)
        {
            factionsList = reference.factionsList;
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Collections.Look(ref factionsList, "factionsList", LookMode.Def);
        }

        public override bool Trigger(ResearchProjectDef proj)
        {
            if (def == proj && factionsList.Contains(Find.FactionManager.OfPlayer.def))
            {

                return true;
            }
            return false;
        }

        public override bool UnlockOnStartup
        {
            get
            {
                if(def != null)
                {
                    return Find.ResearchManager.GetProgress(def) >= 1 && factionsList.Contains(Find.FactionManager.OfPlayer.def);
                }
                return false;
            }
        }

        public List<FactionDef> factionsList;
    }
}

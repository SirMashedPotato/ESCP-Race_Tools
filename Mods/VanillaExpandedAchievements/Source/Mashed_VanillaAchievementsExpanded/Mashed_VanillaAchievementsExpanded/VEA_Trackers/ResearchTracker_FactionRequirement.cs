using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Verse;
using RimWorld;
using AchievementsExpanded;
/* Stupid
namespace Mashed_VanillaAchievementsExpanded
{
    public class ResearchTracker_FactionRequirement : ResearchTracker
    {

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
*/
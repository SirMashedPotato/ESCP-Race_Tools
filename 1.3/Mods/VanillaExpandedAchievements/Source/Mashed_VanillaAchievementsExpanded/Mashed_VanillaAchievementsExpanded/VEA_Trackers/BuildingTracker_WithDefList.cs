using System;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;
using System.Collections.Generic;
using AchievementsExpanded;

namespace Mashed_VanillaAchievementsExpanded
{
    class BuildingTracker_WithDefList : BuildingTracker
    {
        public BuildingTracker_WithDefList()
        {

        }

        public BuildingTracker_WithDefList(BuildingTracker_WithDefList reference) : base(reference)
        {
            defList = reference.defList;
        }


        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Collections.Look(ref defList, "defList", LookMode.Def);
        }


        public override bool Trigger(Building building)
        {
            //base.Trigger(building);   //causes any building (including frames) to count for this tracker
            if (building.Faction == Faction.OfPlayer && (defList.NullOrEmpty() || defList.Contains(building.def)) && (madeFrom is null || madeFrom == building.Stuff))
            {

                if (!registeredBuildings.Add(building.GetUniqueLoadID()))
                {
                    return false;
                }
                triggeredCount++;
            }
            return triggeredCount >= count;
        }

        public List<ThingDef> defList;
    }
}

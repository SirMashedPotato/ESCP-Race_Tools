using System;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using Verse;
using AchievementsExpanded;

namespace Mashed_VanillaAchievementsExpanded
{
    class FactionDefeatTracker : SettlementDefeatTracker
    {
        public FactionDefeatTracker()
        {

        }

        public FactionDefeatTracker(FactionDefeatTracker reference) : base(reference)
        {
        }

        public override bool Trigger(Settlement settlement)
        {
            //base.Trigger(settlement);
            if (def is null || def == settlement.Faction.def)
            {
                
                if (Find.WorldObjects.SettlementBases.Where(x=>x.Faction == settlement.Faction).Count() - 1 <= 0)   //ensures it removes the settlement that was just destroyed from the count
                {
                    triggeredCount++;
                }
                
            }
            return triggeredCount >= count;
        }
    }
}

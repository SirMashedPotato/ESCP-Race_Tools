using System;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;
using AchievementsExpanded;
using System.Collections.Generic;

namespace Mashed_VanillaAchievementsExpanded
{
    /* effectively exactly the same, just checks from lists instead of singular defs */
    class KillTracker_WithList : KillTracker
    {
        public KillTracker_WithList()
        {

        }

        public KillTracker_WithList(KillTracker_WithList reference) : base(reference)
        {
            kindDefList = reference.kindDefList;
            raceDefList = reference.raceDefList;
        }


        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Collections.Look(ref kindDefList, "kindDefList", LookMode.Def);
            Scribe_Collections.Look(ref raceDefList, "RaceDefList", LookMode.Def);
        }

        public override bool Trigger(Pawn pawn, DamageInfo? dinfo)
        {
            //base.Trigger(pawn, dinfo);
            if (killedThings.Contains(pawn.GetUniqueLoadID()))
                return false;
            else
                killedThings.Add(pawn.GetUniqueLoadID());
            bool instigator = instigatorFactionDefs.NullOrEmpty() || (dinfo?.Instigator?.Faction?.def != null && instigatorFactionDefs.Contains(dinfo.Value.Instigator.Faction.def));
            bool kind = kindDef is null || kindDefList.Contains(pawn.kindDef);
            bool race = raceDef is null || raceDefList.Contains(pawn.def);
            bool faction = factionDefs.NullOrEmpty() || (pawn.Faction != null && factionDefs.Contains(pawn.Faction.def));
            return kind && race && faction && instigator && (count <= 1 || ++triggeredCount >= count);
        }

        public List<PawnKindDef> kindDefList;
        public List<ThingDef> raceDefList;
    }
}

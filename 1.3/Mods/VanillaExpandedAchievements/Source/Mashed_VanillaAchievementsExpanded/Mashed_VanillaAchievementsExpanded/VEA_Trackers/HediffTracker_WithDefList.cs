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

    /* Notes:
          * Checks if crafted thing is in defList, pretty simple edit.
          * No point giving it a specific def, that isn't checked.
          * Needs to be given a list, otherwise it will probably break.
          */

    //Don't include this, it breaks the tracker, leaving this as a reminder
    //public override string Key => "ItemCraftTracker_WithThingCategory";

    class HediffTracker_WithDefList : HediffTracker
    {
        public HediffTracker_WithDefList()
        {

        }

        public HediffTracker_WithDefList(HediffTracker_WithDefList reference) : base(reference)
        {
            defList = reference.defList;
        }


        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Collections.Look(ref defList, "defList", LookMode.Def);
        }

        public override bool Trigger(Hediff hediff)
        {
            //base.Trigger(hediff);

            if ((defList.NullOrEmpty() || defList.Contains(hediff.def)))
            {
                if (hediff?.pawn != null && hediff.pawn.Faction == Faction.OfPlayerSilentFail && (def is null || def == hediff.def))
                {
                    triggeredCount++;
                }
            }

            return triggeredCount >= count;
        }

        public List<HediffDef> defList;
    }
}

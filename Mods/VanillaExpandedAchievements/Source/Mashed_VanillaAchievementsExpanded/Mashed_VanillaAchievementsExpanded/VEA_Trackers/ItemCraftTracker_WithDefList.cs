using System;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;
using System.Collections.Generic;
using AchievementsExpanded;

namespace Mashed_VanillaAchievementsExpanded
{
    public class ItemCraftTracker_WithDefList : ItemCraftTracker
    {
        /* Notes:
         * Checks if crafted thing is in defList, pretty simple edit.
         * No point giving it a specific def, that isn't checked.
         * Needs to be given a list, otherwise it will probably break.
         */

        //Don't include this, it breaks the tracker, leaving this as a reminder
        //public override string Key => "ItemCraftTracker_WithThingCategory";

        public ItemCraftTracker_WithDefList()
        {

        }

        public ItemCraftTracker_WithDefList(ItemCraftTracker_WithDefList reference) : base(reference)
        {
            defList = reference.defList;
        }


        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Collections.Look(ref defList, "defList", LookMode.Def);
        }


        public override bool Trigger(Thing thing)
        {
            //base.Trigger(thing);
            if ((defList.NullOrEmpty() || defList.Contains(thing.def)) && (madeFrom is null || madeFrom == thing.Stuff))
            {
                if (quality is null || (thing.TryGetQuality(out var qc) && qc >= quality))
                {
                    triggeredCount++;
                }
            }
            return triggeredCount >= count;
        }

        public List<ThingDef> defList;
    }
}

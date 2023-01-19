using System;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;
using AchievementsExpanded;

namespace Mashed_VanillaAchievementsExpanded
{
    public class ItemCraftTracker_WithThingCategory : ItemCraftTracker
    {
        /* Notes:
         * ItemCraftTracker doesn't track stacks very well, appears to be limited to 4 check, then just stops.
         * For some reason only the first and third item crafted gets past the thingCategory check.
         * Best to not use this for things that are crafted in stacks, such as elixirs which are crafted in a stack of 5 or 25
         * Could use it for craft x times, but you would need to double the triggeredCount.
         */

        //Don't include this, it breaks the tracker, leaving this as a reminder
        //public override string Key => "ItemCraftTracker_WithThingCategory";

        protected override string[] DebugText => new string[] { $"Def: {def?.defName ?? "None"}",
                                                                $"MadeFrom: {madeFrom?.defName ?? "Any"}",
                                                                $"Quality: {quality}",
                                                                $"Count: {count}",
                                                                $"ThingCategory: {thingCategory}",
                                                                $"Current: {triggeredCount}" };
        public ItemCraftTracker_WithThingCategory()
        {

        }

        public ItemCraftTracker_WithThingCategory(ItemCraftTracker_WithThingCategory reference) : base(reference)
        {
            thingCategory = reference.thingCategory;
        }


        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Defs.Look(ref thingCategory, "thingCategory");
        }


        public override bool Trigger(Thing thing)
        {
            if ((def is null || thing.def == def) && (madeFrom is null || madeFrom == thing.Stuff))
            {
                if (quality is null || (thing.TryGetQuality(out var qc) && qc >= quality))
                {
                    if (thing.def.thingCategories.Contains(thingCategory))
                    {
                        triggeredCount++;
                    }
                }
            }
            return triggeredCount >= count;
        }

        public ThingCategoryDef thingCategory;
    }
}

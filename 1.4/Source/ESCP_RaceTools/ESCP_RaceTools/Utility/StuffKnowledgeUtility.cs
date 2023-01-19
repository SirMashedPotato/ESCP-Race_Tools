using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld;
using System.Reflection.Emit;
using System.Linq;

namespace ESCP_RaceTools
{
    public static class StuffKnowledgeUtility
    {
        /* For qulity patch */
        public static bool MadeOfStuff(Thing t, List<string> stuffList)
        {
            return t != null && t.Stuff != null && stuffList.Contains(t.Stuff.ToString());
        }

        public static bool MadeOfThing(Thing t, List<string> stuffList)
        {
            if (t.def.costList != null)
            {
                foreach (ThingDefCountClass ing in t.def.costList)
                {
                    if (stuffList.Contains(ing.thingDef.defName))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool RightSkill(RecipeDef recipe, List<SkillDef> skillList)
        {
            return skillList != null && skillList.Contains(recipe.workSkill);
        }

        public static bool RequiredTrait(Pawn p, TraitDef t, bool nullIsTrue = true)
        {
            return (t == null && nullIsTrue) || (p.story.traits != null && p.story.traits.HasTrait(t));
        }

        public static bool RequiredHediff(Pawn p, HediffDef h, bool nullIsTrue = true)
        {
            return (h == null && nullIsTrue) || (p.health.hediffSet.GetFirstHediffOfDef(h) != null);
        }

        public static bool RequiredBackstory(Pawn p, string b, bool nullIsTrue = true)
        {
            return (b == null && nullIsTrue)
                || (p.story.GetBackstory(BackstorySlot.Childhood) != null && p.story.GetBackstory(BackstorySlot.Childhood).identifier.ToString() == b)
                || (p.story.GetBackstory(BackstorySlot.Adulthood) != null && p.story.GetBackstory(BackstorySlot.Adulthood).identifier.ToString() == b);
        }

        public static bool OnlyOneCheck(Pawn p, TraitDef t, HediffDef h, string b)
        {
            return ((RequiredTrait(p, t, false) || RequiredHediff(p, h, false) || RequiredBackstory(p, b, false))
                || (RequiredTrait(p, t) && RequiredHediff(p, h) && RequiredBackstory(p, b)));
        }

        public static bool ChanceIncrease(float chance)
        {
            return Rand.Chance(chance);
        }

        public static QualityCategory CheckQualityIncrease(Pawn worker, QualityCategory initial, Thing thing, RecipeDef recipe)
        {
            var modExt = StuffKnowledge.Get(worker.def);
            if (initial != QualityCategory.Legendary && modExt != null)
            {
                foreach (var stuffKnowledge in modExt.stuffKnowledgeList)
                {
                    if ((stuffKnowledge.allOrNothing && RequiredTrait(worker, stuffKnowledge.requiredTrait) && RequiredHediff(worker, stuffKnowledge.requiredHediff) && RequiredBackstory(worker, stuffKnowledge.requiredBackstory)) ||
                        (!stuffKnowledge.allOrNothing && OnlyOneCheck(worker, stuffKnowledge.requiredTrait, stuffKnowledge.requiredHediff, stuffKnowledge.requiredBackstory)))
                    {
                        if (RightSkill(recipe, stuffKnowledge.skillList) && (MadeOfStuff(thing, stuffKnowledge.stuffList) || (stuffKnowledge.notJustStuff && MadeOfThing(thing, stuffKnowledge.stuffList))) && ChanceIncrease(stuffKnowledge.chance))
                        {
                            if (ModSettingsUtility.ESCP_StuffKnowledgeLogging()) Log.Message("Initial quality of  " + thing + " = " + initial + ", improved quality = " + (initial + 1)); ;
                            Messages.Message("ESCP_StuffKnowledgeNotification".Translate(worker, thing), thing, MessageTypeDefOf.PositiveEvent, true);
                            return initial + 1;
                        }
                    }
                }
            }
            return initial;
        }
    }
}

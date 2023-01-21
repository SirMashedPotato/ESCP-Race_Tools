using System.Collections.Generic;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    public static class StuffKnowledgeUtility
    {
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

        public static bool RequiredHediff(Pawn p, HediffDef h)
        {
            return h == null || p.health.hediffSet.GetFirstHediffOfDef(h) != null;
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
                foreach (Knowledge stuffKnowledge in modExt.stuffKnowledgeList)
                {
                    if (RequiredHediff(worker, stuffKnowledge.requiredHediff))
                    {
                        if (RightSkill(recipe, stuffKnowledge.skillList) && (MadeOfStuff(thing, stuffKnowledge.stuffList) || (stuffKnowledge.notJustStuff && MadeOfThing(thing, stuffKnowledge.stuffList))) && ChanceIncrease(stuffKnowledge.chance))
                        {
                            if (ESCP_RaceTools_ModSettings.StuffKnowledgeLogging) Log.Message("Initial quality of  " + thing + " = " + initial + ", improved quality = " + (initial + 1)); ;
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

using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    public static class StuffKnowledgeUtility
    {
        public static void Finalise(Pawn worker, QualityCategory initial, Thing thing, RecipeDef recipe)
        {
            if (ESCP_RaceTools_ModSettings.StuffKnowledgeLogging)
            {
                Log.Message("Initial quality of  " + thing + " = " + initial + ", improved quality = " + (initial + 1));
            }
            Messages.Message("ESCP_StuffKnowledgeNotification".Translate(worker, thing), thing, MessageTypeDefOf.PositiveEvent, true);
           
        }

        public static QualityCategory CheckQualityIncrease(Pawn worker, QualityCategory initial, Thing thing, RecipeDef recipe)
        {
            if (initial != QualityCategory.Legendary && !worker.health.hediffSet.hediffs.NullOrEmpty())
            {
                if (thing.Stuff != null)
                {
                    StuffKnowledge props = StuffKnowledge.Get(thing.Stuff);
                    if (props != null && props.requiredHediffDef != null)
                    {
                        if (worker.health.hediffSet.HasHediff(props.requiredHediffDef))
                        {
                            Finalise(worker, initial, thing, recipe);
                            return initial + 1;
                        }
                    }
                }

                if (!thing.def.costList.NullOrEmpty())
                {
                    foreach (ThingDefCountClass ingredient in thing.def.costList)
                    {
                        StuffKnowledge props = StuffKnowledge.Get(ingredient.thingDef);
                        if (props != null && props.requiredHediffDef != null)
                        {
                            if (worker.health.hediffSet.HasHediff(props.requiredHediffDef))
                            {
                                Finalise(worker, initial, thing, recipe);
                                return initial + 1;
                            }
                        }
                    }
                }
            }
            return initial;
        }
    }
}

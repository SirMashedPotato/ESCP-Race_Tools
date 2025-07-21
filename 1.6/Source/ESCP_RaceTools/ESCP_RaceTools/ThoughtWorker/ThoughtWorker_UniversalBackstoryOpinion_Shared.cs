using RimWorld;
using Verse;

namespace ESCP_RaceTools
{
    class ThoughtWorker_UniversalBackstoryOpinion_Shared : ThoughtWorker
    {
        protected override ThoughtState CurrentSocialStateInternal(Pawn pawn, Pawn other)
        {
            if (ESCP_RaceTools_ModSettings.EnableBackstoryOpinions)
            {
                if (pawn.story.Adulthood == null || other.story.Adulthood == null)
                {
                    return false;
                }
                var props = ThoughtDefProperties.Get(def);
                if (props != null && props.sharedBackstoryCategories != null)
                {
                    BackstoryDef a = pawn.story.Adulthood;
                    BackstoryDef b = other.story.Adulthood;
                    foreach (string str in props.sharedBackstoryCategories)
                    {
                        if (a.spawnCategories.Contains(str) && b.spawnCategories.Contains(str))
                        {
                            return ThoughtState.ActiveAtStage(0);
                        }
                    }
                }
            }
            return false;
        }
    }
}

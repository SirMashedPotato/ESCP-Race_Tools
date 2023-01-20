using RimWorld;
using Verse;

namespace ESCP_RaceTools
{
    class ThoughtWorker_UniversalBackstoryOpinion : ThoughtWorker
    {
        protected override ThoughtState CurrentSocialStateInternal(Pawn pawn, Pawn other)
        {
            if (!pawn.RaceProps.Humanlike)
            {
                return false;
            }
            if (ModSettingsUtility.ESCP_RaceTools_EnableBackstoryOpinions())
            {
                if (pawn.story.Adulthood == null || other.story.Adulthood == null)
                {
                    return false;
                }
                var props = ThoughtDefProperties.Get(def);
                if (props != null && props.backstoryCategoryA != null && props.backstoryCategoryB != null)
                {
                    BackstoryDef a = pawn.story.Adulthood;
                    BackstoryDef b = other.story.Adulthood;

                    if ((a.spawnCategories.Contains(props.backstoryCategoryA) && b.spawnCategories.Contains(props.backstoryCategoryB)) || 
                        (a.spawnCategories.Contains(props.backstoryCategoryB) && b.spawnCategories.Contains(props.backstoryCategoryA)))
                    {
                        return ThoughtState.ActiveAtStage(0);
                    }
                }
            }
            return false;
        }
    }
}

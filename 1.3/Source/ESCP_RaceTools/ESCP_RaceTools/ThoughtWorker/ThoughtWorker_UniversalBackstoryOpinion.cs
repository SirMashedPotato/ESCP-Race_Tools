using RimWorld;
using Verse;
using System.Collections.Generic;
using System.Linq;

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
                if (pawn.story.adulthood == null || other.story.adulthood == null)
                {
                    return false;
                }
                var props = ThoughtDefProperties.Get(this.def);
                if (props != null && props.backstoryCategoryA != null && props.backstoryCategoryB != null)
                {
                    Backstory a = pawn.story.adulthood;
                    Backstory b = other.story.adulthood;

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

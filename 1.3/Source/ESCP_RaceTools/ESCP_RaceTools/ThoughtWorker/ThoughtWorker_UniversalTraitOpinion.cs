using RimWorld;
using Verse;
using System.Collections.Generic;
using System.Linq;

namespace ESCP_RaceTools
{
    class ThoughtWorker_UniversalTraitOpinion : ThoughtWorker
    {
        protected override ThoughtState CurrentSocialStateInternal(Pawn pawn, Pawn other)
        {
            if (!pawn.RaceProps.Humanlike)
            {
                return false;
            }
            if (ModSettingsUtility.ESCP_RaceTools_EnableTraitOpinions())
            {
                if (pawn.story.traits == null || other.story.traits == null)
                {
                    return false;
                }
                var props = ThoughtDefProperties.Get(this.def);
                if (props != null && props.traitA != null && props.traitB != null)
                {
                    if ((pawn.story.traits.DegreeOfTrait(props.traitA) >= 0 && other.story.traits.DegreeOfTrait(props.traitB) >= 0) ||
                        (pawn.story.traits.DegreeOfTrait(props.traitB) >= 0 && other.story.traits.DegreeOfTrait(props.traitA) >= 0))
                    {
                        return ThoughtState.ActiveAtStage(0);
                    }
                }
            }
            return false;
        }
    }
}

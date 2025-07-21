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

                    if ((pawn.story.traits.HasTrait(props.traitA) && other.story.traits.HasTrait(props.traitB)) ||
                        (pawn.story.traits.HasTrait(props.traitB) && other.story.traits.HasTrait(props.traitA)))
                    {
                        if (props.useSpectrum)
                        {
                            if ((pawn.story.traits.DegreeOfTrait(props.traitA) == props.traitSpectrumA && other.story.traits.DegreeOfTrait(props.traitB) == props.traitSpectrumB) ||
                            (pawn.story.traits.DegreeOfTrait(props.traitB) == props.traitSpectrumB && other.story.traits.DegreeOfTrait(props.traitA) == props.traitSpectrumA))
                            {
                                return ThoughtState.ActiveAtStage(0);
                            }
                        }
                        else
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

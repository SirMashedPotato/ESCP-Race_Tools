using System;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class Verb_CastAbilityTouch_SloadThrallCreate : Verb_CastAbilityTouch
    {
        public override bool ValidateTarget(LocalTargetInfo target, bool showMessages = true)
        {
            return base.ValidateTarget(target, showMessages) && IsValidCorpse(target.Thing);
        }

        public bool IsValidCorpse(Thing t)
        {
            if (t is Corpse c && c.InnerPawn.RaceProps.IsFlesh && c.GetRotStage() == RotStage.Fresh/* && c.InnerPawn.RaceProps.Humanlike*/)
            {
                var props = RaceProperties.Get(c.InnerPawn.def);
                if(props != null && props.sloadThrallImmune)
                {
                    return false;
                }
                return true;
            }
            
            return false;
        }

        public override bool IsUsableOn(Thing target)
        {
            return base.IsUsableOn(target) && IsValidCorpse(target);
        }
    }
}

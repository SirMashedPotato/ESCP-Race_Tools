using RimWorld;
using Verse;

namespace ESCP_Birthsigns_Abilities
{
    public class Verb_CastAbility_OnInsectoid : Verb_CastAbility
    {
        public override bool IsApplicableTo(LocalTargetInfo target, bool showMessages = false)
        {
            return target.Thing != null && target.Thing is Pawn p && p.RaceProps.Insect;
        }
    }
}

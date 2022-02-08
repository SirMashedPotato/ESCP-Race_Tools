using RimWorld;
using Verse;

namespace ESCP_RaceTools
{
    class ThoughtWorker_SloadOpinionThought : ThoughtWorker_Precept_Social
    {
        protected override ThoughtState ShouldHaveThought(Pawn p, Pawn otherPawn)
        {
            return otherPawn.def.ToString() == "ESCP_SloadRace";
        }
    }
}

using RimWorld;
using Verse;

namespace ESCP_RaceTools
{
    class ThoughtWorker_SloadThought : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            return p.def.ToString() == "ESCP_SloadRace";
        }
    }
}

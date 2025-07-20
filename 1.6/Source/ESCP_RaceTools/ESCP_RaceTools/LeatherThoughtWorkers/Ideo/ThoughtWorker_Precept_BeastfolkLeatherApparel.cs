using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class ThoughtWorker_Precept_BeastfolkLeatherApparel : ThoughtWorker_Precept
	{
		protected override ThoughtState ShouldHaveThought(Pawn p)
		{
			return ThoughtWorker_BeastfolkLeatherApparel.CurrentThoughtState(p);
		}
	}
}

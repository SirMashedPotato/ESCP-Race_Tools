using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
	class ThoughtWorker_Precept_GoblinKenLeatherApparel : ThoughtWorker_Precept
	{
		protected override ThoughtState ShouldHaveThought(Pawn p)
		{
			return ThoughtWorker_GoblinKenLeatherApparel.CurrentThoughtState(p);
		}
	}
}

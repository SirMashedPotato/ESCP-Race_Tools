using System;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class ThoughtWorker_Precept_SloadLeatherApparel : ThoughtWorker_Precept
	{
		protected override ThoughtState ShouldHaveThought(Pawn p)
		{
			return ThoughtWorker_SloadLeatherApparel.CurrentThoughtState(p);
		}
	}
}

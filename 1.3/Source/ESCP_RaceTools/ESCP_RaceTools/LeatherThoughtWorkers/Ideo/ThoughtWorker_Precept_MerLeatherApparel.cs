using System;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
	public class ThoughtWorker_Precept_MerLeatherApparel : ThoughtWorker_Precept
	{
		protected override ThoughtState ShouldHaveThought(Pawn p)
		{
			return ThoughtWorker_MerLeatherApparel.CurrentThoughtState(p);
		}
	}
}

using System;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class GoodwillSituationWorker_AltmerCompatibility : GoodwillSituationWorker
	{
		public override string GetPostProcessedLabel(Faction other)
		{
			if (this.Applies(Faction.OfPlayer, other))
			{
				return "MemeGoodwillImpact_Player".Translate(base.GetPostProcessedLabel(other));
			}
			return "MemeGoodwillImpact_Other".Translate(base.GetPostProcessedLabel(other));
		}

		public override int GetNaturalGoodwillOffset(Faction other)
		{
			if (!this.Applies(other))
			{
				return 0;
			}
			return this.def.naturalGoodwillOffset;
		}

		private bool Applies(Faction other)
		{
			return this.Applies(Faction.OfPlayer, other) || this.Applies(other, Faction.OfPlayer);
		}

		private bool Applies(Faction a, Faction b)
		{
			var propsA = FactionProperties.Get(a.def);
			var propsB = FactionProperties.Get(b.def);
			if (propsA == null || propsB == null)
			{
				return false;
			}
			return propsA.isAltmerFaction && propsB.isAltmerFaction;
		}
	}
}

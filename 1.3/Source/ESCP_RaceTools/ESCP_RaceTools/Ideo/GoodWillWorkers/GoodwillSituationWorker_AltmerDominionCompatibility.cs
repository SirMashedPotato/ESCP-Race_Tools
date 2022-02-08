using System;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
	class GoodwillSituationWorker_AltmerDominionCompatibility : GoodwillSituationWorker
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
            if (a.def.ToString() == "ESCP_AltmerDominion")
            {
				var propsB = FactionProperties.Get(b.def);
				return propsB == null || !propsB.isAltmerFaction;
			} 
			else if (b.def.ToString() == "ESCP_AltmerDominion")
            {
				var propsA = FactionProperties.Get(a.def);
				return propsA == null || !propsA.isAltmerFaction;
			}

			return false;
		}
	}
}

using System;
using Verse;
using RimWorld;
using System.Linq;

namespace ESCP_RaceTools
{
	class GoodwillSituationWorker_Sload : GoodwillSituationWorker
	{
		public override string GetPostProcessedLabel(Faction other)
		{
			if (this.Applies(Faction.OfPlayer, other))
			{
				return "MemeGoodwillImpact_Other".Translate(base.GetPostProcessedLabel(other));
			}
			return "MemeGoodwillImpact_Player".Translate(base.GetPostProcessedLabel(other));
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
		//check if Faction A dislikes faction B
		private bool Applies(Faction a, Faction b)
		{
			var props = IdeoProperties.Get(this.def);
			var propsB = FactionProperties.Get(b.def);

			return props != null && a.ideos.PrimaryIdeo != null && !a.ideos.PrimaryIdeo.PreceptsListForReading.NullOrEmpty() 
				&& a.ideos.PrimaryIdeo.PreceptsListForReading.Where(x => x.def.defName == props.preceptDef).Any() && propsB != null && propsB.isSloadFaction;

		}
	}
}

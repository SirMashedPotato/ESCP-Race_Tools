using System;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
	class GoodWillWorker_UniversalFactionTagCompatibility : GoodwillSituationWorker
	{
		public override string GetPostProcessedLabel(Faction other)
		{
			return base.GetPostProcessedLabel(other);
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
            if (!ModSettingsUtility_Ideo.ESCP_RaceTools_IdeologyFactionGoodwill())
            {
				return false;
            }
			var tagProps = FactionGoodwillProperties.Get(this.def);
			if (tagProps == null || tagProps.FactionTagA == null || tagProps.FactionTagB == null)
			{
				return false;
			}
			var propsA = FactionProperties.Get(a.def);
			var propsB = FactionProperties.Get(b.def);
			if (propsA == null || propsA.factionTags == null || propsB == null || propsB.factionTags == null)
			{
				return false;
			}
			return propsA.factionTags.Contains(tagProps.FactionTagA) && propsB.factionTags.Contains(tagProps.FactionTagB);
		}
	}
}

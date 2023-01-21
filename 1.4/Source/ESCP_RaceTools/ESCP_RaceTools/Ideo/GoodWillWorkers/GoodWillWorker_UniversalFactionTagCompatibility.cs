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
			if (!Applies(other))
			{
				return 0;
			}
			return def.naturalGoodwillOffset;
		}

		private bool Applies(Faction other)
		{
			return Applies(Faction.OfPlayer, other) || Applies(other, Faction.OfPlayer);
		}

		private bool Applies(Faction a, Faction b)
		{
            if (!ESCP_RaceTools_ModSettings.IdeologyFactionGoodwill)
            {
				return false;
            }
			var tagProps = FactionGoodwillProperties.Get(def);
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

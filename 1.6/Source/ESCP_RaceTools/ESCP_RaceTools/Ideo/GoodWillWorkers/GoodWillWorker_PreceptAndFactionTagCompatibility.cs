using RimWorld;
using Verse;

namespace ESCP_RaceTools
{
    public class GoodWillWorker_PreceptAndFactionTagCompatibility : GoodwillSituationWorker
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
			FactionGoodwillProperties tagProps = FactionGoodwillProperties.Get(def);
			if (tagProps == null || tagProps.FactionTagA == null || tagProps.FactionTagB == null)
			{
				return false;
			}
			FactionProperties propsA = FactionProperties.Get(a.def);
			if (propsA == null || propsA.factionTags.NullOrEmpty())
			{
				return false;
			}
			if (propsA.factionTags.Contains(tagProps.FactionTagA))
			{
				if (b.ideos.PrimaryIdeo.PreceptsListForReading.Find(x => x.def == tagProps.preceptDef) != null)
				{
					return true;
				}
			}
			return false;
		}
	}
}

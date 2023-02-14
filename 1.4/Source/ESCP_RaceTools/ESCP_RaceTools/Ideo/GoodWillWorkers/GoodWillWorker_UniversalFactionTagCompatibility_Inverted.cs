using RimWorld;
using Verse;

namespace ESCP_RaceTools
{
	/// <summary>
	/// Roughly the same, but checks if Tag A is present, and Tag B isn't
	/// </summary>
	class GoodWillWorker_UniversalFactionTagCompatibility_Inverted : GoodwillSituationWorker
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
			if (propsA == null || propsA.factionTags.NullOrEmpty())
			{
				return false;
			}
            if (propsA.factionTags.Contains(tagProps.FactionTagA))
            {
				if (propsB == null || propsB.factionTags.NullOrEmpty() || !propsB.factionTags.Contains(tagProps.FactionTagB))
                {
					return true;
                }
            }
			return false;
		}
	}
}

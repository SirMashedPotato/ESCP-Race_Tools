using RimWorld;
using Verse;
using System.Collections.Generic;

//Big thanks to Razza for letting me use MorrowRim Leather Thoughts as a base

namespace ESCP_RaceTools
{
	public class ThoughtWorker_GoblinKenLeatherApparel : ThoughtWorker
	{
		public static List<string> leatherList = new List<string>()
		{
			"ESCP_LeatherGoblin", "ESCP_LeatherRiekling", "ESCP_LeatherRiekr"
		};

		public static ThoughtState CurrentThoughtState(Pawn p)
		{
			//settings check
			if (!ModSettingsUtility.ESCP_RaceTools_LeatherThoughtGoblinKen())
			{
				return ThoughtState.Inactive;
			}

			string text = null;
			int num = 0;
			List<Apparel> wornApparel = p.apparel.WornApparel;
			for (int i = 0; i < wornApparel.Count; i++)
			{
				if (leatherList.Contains(wornApparel[i].Stuff.defName))
				{
					if (text == null)
					{
						text = wornApparel[i].def.label;
					}
					num++;
				}
			}
			if (num == 0)
			{
				return ThoughtState.Inactive;
			}
			if (num >= 5)
			{
				return ThoughtState.ActiveAtStage(4, text);
			}
			return ThoughtState.ActiveAtStage(num - 1, text);
		}

		protected override ThoughtState CurrentStateInternal(Pawn p)
		{
			return ThoughtWorker_GoblinKenLeatherApparel.CurrentThoughtState(p);
		}
	}
}

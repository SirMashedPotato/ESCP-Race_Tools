﻿using RimWorld;
using Verse;
using System.Collections.Generic;

//Big thanks to Razza for letting me use MorrowRim Leather Thoughts as a base

namespace ESCP_RaceTools
{
    class ThoughtWorker_AkaviriLeatherApparel : ThoughtWorker
	{

		public static ThoughtState CurrentThoughtState(Pawn p)
		{
			//settings check
			if (!ModSettingsUtility.ESCP_RaceTools_LeatherThoughtAkaviri())
			{
				return ThoughtState.Inactive;
			}

			string text = null;
			int num = 0;
			List<Apparel> wornApparel = p.apparel.WornApparel;
			for (int i = 0; i < wornApparel.Count; i++)
			{
				if (wornApparel[i].Stuff != null && LeatherListInit.LeatherList_Akaviri.Contains(wornApparel[i].Stuff))
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
			return ThoughtWorker_AkaviriLeatherApparel.CurrentThoughtState(p);
		}
	}
}

using System;
using System.Collections.Generic;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    public static class ESCP_AbilityUtility
    {
		public static bool ValidateMustBeFactionless(Pawn targetPawn, bool showMessages)
		{
			if (targetPawn.Faction != null)
			{
				if (showMessages)
				{
					Messages.Message("ESCP_AbilityMustBeFactionless".Translate(), targetPawn, MessageTypeDefOf.RejectInput, false);
				}
				return false;
			}
			return true;
		}
	}
}

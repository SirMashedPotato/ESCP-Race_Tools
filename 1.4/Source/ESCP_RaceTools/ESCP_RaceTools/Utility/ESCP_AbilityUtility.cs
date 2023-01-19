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

		public static float GetAncestorGiftDuration(float psychSens = 1f, float maxDuration = 5000f, float perSensPoint = 84f)
        {
			float duration = perSensPoint * (psychSens*10);
			return duration > maxDuration ? maxDuration : duration;
        }

		public static string GetAncestorGiftDuration_Display(int duration)
        {
			return "AbilityDuration".Translate() + ": " + ((duration >= 2500) ? duration.ToStringTicksToPeriod(true, false, true, true) : (duration + "LetterSecond".Translate()));
		}
	}
}

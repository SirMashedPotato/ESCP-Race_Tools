using System;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
	[DefOf]
	public static class HediffDefOf
	{

		static HediffDefOf()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(HediffDefOf));
		}

		public static HediffDef ESCP_BeastMasterTraining;
	}
}

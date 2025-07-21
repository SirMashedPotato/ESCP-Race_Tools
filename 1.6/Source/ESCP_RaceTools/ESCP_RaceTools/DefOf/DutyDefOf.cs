using RimWorld;
using Verse.AI;

namespace ESCP_RaceTools
{
	[DefOf]
	public static class DutyDefOf
	{

		static DutyDefOf()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(DutyDefOf));
		}

		public static DutyDef ESCP_EscortAndDefendMaster;
	}
}

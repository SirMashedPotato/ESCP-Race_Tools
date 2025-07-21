using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
	//In theory, kinda standard role check, but also checks for race too

    class RitualOutcomeComp_RacePresentNotSubstituted : RitualOutcomeComp_QualitySingleOffset
    {
		protected override string LabelForDesc
		{
			get
			{
				return label;
			}
		}

		public override bool Applies(LordJob_Ritual ritual)
		{
			return ritual.RoleFilled(roleId) && !ritual.assignments.RoleSubstituted(roleId);
		}

		public override ExpectedOutcomeDesc GetExpectedOutcomeDesc(Precept_Ritual ritual, TargetInfo ritualTarget, RitualObligation obligation, RitualRoleAssignments assignments, RitualOutcomeComp_Data data)
		{
			bool flag = assignments.AnyPawnAssigned(roleId) && !assignments.RoleSubstituted(roleId) && assignments.FirstAssignedPawn(roleId).def == raceDef;
			return new ExpectedOutcomeDesc
			{
				label = LabelForDesc.CapitalizeFirst(),
				present = flag,
				effect = ExpectedOffsetDesc(flag, -1f),
				quality = (flag ? qualityOffset : 0f),
				positive = flag,
				priority = 3f
			};
		}

		public string roleId;

		public ThingDef raceDef;
	}
}

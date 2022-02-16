using System;
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
				return this.label;
			}
		}

		public override bool Applies(LordJob_Ritual ritual)
		{
			return ritual.RoleFilled(this.roleId) && !ritual.assignments.RoleSubstituted(this.roleId);
		}

		public override ExpectedOutcomeDesc GetExpectedOutcomeDesc(Precept_Ritual ritual, TargetInfo ritualTarget, RitualObligation obligation, RitualRoleAssignments assignments, RitualOutcomeComp_Data data)
		{
			bool flag = assignments.AnyPawnAssigned(this.roleId) && !assignments.RoleSubstituted(this.roleId) && assignments.FirstAssignedPawn(this.roleId).def == raceDef;
			return new ExpectedOutcomeDesc
			{
				label = this.LabelForDesc.CapitalizeFirst(),
				present = flag,
				effect = this.ExpectedOffsetDesc(flag, -1f),
				quality = (flag ? this.qualityOffset : 0f),
				positive = flag,
				priority = 3f
			};
		}

		public string roleId;

		public ThingDef raceDef;
	}
}

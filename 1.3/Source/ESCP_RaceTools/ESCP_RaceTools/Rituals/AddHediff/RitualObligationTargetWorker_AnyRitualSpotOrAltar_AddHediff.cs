using System;
using System.Linq;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class RitualObligationTargetWorker_AnyRitualSpotOrAltar_AddHediff : RitualObligationTargetWorker_AnyRitualSpotOrAltar
    {
        public RitualObligationTargetWorker_AnyRitualSpotOrAltar_AddHediff()
        {
        }

        public RitualObligationTargetWorker_AnyRitualSpotOrAltar_AddHediff(RitualObligationTargetFilterDef def) : base(def)
        {
        }

		public override bool ObligationTargetsValid(RitualObligation obligation)
		{
			Pawn pawn;
			if ((pawn = (obligation.targetA.Thing as Pawn)) == null)
			{
				return false;
			}
			if (pawn.Dead)
			{
				return false;
			}
			var props = IdeoProperties.Get(this.def);
			if(props == null || props.hediffDef == null)
            {
				return false;
            }
			return pawn.health.hediffSet.GetFirstHediffOfDef(props.hediffDef) == null;
		}
	}
}

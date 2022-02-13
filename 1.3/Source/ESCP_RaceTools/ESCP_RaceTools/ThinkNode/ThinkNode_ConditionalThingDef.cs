using System;
using Verse;
using Verse.AI;
using RimWorld;

namespace ESCP_RaceTools
{
    class ThinkNode_ConditionalThingDef : ThinkNode_Conditional
    {
		public override ThinkNode DeepCopy(bool resolve = true)
		{
			ThinkNode_ConditionalThingDef thinkNode_ConditionalThingDef = (ThinkNode_ConditionalThingDef)base.DeepCopy(resolve);
			thinkNode_ConditionalThingDef.thingDef = this.thingDef;
			return thinkNode_ConditionalThingDef;
		}

		protected override bool Satisfied(Pawn pawn)
		{
			return pawn.def == this.thingDef;
		}

		public ThingDef thingDef;
	}
}

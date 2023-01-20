using RimWorld;
using Verse;
using System.Collections.Generic;

namespace ESCP_RaceTools
{
	class CompProperties_BeserkerRage : CompProperties
	{
		public CompProperties_BeserkerRage()
		{
			this.compClass = typeof(Comp_BeserkerRage);
		}
		public HediffDef hediffDef;
		public bool enableAugments = false;
		public RecordDef recordDef;
		public List<ThingDef> totems;
		public List<HediffDef> augments;
		public bool enableTracker = true;
		public SkillDef manualSkill;	//defaults to melee if left null
		public int manualSkillLevel = 13;
	}
}
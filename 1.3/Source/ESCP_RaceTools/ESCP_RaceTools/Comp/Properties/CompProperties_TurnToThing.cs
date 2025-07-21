using RimWorld;
using Verse;
using System;
using System.Collections.Generic;

namespace ESCP_RaceTools
{
    class CompProperties_TurnToThing : CompProperties
	{
		public CompProperties_TurnToThing()
		{
			this.compClass = typeof(Comp_TurnToThing);
		}
		public ThingDef thingDef;
		public string texPath;
		public string label;
		public string desc;
		public bool requiresFullHealth = true;
		public FleckDef fleck;
	}
}
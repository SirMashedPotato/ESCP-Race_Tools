using System;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class CompProperties_ReplaceOnMature : CompProperties
    {
		public CompProperties_ReplaceOnMature()
		{
			this.compClass = typeof(Comp_ReplaceOnMature);
		}
		public ThingDef matureInto = null;
		//Probably don't spawn something that is 'stuffed'. RimWorld will get angry, and find a default stuff thing
	}
}
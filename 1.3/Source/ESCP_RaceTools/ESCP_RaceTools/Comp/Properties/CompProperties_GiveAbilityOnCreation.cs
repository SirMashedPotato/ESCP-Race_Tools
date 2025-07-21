using RimWorld;
using Verse;
using System;
using System.Collections.Generic;

namespace ESCP_RaceTools
{
    class CompProperties_GiveAbilityOnCreation : CompProperties
	{
		public CompProperties_GiveAbilityOnCreation()
		{
			this.compClass = typeof(Comp_GiveAbilityOnCreation);
		}
		public List<AbilityDef> abilitiesList;
	}
}
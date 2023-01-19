using RimWorld;
using System.Collections.Generic;
using Verse;
using UnityEngine;

namespace ESCP_RaceTools
{
    class Comp_GiveAbilityOnCreation : ThingComp
	{
		public CompProperties_GiveAbilityOnCreation Props
		{
			get
			{
				return (CompProperties_GiveAbilityOnCreation)this.props;
			}
		}

        public override void PostSpawnSetup(bool respawningAfterLoad)
        {
            base.PostSpawnSetup(respawningAfterLoad);
            if (!Props.abilitiesList.NullOrEmpty())
            {
                Pawn p = parent as Pawn;
                foreach (AbilityDef a in Props.abilitiesList)
                {
                    p.abilities.GainAbility(a);
                }
            }
        }
    }
}

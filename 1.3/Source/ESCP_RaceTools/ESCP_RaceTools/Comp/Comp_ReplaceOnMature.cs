using System;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class Comp_ReplaceOnMature : ThingComp
    {
		public CompProperties_ReplaceOnMature Props
		{
			get
			{
				return (CompProperties_ReplaceOnMature)this.props;
			}
		}

		public override void CompTickLong()
		{
			base.CompTickLong();
			//in a try catch, as this will try run again after the plant is destroyed
            try
			{
				Plant plant = parent as Plant;
				if (plant.Growth >= 1)
				{
					IntVec3 loc = plant.Position;
					Map map = plant.Map;
					plant.Destroy();
					GenSpawn.Spawn(Props.matureInto, loc, map);
				}
			}
			catch (NullReferenceException e)
            {

            }
		}
		/*
        public override void PostDestroy(DestroyMode mode, Map previousMap)
        {
            base.PostDestroy(mode, previousMap);
        }
		*/
    }
}

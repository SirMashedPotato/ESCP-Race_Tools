using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    [StaticConstructorOnStartup]
    public class PlantBuildingPod : Plant
    {
		public override void Tick()
		{
			base.Tick();
			if (this.IsHashIntervalTick(2000))
			{
				TickLong();
			}
		}

		/* 
		 * basically just copied from Plant 
		 * Need to check for full growth at the start
		 * If so, does the whole replacing stuff
		 */

		public override void TickLong()
		{
			if (Destroyed)
			{
				return;
			}

			var modExt = PlantProperties.Get(def);
			if (modExt != null && modExt.matureInto != null  && Growth >= 1f)
            {
				IntVec3 loc = Position;
				Map map = Map;
				//this.Destroy();
				GenSpawn.Spawn(modExt.matureInto, loc, map);
				return;
			}

			base.TickLong();
		}
	}
}

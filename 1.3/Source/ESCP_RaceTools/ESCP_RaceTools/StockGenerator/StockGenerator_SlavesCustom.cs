using System;
using System.Collections.Generic;
using System.Linq;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
	/*
	 * Mostly doesn't work
	 * The slave kinds are generated, but can not be purchased
	 * The vanilla StockGenerator_Slaves has the same issue with slaveKindDef 
	 */
	class StockGenerator_SlavesCustom : StockGenerator
	{
		public override IEnumerable<Thing> GenerateThings(int forTile, Faction faction = null)
		{
			Log.Message("1");
			if (this.respectPopulationIntent && Rand.Value > StorytellerUtilityPopulation.PopulationIntent)
			{
				yield break;
			}
			Log.Message("2");
			if (faction != null && faction.ideos != null)
			{
				Log.Message("3");
				bool flag = true;
				using (IEnumerator<Ideo> enumerator = faction.ideos.AllIdeos.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (!enumerator.Current.IdeoApprovesOfSlavery())
						{
							flag = false;
							break;
						}
					}
				}
				Log.Message("4");
				if (!flag)
				{
					yield break;
				}
			}
			Log.Message("5");
			int count = this.countRange.RandomInRange;
			int num;
			for (int i = 0; i < count; i = num + 1)
			{
				Log.Message("6");
				Faction faction2;
				if (!(from fac in Find.FactionManager.AllFactionsVisible
					  where fac != Faction.OfPlayer && fac.def.humanlikeFaction && !fac.temporary
					  select fac).TryRandomElement(out faction2))
				{
					yield break;
				}
				Log.Message("7");
				PawnGenerationRequest request = PawnGenerationRequest.MakeDefault();
				//request.KindDef = ((this.slaveKinds.RandomElementByWeight() != null) ? this.slaveKindDef : PawnKindDefOf.Slave);
				request.KindDef = GetSlaveKind();
				request.Faction = faction2;
				request.Tile = forTile;
				request.ForceAddFreeWarmLayerIfNeeded = !this.trader.orbital;
				yield return PawnGenerator.GeneratePawn(request);
				num = i;
			}
			Log.Message("8");
			yield break;
		}

		public override bool HandlesThingDef(ThingDef thingDef)
		{
			return thingDef.category == ThingCategory.Pawn && thingDef.race.Humanlike && thingDef.tradeability > Tradeability.None;
		}

		public PawnKindDef GetSlaveKind()
        {
            if (slaveKinds != null)
            {
				PawnKindDef slave = slaveKinds.RandomElementByWeight(x => x.commonality).slave;
                if (slave != null)
                {
					Log.Message("Kind = " + slave);
					return slave;
                }
            }
			Log.Message("Kind = default");
			return PawnKindDefOf.Slave;
		}

		private bool respectPopulationIntent;

		public List<TraderSlaveRecord> slaveKinds = new List<TraderSlaveRecord>();
	}
}

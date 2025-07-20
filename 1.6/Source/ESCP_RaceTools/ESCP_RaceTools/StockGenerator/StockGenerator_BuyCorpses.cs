using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;
using Verse;

namespace ESCP_RaceTools
{
    class StockGenerator_BuyCorpses : StockGenerator
    {
        public override IEnumerable<Thing> GenerateThings(PlanetTile forTile, Faction faction = null)
        {
            yield break;
        }

        public override bool HandlesThingDef(ThingDef thingDef)
        {
            return thingDef.IsCorpse;
        }
    }
}

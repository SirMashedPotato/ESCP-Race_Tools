using System.Collections.Generic;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class StockGenerator_BuyCorpses : StockGenerator
    {
        public override IEnumerable<Thing> GenerateThings(int forTile, Faction faction = null)
        {
            yield break;
        }

        public override bool HandlesThingDef(ThingDef thingDef)
        {
            return thingDef.IsCorpse;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    public class FactionProperties : DefModExtension
    {
        public bool canMoragTong = false;  //Whether the faction can initiate Morag Tong contracts when hostile

        [Obsolete("Best to use FactionProperties.factionTags instead, kept for old code")]
        public bool isAltmerFaction = false;    //Used for the goodwill worker
        [Obsolete("Best to use FactionProperties.factionTags instead, kept for old code")]
        public bool isMaormerFaction = false;    //Used for the goodwill worker
        [Obsolete("Best to use FactionProperties.factionTags instead, kept for old code")]
        public bool isSloadFaction = false;     //Used for the goodwill worker

        public List<string> factionTags;

        public static FactionProperties Get(Def def)
        {
            return def.GetModExtension<FactionProperties>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class FactionProperties : DefModExtension
    {
        public bool canMoragTong = false;  //Whether the faction can initiate Morag Tong contracts when hostile
        public bool isAltmerFaction = false;    //Used for the goodwill worker
        public bool isDunmerFaction = false;    //Used for the goodwill worker
        public bool isDunmerAshlanderFaction = false;    //As not all Dunmer are created equal, still Dunmer but also not

        public static FactionProperties Get(Def def)
        {
            return def.GetModExtension<FactionProperties>();
        }
    }
}

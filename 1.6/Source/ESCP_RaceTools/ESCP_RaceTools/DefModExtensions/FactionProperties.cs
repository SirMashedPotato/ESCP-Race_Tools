using System.Collections.Generic;
using Verse;

namespace ESCP_RaceTools
{
    public class FactionProperties : DefModExtension
    {
        //used for good will worker/s
        public List<string> factionTags;
        //used for specific incident raids, eg Morag Tong, Goblin mercanaries, Dark Brotherhood
        public List<string> hireableFactionTags;

        public static FactionProperties Get(Def def)
        {
            return def.GetModExtension<FactionProperties>();
        }
    }
}

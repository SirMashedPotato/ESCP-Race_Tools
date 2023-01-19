using System;
using System.Collections.Generic;
using System.Linq;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    public class FactionGoodwillProperties : DefModExtension
    {
        //used for: ThoughtWorker_UniversalBackstoryOpinion_Shared
        public List<string> sharedFactionTags;
        //used for: GoodWillWorker_UniversalFactionTagCompatibility
        public string FactionTagA;
        public string FactionTagB;

        public static FactionGoodwillProperties Get(Def def)
        {
            return def.GetModExtension<FactionGoodwillProperties>();
        }
    }
}

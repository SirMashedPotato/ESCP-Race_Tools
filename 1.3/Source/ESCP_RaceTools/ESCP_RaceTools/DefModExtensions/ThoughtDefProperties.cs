using System;
using System.Collections.Generic;
using System.Linq;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    public class ThoughtDefProperties : DefModExtension
    {
        //used for: ThoughtWorker_UniversalBackstoryOpinion_Shared
        public List<string> sharedBackstoryCategories;
        //used for: ThoughtWorker_UniversalBackstoryOpinion
        public string backstoryCategoryA;
        public string backstoryCategoryB;
        //used for: ThoughtWorker_UniversalTraitOpinion
        public TraitDef traitA;
        public TraitDef traitB;

        public static ThoughtDefProperties Get(Def def)
        {
            return def.GetModExtension<ThoughtDefProperties>();
        }
    }
}

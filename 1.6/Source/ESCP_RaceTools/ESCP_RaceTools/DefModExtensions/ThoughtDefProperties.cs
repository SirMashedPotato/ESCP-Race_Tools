using System.Collections.Generic;
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
        //used for: ThoughtWorker_UniversalTraitSpectrumOpinion
        public bool useSpectrum = false;
        public int traitSpectrumA = 1;
        public int traitSpectrumB = 1;

        public static ThoughtDefProperties Get(Def def)
        {
            return def.GetModExtension<ThoughtDefProperties>();
        }
    }
}

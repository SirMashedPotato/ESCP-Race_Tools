using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    public class FactionGoodwillProperties : DefModExtension
    {
        //used for: GoodWillWorker_UniversalFactionTagCompatibility
        public string FactionTagA;
        public string FactionTagB;
        public PreceptDef preceptDef;

        public static FactionGoodwillProperties Get(Def def)
        {
            return def.GetModExtension<FactionGoodwillProperties>();
        }
    }
}

using Verse;

namespace ESCP_RaceTools
{
    public class FactionGoodwillProperties : DefModExtension
    {
        //used for: GoodWillWorker_UniversalFactionTagCompatibility
        public string FactionTagA;
        public string FactionTagB;

        public static FactionGoodwillProperties Get(Def def)
        {
            return def.GetModExtension<FactionGoodwillProperties>();
        }
    }
}

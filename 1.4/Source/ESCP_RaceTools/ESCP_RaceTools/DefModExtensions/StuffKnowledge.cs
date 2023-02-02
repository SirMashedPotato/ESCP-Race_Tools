using Verse;

namespace ESCP_RaceTools
{
    public class StuffKnowledge : DefModExtension
    {
        public HediffDef requiredHediffDef;

        public static StuffKnowledge Get(Def def)
        {
            return def.GetModExtension<StuffKnowledge>();
        }
    }
}

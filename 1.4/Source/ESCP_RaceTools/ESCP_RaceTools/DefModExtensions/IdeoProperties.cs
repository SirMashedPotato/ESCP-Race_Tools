using RimWorld;
using Verse;

namespace ESCP_RaceTools
{
    public class IdeoProperties : DefModExtension
    {
        public PreceptDef requiredPreceptDef;

        public static IdeoProperties Get(Def def)
        {
            return def.GetModExtension<IdeoProperties>();
        }
    }
}

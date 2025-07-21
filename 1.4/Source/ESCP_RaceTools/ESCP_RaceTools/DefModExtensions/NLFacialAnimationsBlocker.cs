using Verse;

namespace ESCP_RaceTools
{
    public class NLFacialAnimationsBlocker : DefModExtension
    {
        public static NLFacialAnimationsBlocker Get(Def def)
        {
            return def.GetModExtension<NLFacialAnimationsBlocker>();
        }
    }
}

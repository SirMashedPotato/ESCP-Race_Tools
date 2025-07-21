using Verse;

namespace ESCP_RaceTools
{
    public class HediffCompProperties_UntameOnEnd : HediffCompProperties
    {
        public HediffCompProperties_UntameOnEnd()
        {
            compClass = typeof(HediffComp_UntameOnEnd);
        }

        public bool untame = true;
    }
}

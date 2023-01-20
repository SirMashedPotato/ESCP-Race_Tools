using Verse;

namespace ESCP_RaceTools
{
    class HediffCompProperties_ViolentMeditation : HediffCompProperties
    {
        public HediffCompProperties_ViolentMeditation()
        {
            compClass = typeof(HediffComp_ViolentMeditation);
        }

        public float div = 100f;
    }
}

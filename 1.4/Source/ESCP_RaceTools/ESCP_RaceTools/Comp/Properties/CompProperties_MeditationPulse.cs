using RimWorld;
using Verse;

namespace ESCP_RaceTools
{
    class CompProperties_MeditationPulse : CompProperties
    {

        public CompProperties_MeditationPulse()
        {
            compClass = typeof(Comp_MeditationPulse);
        }

        public MeditationFocusDef focusDef;
        public float amount = 0.1f;
        public int ticksBetween = 900;
        public int radius = 3;
        public FleckDef fleck;
    }
}

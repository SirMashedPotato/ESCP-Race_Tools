using Verse;

namespace ESCP_RaceTools
{
    class CompProperties_DunmerGraveWhisper : CompProperties
    {

        public CompProperties_DunmerGraveWhisper()
        {
            compClass = typeof(Comp_DunmerGraveWhisper);
        }

        public SoundDef soundDef;
        public bool onlyFull = true;

    }
}

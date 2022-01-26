using RimWorld;
using Verse;
using Verse.Sound;

namespace ESCP_RaceTools
{
    class CompProperties_DunmerGraveWhisper : CompProperties
    {

        public CompProperties_DunmerGraveWhisper()
        {
            this.compClass = typeof(Comp_DunmerGraveWhisper);
        }

        public SoundDef soundDef;
        public bool onlyFull = true;

    }
}

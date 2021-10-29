using System;
using RimWorld;
using Verse;

namespace ESCP_RaceTools
{
    class HediffCompProperties_NightEye : HediffCompProperties
    {
        public HediffCompProperties_NightEye()
        {
            this.compClass = typeof(HediffComp_NightEye);
        }

        public float lightLevelRequired = 0.3f;
    }
}

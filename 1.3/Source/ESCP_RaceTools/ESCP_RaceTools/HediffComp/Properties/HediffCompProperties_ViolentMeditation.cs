using System;
using RimWorld;
using Verse;
using System.Collections.Generic;

namespace ESCP_RaceTools
{
    class HediffCompProperties_ViolentMeditation : HediffCompProperties
    {
        public HediffCompProperties_ViolentMeditation()
        {
            this.compClass = typeof(HediffComp_ViolentMeditation);
        }

        public float div = 100f;
    }
}

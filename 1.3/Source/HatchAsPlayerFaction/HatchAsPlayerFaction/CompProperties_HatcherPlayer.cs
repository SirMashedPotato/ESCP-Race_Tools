using System;
using Verse;
using RimWorld;

namespace HatchAsPlayerFaction
{
    class CompProperties_HatcherPlayer : CompProperties
    {
        public CompProperties_HatcherPlayer()
        {
            this.compClass = typeof(CompHatcherPlayer);
        }

        public float hatcherDaystoHatch = 1f;

        public PawnKindDef hatcherPawn;
    }
}

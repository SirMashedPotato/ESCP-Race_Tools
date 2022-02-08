using System;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class ThoughtWorker_Situational_Precept_NoSloadInColony : ThoughtWorker_Precept
    {
        protected override ThoughtState ShouldHaveThought(Pawn p)
        {
            return p.IsColonist && !p.IsSlave && !p.IsPrisoner && SloadUtility.SloadsInFaction(p.Faction) == 0;
        }
    }
}
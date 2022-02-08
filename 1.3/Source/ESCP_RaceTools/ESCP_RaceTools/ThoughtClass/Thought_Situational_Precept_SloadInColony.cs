using System;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class Thought_Situational_Precept_SloadInColony : Thought_Situational
    {
        public override float MoodOffset()
        {
            return this.BaseMoodOffset * (float)SloadUtility.SloadsInFaction(this.pawn.Faction);
        }
    }
}




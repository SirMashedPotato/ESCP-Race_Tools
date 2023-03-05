using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Verse;
using RimWorld;
using AchievementsExpanded;

namespace Mashed_VanillaAchievementsExpanded
{
    /* Notes:
      * Pretty much completely custom tracker
      * Triggered when the player recruits a pawn with the specified hediff, and optionally with the specified severity
      */

    class PawnHediffTracker : PawnJoinedTracker
    {
    public ThingDef key;
    public HediffDef hediff;
    public float minSeverity = 0f;

    protected override string[] DebugText => new string[] { $"Def: {key?.defName ?? "None"}",
                                                                $"hediff: {hediff}",
                                                                $"severity: {minSeverity}"};

    public PawnHediffTracker()
    {
    }

    public PawnHediffTracker(PawnHediffTracker reference) : base(reference)
    {
        key = reference.key;
        hediff = reference.hediff;
        minSeverity = reference.minSeverity;
    }

    public override bool UnlockOnStartup => Trigger(null);

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Defs.Look(ref key, "key");
        Scribe_Defs.Look(ref hediff, "hediff");
        Scribe_Values.Look(ref minSeverity, "severity");
    }

    public override bool Trigger(Pawn param)
    {
        base.Trigger(param);
        ThingDef raceDef = param?.def;
        var factionPawns = PawnsFinder.AllMapsCaravansAndTravelingTransportPods_Alive_OfPlayerFaction;
        if (factionPawns is null)
        {
            return false;
        }
            if (key == raceDef && param.health.hediffSet.GetFirstHediffOfDef(hediff) != null)
            {
                if (minSeverity == 0f || param.health.hediffSet.GetFirstHediffOfDef(hediff).Severity >= minSeverity) 
                {
                    return true;
                }
            }
        return false;
    }

}
}

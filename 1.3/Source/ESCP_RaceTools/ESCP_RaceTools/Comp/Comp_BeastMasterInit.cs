using RimWorld;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Verse;
using Verse.AI;
using Verse.AI.Group;

namespace ESCP_RaceTools
{
    [Obsolete]
    class Comp_BeastMasterInit : ThingComp
    {
        public bool ESCP_BeastMaster_beastsSpawned = false;

        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Values.Look<bool>(ref this.ESCP_BeastMaster_beastsSpawned, "ESCP_BeastMaster_beastsSpawned", true, false);
        }

        public CompProperties_BeastMasterInit Props
        {
            get
            {
                return (CompProperties_BeastMasterInit)this.props;
            }
        }

        public override void CompTick()
        {
            base.CompTick();

            if (!ESCP_BeastMaster_beastsSpawned)
            {
                Pawn p = parent as Pawn;
                ESCP_BeastMaster_beastsSpawned = true;

                /* checks */
                if (ModSettingsUtility.ESCP_RaceTools_EnableBeastMaster())
                {
                    if (!p.Spawned)  return;
                    if (p.Dead) return;
                    if (p.Faction == null) return;
                    if (p.Map == null) return;
                    if (p.GetLord() == null) return;
                    if (p.Downed) return;
                    if (BeastMaster.Get(p.kindDef) == null) return;
                    if (p.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.ESCP_HiddenBeastMaster) != null) return;

                    if (ModSettingsUtility.ESCP_BeastMasterLogging()) Log.Message("Found beast master: " + p);
                    List<Pawn> pawns = BeastMasterUtility.ReadyAdditionalSpawns(p);
                    BeastMasterUtility.GiveLord(pawns, p);
                    BeastMasterUtility.GiveDuty(pawns, p);
                    BeastMasterUtility.GiveMaster(pawns, p);
                    p.health.AddHediff(HediffDefOf.ESCP_HiddenBeastMaster);
                }
            }
        }
    }
}

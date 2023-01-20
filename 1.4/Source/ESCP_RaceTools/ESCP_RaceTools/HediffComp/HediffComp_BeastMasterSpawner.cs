using System.Collections.Generic;
using Verse;
using Verse.AI.Group;

namespace ESCP_RaceTools
{
    class HediffComp_BeastMasterSpawner : HediffComp
	{
        public bool ESCP_BeastMaster_beastsSpawned = false;

        public override void CompExposeData()
        {
            base.CompExposeData();
            Scribe_Values.Look(ref ESCP_BeastMaster_beastsSpawned, "ESCP_BeastMaster_beastsSpawned", true, false);
        }

        //in post tick because it doesn't work in spawn post make
        public override void CompPostTick(ref float severityAdjustment)
        {
            if (!ESCP_BeastMaster_beastsSpawned)
            {
                Pawn p = Pawn;
                ESCP_BeastMaster_beastsSpawned = true;

                if (ModSettingsUtility.ESCP_RaceTools_EnableBeastMaster())
                {
                    if (!p.Spawned) return;
                    if (p.Dead) return;
                    if (p.Faction == null) return;
                    if (p.Map == null) return;
                    if (p.GetLord() == null) return;
                    if (p.Downed) return;
                    if (BeastMaster.Get(p.kindDef) == null) return;

                    if (ModSettingsUtility.ESCP_BeastMasterLogging()) 
                    { 
                        Log.Message("Found beast master: " + p);
                    }
                    List<Pawn> pawns = BeastMasterUtility.ReadyAdditionalSpawns(p);
                    BeastMasterUtility.GiveLord(pawns, p);
                    BeastMasterUtility.GiveDuty(pawns, p);
                    BeastMasterUtility.GiveMaster(pawns, p);
                }
                Pawn.health.RemoveHediff(parent);
            }
        }
    }
}

using System;
using Verse;
using RimWorld;
using System.Collections.Generic;
using System.Linq;

namespace ESCP_RaceTools
{
    class DeathActionWorker_Sload : DeathActionWorker_HistoryEventOnDeath
    {
        public override void PawnDied(Corpse corpse)
        {
            corpse.InnerPawn.GetComp<Comp_SloadThralls>().KillThralls();
            base.PawnDied(corpse);
        }
    }
}

using Verse;
using RimWorld;
using System.Collections.Generic;

namespace ESCP_RaceTools
{
    //TODO, move this to a Harmony patch
    public class DeathActionWorker_HistoryEventOnDeath : DeathActionWorker
    {
        public override void PawnDied(Corpse corpse)
        {
            if (corpse !=  null && corpse.InnerPawn != null && corpse.Map != null)
            {
                var props = RaceProperties.Get(corpse.InnerPawn.def);
                if(props != null && props.eventOnDeath != null)
                {
                    if (ModsConfig.IdeologyActive)
                    {
                        List<Pawn> pawns = new List<Pawn>(corpse.Map.mapPawns.FreeColonistsSpawned);
                        foreach(Pawn p in pawns)
                        {
                            HistoryEvent historyEvent = new HistoryEvent(props.eventOnDeath, p.Named(HistoryEventArgsNames.Doer));
                            Find.HistoryEventsManager.RecordEvent(historyEvent, true);
                        }
                    }
                }
            } 
        }
    }
}

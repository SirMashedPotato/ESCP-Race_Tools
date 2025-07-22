using Verse;
using RimWorld;
using System.Collections.Generic;
using Verse.AI.Group;

namespace ESCP_RaceTools
{
    public class DeathActionWorker_HistoryEventOnDeath : DeathActionWorker
    {
        public override void PawnDied(Corpse corpse, Lord prevLord)
        {
            if (corpse !=  null && corpse.InnerPawn != null && corpse.Map != null)
            {
                var props = RaceProperties.Get(corpse.InnerPawn.def);
                if(props != null && props.eventOnDeath != null)
                {
                    if (ModsConfig.IdeologyActive)
                    {
                        List<Pawn> pawns = [.. corpse.Map.mapPawns.FreeColonistsSpawned];
                        foreach(Pawn p in pawns)
                        {
                            HistoryEvent historyEvent = new(props.eventOnDeath, p.Named(HistoryEventArgsNames.Doer));
                            Find.HistoryEventsManager.RecordEvent(historyEvent, true);
                        }
                    }
                }
            } 
        }
    }
}

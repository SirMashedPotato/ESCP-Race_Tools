using Verse;
using RimWorld;
using UnityEngine;

namespace DessicateOnDeath
{
    class DeathActionWorker_DessicateOnDeath : DeathActionWorker
    {

        public override void PawnDied(Corpse corpse)
        {
            if (corpse != null && corpse.Map != null)
            {
                var rot = corpse.GetComp<CompRottable>();
                if(rot != null)
                {
                    rot.RotProgress = rot.PropsRot.TicksToDessicated;

                    if (corpse.InnerPawn.def.race.BloodDef != null)
                    {
                        FilthMaker.TryMakeFilth(corpse.Position, corpse.Map, corpse.InnerPawn.def.race.BloodDef, 3);
                    }
                    FleckMaker.AttachedOverlay(corpse, FleckDefOf.DustPuffThick, Vector3.zero, 10, -1);
                }
                else
                {
                    Log.Warning("You tried adding 'DeathActionWorker_DessicateOnDeath' to " + corpse.InnerPawn.def + " which doesn't rot.");
                }
            }
        }
    }
}

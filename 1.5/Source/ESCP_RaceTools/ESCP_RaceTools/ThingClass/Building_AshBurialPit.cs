using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    public class Building_AshBurialPit : Building_Grave
    {
        public override void Notify_CorpseBuried(Pawn worker)
        {
            base.Notify_CorpseBuried(worker);

            if (Corpse != null && Corpse.InnerPawn.RaceProps.IsFlesh)
            {
                CompRottable compRot = Corpse.GetComp<CompRottable>();
                if (compRot != null)
                {
                    compRot.RotProgress = compRot.PropsRot.TicksToDessicated;
                }
                if (Corpse.InnerPawn.apparel != null && Corpse.InnerPawn.apparel.AnyApparel)
                {
                    Corpse.InnerPawn.apparel.DropAll(Position);
                }
                if (!Corpse.InnerPawn.inventory.innerContainer.NullOrEmpty())
                {
                    Corpse.InnerPawn.inventory.innerContainer.TryDropAll(Position, Map, ThingPlaceMode.Near);
                }
            }
        }
    }
}

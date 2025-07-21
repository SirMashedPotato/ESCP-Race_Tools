using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    public class Building_AshBurialPit : Building_Grave
    {
        /// <summary>
        /// Used to override Notify_CorpseBuried(Pawn worker)
        /// </summary>
        public override void Notify_HauledTo(Pawn hauler, Thing thing, int count)
        {
            base.Notify_HauledTo(hauler, thing, count);

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

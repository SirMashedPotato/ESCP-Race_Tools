using Verse;

namespace LeaveResourcesOnDeath
{
    class Building_LeaveAllOnDeconstruct : Building
    {
        public override void Destroy(DestroyMode mode = DestroyMode.Vanish)
        {
            if (mode == DestroyMode.Deconstruct)
            {
                mode = DestroyMode.Refund;
            }
            base.Destroy(mode);
        }
    }
}

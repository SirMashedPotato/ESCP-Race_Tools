using RimWorld;
using System.Collections.Generic;
using Verse;

namespace PowerArmourFrameCheck
{
    class FrameApparel : ThingComp
    {
        public override void Notify_Unequipped(Pawn pawn)
        {
            base.Notify_Unequipped(pawn);
            if (pawn.apparel != null)
            {
                List<Apparel> toRemove = new List<Apparel> { };
                foreach (var ap in pawn.apparel.WornApparel)
                {
                    var thingProps = RequirementProperties.Get(ap.def);
                    if (thingProps != null && thingProps.requiredFrameDefNames != null)
                    {
                        if (!pawn.apparel.WornApparel.Any(x => thingProps.requiredFrameDefNames.Contains(x.def.defName)))
                        {
                            toRemove.Add(ap);
                        }
                    }
                }
                if (!toRemove.NullOrEmpty())
                {
                    foreach (var ap in toRemove)
                    {
                        pawn.apparel.TryDrop(ap, out _, pawn.PositionHeld);
                    }
                }
            }
        }
    }
}

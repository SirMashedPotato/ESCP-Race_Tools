using RimWorld;
using Verse;

namespace ESCP_RaceTools
{
    /// <summary>
    /// Prevents pawns from wearing apparel that covers specific tags, unless specifically allowed
    /// </summary>
    public static class EquipmentUtility_CanEquip_Patch
    {
        public static void PawnCanWear_PostFix(Thing thing, Pawn pawn, ref string cantReason, ref bool __result)
        {
            if (thing is Apparel)
            {
                if (ESCP_RaceTools_ModSettings.EnableRestrictedApparel)
                {
                    RaceProperties props = RaceProperties.Get(pawn.def);
                    if (props != null && !props.restrictedApparelPartGroups.NullOrEmpty() && !thing.def.apparel.bodyPartGroups.NullOrEmpty())
                    {
                        if (props.restrictedApparelPartGroups.Any(x=>thing.def.apparel.bodyPartGroups.Any(y=>y==x)))
                        {
                            if (props.restrictedApparelOverrideTag == null || (!thing.def.apparel.tags.NullOrEmpty() && !thing.def.apparel.tags.Contains(props.restrictedApparelOverrideTag)))
                            {
                                __result = false;
                                cantReason = "ESCP_ApparelRestriction_CantWear".Translate(pawn.def.label, thing.Label);
                            }
                        }
                    }
                }
            }
        }
    }
}

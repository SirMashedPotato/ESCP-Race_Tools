using HarmonyLib;
using RimWorld;
using Verse;
using System;
using System.Linq;

namespace PowerArmourFrameCheck
{
	[StaticConstructorOnStartup]
	public class HarmonyPatches
	{
		private static readonly Type patchType = typeof(HarmonyPatches);
		static HarmonyPatches()
		{
			Harmony harmony = new Harmony(id: "com.PowerArmourFrameCheck");

			harmony.Patch(AccessTools.Method(typeof(EquipmentUtility), nameof(EquipmentUtility.CanEquip), new[] { typeof(Thing), typeof(Pawn), typeof(string).MakeByRefType(), typeof(bool) }), postfix: new HarmonyMethod(patchType, nameof(PowerArmourAddonPostfix)));
		}

		public static void PowerArmourAddonPostfix(Thing thing, Pawn pawn, ref string cantReason, ref bool __result)
		{
            if (__result)
            {
				var thingProps = RequirementProperties.Get(thing.def);
				if(thingProps != null && thingProps.requiredFrameDefNames != null)
                {
                    if (pawn.apparel != null)
                    {
                        if (!pawn.apparel.WornApparel.Any(x => thingProps.requiredFrameDefNames.Contains(x.def.defName)))
                        {
							__result = false;
							cantReason = thingProps.failReason;

						}
                    }
                }
            }
		}
    }
}


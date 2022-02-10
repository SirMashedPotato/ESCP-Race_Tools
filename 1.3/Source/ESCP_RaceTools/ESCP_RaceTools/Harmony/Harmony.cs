using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;
using Verse.AI;
using Verse.AI.Group;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Linq;
using RimWorld.Planet;


namespace ESCP_RaceTools
{
    //Setting the Harmony instance
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.ESCP_RaceTools");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

	/* Real basic patch, checks if the pawn has an Argo stomach, prevents food poisoning if they do */

	[HarmonyPatch(typeof(FoodUtility))]
	[HarmonyPatch("GetFoodPoisonChanceFactor")]
	public static class FoodUtility_GetFoodPoisonChanceFactor_Patch
	{
		[HarmonyPostfix]
		public static void ArgoStomachPatch(Pawn ingester, ref float __result)
		{
			if (ModSettingsUtility.ESCP_RaceTools_EnableArgoStomachFoodPoisoningResist() && __result != 0f)
			{
                if (DefDatabase<HediffDef>.GetNamed("ESCP_ArgonianStomach", false) != null)
                {
					if (ingester.health.hediffSet.GetFirstHediffOfDef(HediffDef.Named("ESCP_ArgonianStomach")) != null)
					{
						__result = 0f;
					}
				}
			}
		}
	}

    

    /*
    [HarmonyPatch(typeof(ThingDef))]
    class GetRidOfLeaderError
    {
        [HarmonyPostfix]
        [HarmonyPatch("LabelAsStuff", MethodType.Getter)]
        public static void GetRidOfLeaderError_Patch(ref ThingDef __instance, ref string __result)
        {
            Log.Message("Triggering: " + __instance.label);
            __result = null;
        }
    }
    */
}


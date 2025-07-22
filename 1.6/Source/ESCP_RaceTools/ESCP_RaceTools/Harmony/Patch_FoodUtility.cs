using HarmonyLib;
using RimWorld;
using Verse;

namespace ESCP_RaceTools
{
	[HarmonyPatch(typeof(FoodUtility))]
	[HarmonyPatch("GetFoodPoisonChanceFactor")]
	public static class FoodUtility_GetFoodPoisonChanceFactor_Patch
	{
		public static void Postfix(Pawn ingester, ref float __result)
		{
			if (__result > 0f)
			{
				RaceProperties props = RaceProperties.Get(ingester.def);

				if (props != null && props.foodPoisoningResistant)
				{
					__result = 0f;
				}
			}
		}
	}
}

using HarmonyLib;
using RimWorld;
using Verse;

namespace ESCP_RaceTools
{
    [HarmonyPatch(typeof(TradeUtility))]
    [HarmonyPatch("EverPlayerSellable")]
    public static class TradeUtility_EverPlayerSellable_CorpsePatch
    {
        [HarmonyPostfix]
        public static void EverPlayerSellable_CorpseFix(ThingDef def, ref bool __result)
        {
            if (!__result)
            {
                if (def.IsCorpse)
                {
                    __result = true;
                }
            }
        }
    }

    [HarmonyPatch(typeof(StockGenerator_BuyExpensiveSimple))]
    [HarmonyPatch("HandlesThingDef")]
    public static class StockGenerator_BuyExpensiveSimple_CorpsePatch
    {
        [HarmonyPostfix]
        public static void StockGenerator_BuyExpensiveSimple_CorpseFix(ThingDef thingDef, ref bool __result)
        {
            if (__result)
            {
                if (thingDef.IsCorpse)
                {
                    __result = false;
                }
            }
        }
    }
}

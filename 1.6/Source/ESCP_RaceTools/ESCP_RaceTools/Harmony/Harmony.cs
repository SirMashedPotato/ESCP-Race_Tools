using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;

namespace ESCP_RaceTools
{
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.ESCP_RaceTools");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            harmony.Patch(AccessTools.Method(typeof(EquipmentUtility), nameof(EquipmentUtility.CanEquip), [typeof(Thing), typeof(Pawn), typeof(string).MakeByRefType(), typeof(bool)]), postfix: new HarmonyMethod(typeof(EquipmentUtility_CanEquip_Patch), nameof(EquipmentUtility_CanEquip_Patch.PawnCanWear_PostFix)));
        }
    }
}


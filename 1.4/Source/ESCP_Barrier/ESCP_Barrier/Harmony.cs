using HarmonyLib;
using Verse;
using System.Reflection;
using RimWorld;
using UnityEngine;

namespace ESCP_Barrier
{
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.ESCP_Barrier");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(Gizmo_EnergyShieldStatus))]
    [HarmonyPatch("GizmoOnGUI")]
    public static class Gizmo_EnergyShieldStatuse_GizmoOnGUI_Patch
    {
        [HarmonyPrefix]
        public static bool Lynians_UltimateMaskGizmoOnGUI_Patch(Vector2 topLeft, float maxWidth, GizmoRenderParms parms, ref CompShield ___shield, ref Gizmo_EnergyShieldStatus __instance, ref GizmoResult __result)
        {
            if (___shield is Comp_BarrierShield sheildComp)
            {
                Texture2D FullShieldBarTex = SolidColorMaterials.NewSolidColorTexture(sheildComp.Props.fullShieldBarTex);
                Texture2D EmptyShieldBarTex = SolidColorMaterials.NewSolidColorTexture(sheildComp.Props.EmptyShieldBarTex);

                Rect rect = new Rect(topLeft.x, topLeft.y, __instance.GetWidth(maxWidth), 75f);
                Rect rect2 = rect.ContractedBy(6f);
                Widgets.DrawWindowBackground(rect);
                Rect rect3 = rect2;
                rect3.height = rect.height / 2f;
                Text.Font = GameFont.Tiny;
                Widgets.Label(rect3, __instance.shield.IsApparel ? __instance.shield.parent.LabelCap : "ShieldInbuilt".Translate().Resolve());
                Rect rect4 = rect2;
                rect4.yMin = rect2.y + rect2.height / 2f;
                float fillPercent = __instance.shield.Energy / Mathf.Max(1f, __instance.shield.parent.GetStatValue(StatDefOf.EnergyShieldEnergyMax, true, -1));
                Widgets.FillableBar(rect4, fillPercent, FullShieldBarTex, EmptyShieldBarTex, false);
                Text.Font = GameFont.Small;
                Text.Anchor = TextAnchor.MiddleCenter;
                Widgets.Label(rect4, (__instance.shield.Energy * 100f).ToString("F0") + " / " + (__instance.shield.parent.GetStatValue(StatDefOf.EnergyShieldEnergyMax, true, -1) * 100f).ToString("F0"));
                Text.Anchor = TextAnchor.UpperLeft;
                TooltipHandler.TipRegion(rect2, sheildComp.Props.barrierGizmoTooltip);
                __result = new GizmoResult(GizmoState.Clear);
                return false;
            }
            return true;
        }
    }
}

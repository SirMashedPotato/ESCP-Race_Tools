using System;
using UnityEngine;
using Verse;
using RimWorld;

namespace ESCP_Barrier
{
    [StaticConstructorOnStartup]
    class Gizmo_BarrierShieldStatus : Gizmo
    {
		public Gizmo_BarrierShieldStatus()
		{
			this.order = -100f;
		}

		public override float GetWidth(float maxWidth)
		{
			return 140f;
		}

		public override GizmoResult GizmoOnGUI(Vector2 topLeft, float maxWidth, GizmoRenderParms parms)
		{
			Rect rect = new Rect(topLeft.x, topLeft.y, this.GetWidth(maxWidth), 75f);
			Rect rect2 = rect.ContractedBy(6f);
			Widgets.DrawWindowBackground(rect);
			Rect rect3 = rect2;
			rect3.height = rect.height / 2f;
			Text.Font = GameFont.Tiny;
			Widgets.Label(rect3, this.shield.LabelCap);
			Rect rect4 = rect2;
			rect4.yMin = rect2.y + rect2.height / 2f;
			float fillPercent = this.shield.Energy / Mathf.Max(1f, this.shield.GetStatValue(StatDefOf.EnergyShieldEnergyMax, true));
			Texture2D FullShieldBarTex = SolidColorMaterials.NewSolidColorTexture(this.shield.GetProps().EnergyBarColor);
			Widgets.FillableBar(rect4, fillPercent, FullShieldBarTex, Gizmo_BarrierShieldStatus.EmptyShieldBarTex, false);
			Text.Font = GameFont.Small;
			Text.Anchor = TextAnchor.MiddleCenter;
			Widgets.Label(rect4, (this.shield.Energy * 100f).ToString("F0") + " / " + (this.shield.GetStatValue(StatDefOf.EnergyShieldEnergyMax, true) * 100f).ToString("F0"));
			Text.Anchor = TextAnchor.UpperLeft;
			return new GizmoResult(GizmoState.Clear);
		}

		public BarrierBelt shield;

		//private static readonly Texture2D FullShieldBarTex = SolidColorMaterials.NewSolidColorTexture(new Color(0.30f, 0.25f, 0.32f));
		private static readonly Texture2D EmptyShieldBarTex = SolidColorMaterials.NewSolidColorTexture(Color.clear);
	}
}

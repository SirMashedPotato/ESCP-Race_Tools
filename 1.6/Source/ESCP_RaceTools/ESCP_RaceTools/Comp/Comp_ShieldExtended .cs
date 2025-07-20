using UnityEngine;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    [StaticConstructorOnStartup]
    public class Comp_ShieldExtended : CompShield
    {
        public new CompProperties_ShieldExtended Props
        {
            get
            {
                return (CompProperties_ShieldExtended)props;
            }
        }

        private bool IsBuiltIn
        {
            get
            {
                return !IsApparel;
            }
        }

        public override void CompDrawWornExtras()
        {
            //base.CompDrawWornExtras();
            if (IsApparel)
            {
                Draw();
            }
        }

        public override void PostDraw()
        {
            //base.PostDraw();
            if (IsBuiltIn)
            {
                Draw();
            }
        }

        private void Draw()
        {
            if (ShieldState == ShieldState.Active && ShouldDisplay)
            {
                float num = Mathf.Lerp(Props.minDrawSize, Props.maxDrawSize, energy);
                Vector3 vector = PawnOwner.Drawer.DrawPos;
                vector.y = AltitudeLayer.MoteOverhead.AltitudeFor();
                /*int num2 = Find.TickManager.TicksGame - this.lastAbsorbDamageTick;
				if (num2 < 8)
				{
					float num3 = (float)(8 - num2) / 8f * 0.05f;
					vector += this.impactAngleVect * num3;
					num -= num3;
				}*/
                float angle = Rand.Range(0, 360);
                Vector3 s = new Vector3(num, 1f, num);
                Matrix4x4 matrix = default;
                matrix.SetTRS(vector, Quaternion.AngleAxis(angle, Vector3.up), s);
                Material BubbleMat = MaterialPool.MatFrom(Props.texPath, ShaderDatabase.Transparent);
                Graphics.DrawMesh(MeshPool.plane10, matrix, BubbleMat, 0);
            }
        }
    }
}
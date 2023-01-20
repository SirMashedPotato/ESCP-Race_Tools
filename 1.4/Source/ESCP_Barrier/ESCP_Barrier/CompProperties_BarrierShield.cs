using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld;

namespace ESCP_Barrier
{
    public class CompProperties_BarrierShield : CompProperties_Shield
    {
        public CompProperties_BarrierShield()
        {
            compClass = typeof(Comp_BarrierShield);
        }

        public string bubblePath = "Other/ShieldBubble";
        public bool canFireOut = true;

        /* sounds */
        /*
        public SoundDef soundBarrierBroken;
        public SoundDef soundBarrierReset;
        public SoundDef soundAbsorbedDamage;
        */
        /* gizmo */

        public Color fullShieldBarTex = new Color(0.30f, 0.25f, 0.32f);
        public Color EmptyShieldBarTex = Color.clear;
        public string barrierGizmoTooltip = "";

        /* damage absorption */

        public bool absorbMelee = false;
        public bool absorbRanged = true;
        public bool absorbExplosive = true;
        public List<DamageDef> absorbedDamageDefs;
        public List<DamageDef> allowedDamageDefs;
        public List<DamageDef> breakDamageDefs;
    }
}

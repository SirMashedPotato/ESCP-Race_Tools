using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using Verse.Sound;
using RimWorld;

namespace ESCP_Barrier
{
    public class BarrierProperties : DefModExtension
    {
        public float MinDrawSize = 1.2f;

        public float MaxDrawSize = 1.55f;

        public string BubblePath = "Other/ShieldBubble";

        public bool CanFireOut = true;

        /* sounds */

        public SoundDef soundBarrierBroken;
        public SoundDef soundBarrierReset;
        public SoundDef soundAbsorbedDamage;

        /* gizmo */

        public Color EnergyBarColor = new Color(0.30f, 0.25f, 0.32f);

        /* damage absorption */

        public bool absorbMelee = false;
        public bool absorbRanged = true;
        public bool absorbExplosive = true;
        public List<DamageDef> absorbedDamageDefs;
        public List<DamageDef> allowedDamageDefs;
        public List<DamageDef> breakDamageDefs;

        public static BarrierProperties Get(Def def)
        {
            return def.GetModExtension<BarrierProperties>();
        }
    }
}

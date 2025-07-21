using RimWorld;
using Verse;

namespace ESCP_Birthsigns_Abilities
{
    public class HediffCompProperties_ScaledStatOffset : HediffCompProperties
    {
        public HediffCompProperties_ScaledStatOffset()
        {
            this.compClass = typeof(HediffComp_ScaledStatOffset);
        }

        public SkillDef skillDef;
        public StatDef statDef;
        public float factor = 1f;
    }
}

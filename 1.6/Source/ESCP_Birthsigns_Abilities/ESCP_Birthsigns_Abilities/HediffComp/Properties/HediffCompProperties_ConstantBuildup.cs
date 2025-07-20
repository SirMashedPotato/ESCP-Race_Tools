using Verse;

namespace ESCP_Birthsigns_Abilities
{
    public class HediffCompProperties_ConstantBuildup : HediffCompProperties
    {
        public HediffCompProperties_ConstantBuildup()
        {
            this.compClass = typeof(HediffComp_ConstantBuildup);
        }

        public HediffDef hediffDef;
        public float amountPerSecond = 0.01f;
        public int ticksPer = 60;
    }
}

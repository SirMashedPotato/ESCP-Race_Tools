using Verse;

namespace ESCP_Birthsigns_Abilities
{
    public class HediffCompProperties_DissipateNeuralHeat : HediffCompProperties
    {
        public HediffCompProperties_DissipateNeuralHeat()
        {
            this.compClass = typeof(HediffComp_DissipateNeuralHeat);
        }

        public float chance = 1f;
        public float factor = 0.5f;
    }
}

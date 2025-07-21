using Verse;

namespace PreventTrainingDecay
{
    class PawnProperties : DefModExtension
    {
        public bool preventTrainingDecay = true;

        public static PawnProperties Get(Def def)
        {
            return def.GetModExtension<PawnProperties>();
        }
    }
}

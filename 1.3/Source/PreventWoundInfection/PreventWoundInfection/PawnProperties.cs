using Verse;

namespace PreventWoundInfection
{
    class PawnProperties : DefModExtension
    {
        public bool preventWoundInfection = true;

        public static PawnProperties Get(Def def)
        {
            return def.GetModExtension<PawnProperties>();
        }
    }
}

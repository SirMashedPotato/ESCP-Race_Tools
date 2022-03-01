using Verse;

namespace PreventDisease
{
    class PawnProperties : DefModExtension
    {
        public bool preventDisease = true;

        public static PawnProperties Get(Def def)
        {
            return def.GetModExtension<PawnProperties>();
        }
    }
}

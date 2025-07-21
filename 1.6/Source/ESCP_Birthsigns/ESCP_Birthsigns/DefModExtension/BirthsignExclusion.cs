using Verse;

namespace ESCP_Birthsigns
{
    /// <summary>
    /// Used to exclude races from recieving birthsigns during pawn generation
    /// No idea if it's actually useful, but it's here anyway
    /// </summary>
    class BirthsignExclusion : DefModExtension
    {
        public static BirthsignExclusion Get(Def def)
        {
            return def.GetModExtension<BirthsignExclusion>();
        }
    }
}

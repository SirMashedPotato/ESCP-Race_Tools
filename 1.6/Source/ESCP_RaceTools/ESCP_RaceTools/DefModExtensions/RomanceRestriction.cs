using System.Collections.Generic;
using Verse;

namespace ESCP_RaceTools
{
    public class RomanceRestriction : DefModExtension
    {
        public bool restrictRomanceToTags = false;
        public List<string> restrictedRomanceTags;

        public static RomanceRestriction Get(Def def)
        {
            return def.GetModExtension<RomanceRestriction>();
        }
    }
}

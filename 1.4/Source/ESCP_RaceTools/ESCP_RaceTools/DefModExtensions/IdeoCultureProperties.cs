using System.Collections.Generic;
using Verse;

namespace ESCP_RaceTools
{
    class IdeoCultureProperties : DefModExtension
    {
        public bool overrideDivines = false;
        public bool overrideNineDivines = false;
        public List<Divine> divinesList;

        public static IdeoCultureProperties Get(Def def)
        {
            return def.GetModExtension<IdeoCultureProperties>();
        }

        public class Divine
        {
            public string name = null;
            public string type = null;
            public Gender gender = Gender.None;
            public string iconPath = "UI/Deities/DeityGeneric";
        }

        public override IEnumerable<string> ConfigErrors()
        {
            if (!divinesList.NullOrEmpty())
            {
                if (overrideDivines && (divinesList.Count != 8 || divinesList.Count != 9))
                {
                    yield return "overrideDivines is true, divinesList needs to contain either 8 or 9 items";
                }
                if (overrideNineDivines && divinesList.Count != 9)
                {
                    yield return "overrideNineDivines is true, divinesList needs to contain 9 items";
                }
            }
        }
    }
}

using System.Collections.Generic;
using Verse;

namespace PowerArmourFrameCheck
{
    class RequirementProperties : DefModExtension
    {
        public List<string> requiredFrameDefNames;  //string that corresponds to valid frames
        public string failReason = "requries equipped frame";

        public static RequirementProperties Get(Def def)
        {
            return def.GetModExtension<RequirementProperties>();
        }
    }
}

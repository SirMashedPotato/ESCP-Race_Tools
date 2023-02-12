using Verse;

namespace ESCP_RaceTools
{
    public class GreyHairPatchProps : DefModExtension
    {
        public float minAgeForGreyHair = -1;

        public static GreyHairPatchProps Get(Def def)
        {
            return def.GetModExtension<GreyHairPatchProps>();
        }
    }
}

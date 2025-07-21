using Verse;

namespace ESCP_RaceTools
{
    public class PlantProperties : DefModExtension
    {

        //For plants that use the PlantBuildingPod class
        //Probably don't spawn something that is 'stuffed'. RimWorld will get angry, and find a default stuff thing
        public ThingDef matureInto = null;

        public static PlantProperties Get(Def def)
        {
            return def.GetModExtension<PlantProperties>();
        }
    }
}

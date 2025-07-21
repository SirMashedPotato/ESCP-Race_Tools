using System.Collections.Generic;
using Verse;

namespace ESCP_RaceTools
{
    //Yes I am aware of the typo in the name, it aint getting changed
    public class IdeoOrginProperties : DefModExtension
    {
        public bool IgnoreDuplicateDeityNames = true;   //ignores duplicate ideo deity names, kind self explanatory really
        public bool RandomiseDeityName = false; //Overrides some stuff and simply randomises the name AND type. Should only use if the origin is limited to one deity
        public bool RandomiseDeityType = false;  //Whether the deity type is randomised
                                                 //should only use this for origins that have one unique fixed deity, but multiple possible types
        public bool overrideDeityGenders = false;
        public List<Gender> deityGenders;
        public bool overrideDeityIcons = false;
        public List<string> iconPath;

        public static IdeoOrginProperties Get(Def def)
        {
            return def.GetModExtension<IdeoOrginProperties>();
        }
    }
}

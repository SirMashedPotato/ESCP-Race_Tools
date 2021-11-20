using System;
using System.Collections.Generic;
using System.Linq;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class IdeoOrginProperties : DefModExtension
    {
        public bool IgnoreDuplicateDeityNames = true;   //ignores duplicate ideo deity names, kind self explanatory really
        public bool RandomiseDeityName = false; //Overrides some stuff and simply randomises the name AND type. Should only use if the origin is limited to one deity
        public bool RandomiseDeityType = false;  //Whether the deity type is randomised
                                                 //should only use this for origins that have one unique fixed deity, but multiple possible types

        public static IdeoOrginProperties Get(Def def)
        {
            return def.GetModExtension<IdeoOrginProperties>();
        }
    }
}

using Verse;
using RimWorld;
using System.Collections.Generic;

namespace ESCP_RaceTools
{
    public class StuffKnowledge : DefModExtension
    {
        public List<Knowledge> stuffKnowledgeList;

        public static StuffKnowledge Get(Def def)
        {
            return def.GetModExtension<StuffKnowledge>();
        }
    }

    public class Knowledge
    {
        public List<string> stuffList;
        public List<SkillDef> skillList;
        public bool notJustStuff = false;   //if true: the ingrediant list for the recipe will also be checked for anything in stuffList
        public bool allOrNothing = true;    //if true: all specified trait, hediff, and backstory must be present
                                            //if false: only one of the specified trait, hediff or backstory must be present
                                            //any null trait, hediff and backstory are simply ignored either way
                                            //however make sure that atleast one of the required options is not null if allOrNothing is set to false
        public TraitDef requiredTrait = null;
        public HediffDef requiredHediff = null;
        public Backstory requiredBackstory = null;
        public float chance = 1f;
    }
}

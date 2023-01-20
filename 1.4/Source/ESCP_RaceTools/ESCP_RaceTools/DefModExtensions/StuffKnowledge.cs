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
        public List<SkillDef> skillList;    //only if crafting uses any specified skills in this list
        public bool notJustStuff = false;   //if true: the ingrediant list for the recipe will also be checked for anything in stuffList
        public HediffDef requiredHediff = null;
        public float chance = 1f;
    }
}

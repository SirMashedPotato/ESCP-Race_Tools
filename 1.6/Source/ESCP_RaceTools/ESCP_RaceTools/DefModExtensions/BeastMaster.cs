using Verse;
using System.Collections.Generic;

namespace ESCP_RaceTools
{
    public class BeastMaster : DefModExtension
    {
        //controls how many are spawned in
        public int maxNumberOfPawns = 5;
        public float maxTotalCombatPower = 120f;
        //list of strings for potential spawns
        public List<string> pawnKinds;
        //adds the specified hediff to any spawned pawns
        public HediffDef hediffToAdd;
        public float hediffToAddSeverity = 1f;
        //causes spawned animals to bond to the master, set to false if Humanlike races are potential spawns
        public bool bond = true;

        public static BeastMaster Get(Def def)
        {
            return def.GetModExtension<BeastMaster>();
        }
    }
}

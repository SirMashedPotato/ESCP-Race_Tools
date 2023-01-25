using System.Collections.Generic;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    public class RaceProperties : DefModExtension
    {
        //hypothermia
        public bool completeHypothermiaResistance = false;
        public bool hypothermiaResistant = false;   //just enables the hypothermia switch
        public bool frostbiteResistant = false;    //prevents any actual damage from the cold
        public HediffDef hypothermiaDef;
        //heatstroke
        public bool completeHeatstrokeResistance = false;
        public bool heatstrokeResistant = false;   //just enables the heatstroke switch
        public bool heatburnResistant = false;    //prevents any actual damage from the heat
        public HediffDef heatstrokeDef;
        //food poisoning
        public bool foodPoisoningResistant = false;
        //expectations
        public bool modifiedExpectations = false;
        public int expectationOffset = -1;
        //for death action worker give history event  rework to harmony patch
        public HistoryEventDef eventOnDeath;
        //disease immunity
        public bool immuneToAllDisease = false;
        public List<string> immuneDiseases;
        //starting hediffs, abilities TODO add harmony patch
        public List<HediffDef> hediffsToAdd;
        public List<AbilityDef> abilitiesToAdd;
        public List<AbilityDef> oneOfRandomAbility;
        public float oneOfRandomAbilityChance = 1f;
        //Biotech specific
        public List<GeneDef> genesToAdd;    //starting genes, need to patch in, does not work with MayRequire
        //additional gene/s that are 'inherited' from the father of the pawn
        //done seperately because can't may require lists in mod extensions ????
        public GeneDef majorRacialGeneToInherit;
        public GeneDef minorRacialGeneToInherit;
        //can't be turned into a sload thrall
        public bool sloadThrallImmune = false;
        public bool thrassianPlagueImmune = false;

        public static RaceProperties Get(Def def)
        {
            return def.GetModExtension<RaceProperties>();
        }
    }
}

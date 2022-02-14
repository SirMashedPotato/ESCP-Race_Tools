﻿using System;
using System.Collections.Generic;
using System.Linq;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class RaceProperties : DefModExtension
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
        //expectations
        public bool modifiedExpectations = false;
        public int expectationOffset = -1;
        //for death action worker give history event
        public HistoryEventDef eventOnDeath;
        //disease immunity
        public bool immuneToAlLDisease = false;
        public List<string> immuneDiseases;
        //can't be turned into a sload thrall
        public bool sloadThrallImmune = false;

        public static RaceProperties Get(Def def)
        {
            return def.GetModExtension<RaceProperties>();
        }
    }
}

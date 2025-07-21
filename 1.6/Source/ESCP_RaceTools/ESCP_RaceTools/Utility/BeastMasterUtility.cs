using System.Collections.Generic;
using Verse;
using Verse.AI;
using Verse.AI.Group;
using RimWorld;

namespace ESCP_RaceTools
{
    public static class BeastMasterUtility
    {
        public static List<Pawn> ReadyAdditionalSpawns(Pawn pawn)
        {
            List<Pawn> additonalPawns = new List<Pawn>();
            var modExt = BeastMaster.Get(pawn.kindDef);
            if (modExt.pawnKinds != null)
            {
                float currentCombatPower = 0f;
                int currentNumber = 0;
                while(currentCombatPower < modExt.maxTotalCombatPower && currentNumber < modExt.maxNumberOfPawns)
                {
                    Pawn newPawn;
                    PawnGenerationRequest request = new PawnGenerationRequest(PawnKindDef.Named(modExt.pawnKinds.RandomElement())) 
                    { 
                        Tile = pawn.Tile,
                        Faction = pawn.Faction,
                        Context = PawnGenerationContext.NonPlayer,
                        
                    };

                    newPawn = PawnGenerator.GeneratePawn(request);
                    GenSpawn.Spawn(newPawn, pawn.Position, pawn.Map);
                    /* additional checks */
                    if(modExt.bond && newPawn.AnimalOrWildMan())
                    {
                        newPawn.relations.AddDirectRelation(PawnRelationDefOf.Bond, pawn);
                    }
                    if (modExt.hediffToAdd != null)
                    {
                        newPawn.health.AddHediff(modExt.hediffToAdd).Severity = modExt.hediffToAddSeverity;
                    }
                    /* finalisation */
                    if (ESCP_RaceTools_ModSettings.BeastMasterLogging) Log.Message("Spawned " + newPawn + ", for master " + pawn + ", " + (modExt.maxTotalCombatPower - (newPawn.kindDef.combatPower + currentCombatPower)) + " combat power left");
                    if (newPawn.AnimalOrWildMan())
                    {
                        newPawn.health.AddHediff(HediffDefOf.ESCP_BeastMasterTraining, newPawn.health.hediffSet.GetBrain() != null ? newPawn.health.hediffSet.GetBrain() : null);
                    }
                    //newPawn.jobs.StartJob(new Job(JobDefOf.Follow, pawn, 1000000));
                    newPawn.mindState.duty = new PawnDuty(DutyDefOf.ESCP_EscortAndDefendMaster, pawn, 4);   //causes the pawn to follow and protect their master until one of them dies, in theory
                    additonalPawns.Add(newPawn);
                    currentCombatPower += newPawn.kindDef.combatPower;
                    currentNumber++;
                }
            }
            return additonalPawns;
        }

        public static void GiveLord(List<Pawn> pawns, Pawn master)
        {
            Lord lord = master.GetLord();
            foreach (Pawn p in pawns)
            {
                lord.AddPawn(p);
            }
        }

        public static void GiveDuty(List<Pawn> pawns, Pawn master)
        {
            foreach (Pawn p in pawns)
            {
                p.mindState.duty = new PawnDuty(DutyDefOf.ESCP_EscortAndDefendMaster, master, 4);
            }
        }

        public static void GiveMaster(List<Pawn> pawns, Pawn master)
        {
            foreach (Pawn p in pawns)
            {
                p.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.ESCP_BeastMasterTraining).TryGetComp<HediffComp_BeastMaster>().SetMaster(master);
            }
        }
    }
}

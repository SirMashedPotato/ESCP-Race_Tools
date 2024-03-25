using Verse;
using RimWorld;
using System.Linq;
using System.Collections.Generic;

namespace ESCP_Birthsigns_Abilities
{
    class StatPart_TheApprenticeNegation : StatPart
    {
        public override void TransformValue(StatRequest req, ref float val)
        {
            Pawn pawn;
            if ((pawn = (req.Thing as Pawn)) == null)
            {
                return;
            }
            val -= this.StatFactor(pawn);
        }

        public float StatFactor(Pawn pawn)
        {
            if (!hediffs.NullOrEmpty())
            {
                List<Hediff> hList = pawn.health.hediffSet.hediffs.Where(x => hediffs.Contains(x.def)).ToList();
                if (!hList.NullOrEmpty())
                {
                    float offset = 0;
                    foreach (Hediff h in hList)
                    {
                        if (pawn.def.statBases.Find(x => x.stat == StatDefOf.PsychicEntropyMax) != null)
                        {
                            offset += (negateOffset * pawn.def.statBases.Find(x => x.stat == StatDefOf.PsychicEntropyMax).value);
                        } 
                        else
                        {
                            offset += (StatDefOf.PsychicEntropyMax.defaultBaseValue * negateOffset);
                        }
                    }
                    return offset;
                }
            }
            return 0f;
        }

        public override string ExplanationPart(StatRequest req)
        {
            Pawn pawn;
            if (req.HasThing && (pawn = (req.Thing as Pawn)) != null)
            {
                return "ESCP_BirthSigns_StatsReport_NegatedApprenticeBonus".Translate() + (": " + this.StatFactor(pawn).ToString());
            }
            return null;
        }

        private float negateOffset = 0.5f;
        private List<HediffDef> hediffs;
    }
}

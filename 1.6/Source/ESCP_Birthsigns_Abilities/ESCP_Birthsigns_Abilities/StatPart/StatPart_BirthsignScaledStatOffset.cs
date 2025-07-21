using Verse;
using RimWorld;
using System.Linq;
using System.Collections.Generic;

namespace ESCP_Birthsigns_Abilities
{
    public class StatPart_BirthsignScaledStatOffset : StatPart
    {
        public override void TransformValue(StatRequest req, ref float val)
        {
            Pawn pawn;
            if ((pawn = (req.Thing as Pawn)) == null)
            {
                return;
            }
            val += this.StatFactor(pawn);
        }

        public float StatFactor(Pawn pawn)
        {
            if (!hediffs.NullOrEmpty())
            {
                List<Hediff> hList = pawn.health.hediffSet.hediffs.Where(x => hediffs.Contains(x.def)).ToList();
                if (!hList.NullOrEmpty())
                {
                    float offset = 0;
                    foreach(Hediff h in hList)
                    {
                        HediffComp_ScaledStatOffset comp = h.TryGetComp<HediffComp_ScaledStatOffset>();
                        offset += (baseFactor * (comp.Props.factor * pawn.skills.GetSkill(comp.Props.skillDef).Level));
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
                return "ESCP_BirthSigns_StatsReport_ScaledStatOffset".Translate() + (": " + this.StatFactor(pawn).ToString());
            }
            return null;
        }

        public override IEnumerable<string> ConfigErrors()
        {
            foreach (string text in base.ConfigErrors())
            {
                yield return text;
            }
            if (hediffs.NullOrEmpty())
            {
                yield return "hediff list is null or empty";
            }
            //listed hediff doesn't have comp
        }

        private float baseFactor = 1f;
        private List<HediffDef> hediffs;
    }
}

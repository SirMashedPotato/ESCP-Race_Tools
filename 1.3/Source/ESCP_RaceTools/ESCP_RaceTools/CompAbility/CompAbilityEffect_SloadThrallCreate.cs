using System;
using Verse;
using RimWorld;
using System.Linq;
using System.Collections.Generic;

namespace ESCP_RaceTools
{
    class CompAbilityEffect_SloadThrallCreate : CompAbilityEffect
    {
        public new CompProperties_SloadThrallCreate Props
        {
            get
            {
                return (CompProperties_SloadThrallCreate)this.props;
            }
        }

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            Thing t = target.Thing;
            if(t != null && t is Corpse c)
            {
                Pawn p = c.InnerPawn;
                ResurrectionUtility.Resurrect(c.InnerPawn);
                if(Props.hediff != null)
                {
                    p.health.AddHediff(Props.hediff);
                    p.health.hediffSet.GetFirstHediffOfDef(Props.hediff).TryGetComp<HediffComp_SloadThrall>().SetMaster(parent.pawn);   //TODO change to seoerate comp
                }
                p.SetFaction(parent.pawn.Faction, parent.pawn);
                if (ModsConfig.IdeologyActive && p.RaceProps.Humanlike)
                {
                    p.ideo.SetIdeo(parent.pawn.Ideo);
                }
                parent.pawn.GetComp<Comp_SloadThralls>().AddThrall(p);
            }
        }

        public override bool GizmoDisabled(out string reason)
        {
            if (Props.disablerPrecept != null && ModsConfig.IdeologyActive)
            {
                if (parent.pawn.ideo.Ideo.PreceptsListForReading.Where(x => x.def.defName == Props.disablerPrecept).Any())
                {
                    reason = "ESCP_SloadThrall_PreceptDisabled".Translate();
                    return true;
                }
            }

            int limit = CurrentLimit(parent.pawn);
            int count = parent.pawn.GetComp<Comp_SloadThralls>().ThrallCount();
            if (limit <= count)
            {
                reason = "ESCP_SloadThrall_LimitReached".Translate(limit);
                return true;
            }
            return base.GizmoDisabled(out reason);
        }

        public override string ExtraTooltipPart()
        {
            string extra = "";
            Pawn p = parent.pawn;
            int limit = CurrentLimit(p);
            int count = p.GetComp<Comp_SloadThralls>().ThrallCount();
            int skillLevel = p.skills.GetSkill(Props.skill != null ? Props.skill : SkillDefOf.Intellectual).Level;

            extra += "ESCP_SloadThrall_ExtraTooltip_Count".Translate(count, limit);
            if (skillLevel != 20)
            {
                extra += GetTooltipExtra_Limit(p, skillLevel);
            }

            return extra;
        }

        public string GetTooltipExtra_Limit(Pawn p, int curLevel)
        {
            int index = 0;

            for (int i = 0; i < Props.levelRequirement.Count; i++)
            {
                if (Props.levelRequirement[i] <= curLevel)
                {
                    index = i+1;
                }
            }
            if (index+1 != Props.levelRequirement.Count())
            {
                return "ESCP_SloadThrall_ExtraTooltip_Limit".Translate(Props.thrallLimit[index] - Props.thrallLimit[index - 1], Props.levelRequirement[index], Props.skill != null ? Props.skill.label : SkillDefOf.Intellectual.label);
            }
            return "";
        }

        public int CurrentLimit(Pawn p)
        {
            int curLevel = p.skills.GetSkill(Props.skill != null ? Props.skill : SkillDefOf.Intellectual).Level;
            int index = 0;
            for (int i = 0; i < Props.levelRequirement.Count; i++)
            {
                if(Props.levelRequirement[i] <= curLevel)
                {
                    index = i;
                }
            }
            return Props.thrallLimit[index];
        }
    }
}

using RimWorld;
using System.Collections.Generic;
using Verse;
using UnityEngine;

namespace ESCP_RaceTools
{
	class Comp_BeserkerRage : ThingComp
	{
		public CompProperties_BeserkerRage Props
		{
			get
			{
				return (CompProperties_BeserkerRage)this.props;
			}
		}

        public override void PostPostApplyDamage(DamageInfo dinfo, float totalDamageDealt)
        {
            base.PostPostApplyDamage(dinfo, totalDamageDealt);
			Pawn pawn = parent as Pawn;
			if ( pawn.health.hediffSet.PainTotal >= 0.6 && PawnIsValid(pawn))
			{
				if (pawn.Faction == null && !pawn.AnimalOrWildMan()) return;
				ActivateRage(pawn);
			}
		}

        public override IEnumerable<Gizmo> CompGetGizmosExtra()
        {
			foreach (Gizmo gizmo in base.CompGetGizmosExtra())
			{
				yield return gizmo;
			}

			Pawn pawn = parent as Pawn;
			if (PawnIsValid(pawn) && pawn.Faction != null && pawn.Faction.IsPlayer && !pawn.NonHumanlikeOrWildMan())
            {
                if (pawn.skills.GetSkill(Props.manualSkill ?? SkillDefOf.Melee).Level >= Props.manualSkillLevel)
                {
					yield return new Command_Action
					{
						defaultLabel = "ESCP_EnterBeserkRage".Translate(),
						defaultDesc = "ESCP_EnterBeserkRageTooltip".Translate(),
						icon = ContentFinder<Texture2D>.Get("UI/Gizmos/ESCP_BeserkerRage", true),
						disabled = !CheckRage(pawn),
						disabledReason = "ESCP_EnterBeserkRageCooldown".Translate(),
						action = delegate ()
						{
							ActivateRage(pawn);
						}
					};
				}
            }
		}

		public bool CheckRage(Pawn pawn)
		{
			if (!pawn.health.hediffSet.HasHediff(Props.hediffDef))
			{
				if (pawn.health.hediffSet.hediffs.Any(x => Props.augments.Contains(x.def)))
				{
					return false;
				}
				return true;
			}
			return false;
		}

        public void ActivateRage(Pawn pawn)
        {
			if (Props.enableAugments)
			{
				if (!pawn.health.hediffSet.HasHediff(Props.hediffDef))
				{
					if (!pawn.health.hediffSet.hediffs.Any(x => Props.augments.Contains(x.def)))
					{
						for (int i = 0; i != Props.totems.Count; i++)
						{
							if (pawn.apparel.WornApparel.Any(x => x.def == Props.totems[i]))
							{
								pawn.health.AddHediff(Props.augments[i]).Severity = 1;
								IncrementRedord(pawn);
								return;
							}
						}
						pawn.health.AddHediff(Props.hediffDef).Severity = 1f;

						IncrementRedord(pawn);
						return;
					}
				}

			}
			else
			{
				if (!pawn.health.hediffSet.HasHediff(Props.hediffDef))
				{
					pawn.health.AddHediff(Props.hediffDef).Severity = 1f;
					IncrementRedord(pawn);
				}
			}
		}

		public void ResetRage(Pawn pawn)
		{
			Hediff hediff = pawn.health.hediffSet.GetFirstHediffOfDef(Props.hediffDef);
            if (hediff != null)
            {
				hediff.Severity = 1f;
				return;
            }
			if (Props.enableAugments)
			{
                foreach (HediffDef h in Props.augments)
                {
					hediff = pawn.health.hediffSet.GetFirstHediffOfDef(h);
					if (hediff != null)
					{
						hediff.Severity = 1f;
						return;
					}
				}
			}
		}

		private static bool PawnIsValid(Pawn p)
		{
			return p.Spawned && !p.Position.Fogged(p.Map);
		}

		private void IncrementRedord(Pawn pawn)
		{
			if (Props.enableTracker && Props.recordDef != null)
			{
				pawn.records.Increment(Props.recordDef);
			}
		}

	}
}

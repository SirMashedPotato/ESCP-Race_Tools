using RimWorld;
using Verse;

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

		public override void CompTick()
		{
			base.CompTick();
			Pawn pawn = this.parent as Pawn;
			//check
			if (/*pawn.health.hediffSet.HasHediff(RimWorld.HediffDefOf.BloodLoss) &&*/ pawn.health.hediffSet.PainTotal >= 0.6 && PawnIsValid(pawn))
			{
				//check if pawn is likely a rescue target, then return
				if (pawn.Faction == null && !pawn.AnimalOrWildMan()) return;
				//do beserker
				if (Props.enableAugments)
				{
					//enables belts for 1.2
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

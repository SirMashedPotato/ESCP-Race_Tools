using System;
using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;

namespace ESCP_RaceTools
{
    public class HediffComp_GiveHediffsInRange : HediffComp
    {
		public HediffCompProperties_GiveHediffsInRange Props
		{
			get
			{
				return (ESCP_RaceTools.HediffCompProperties_GiveHediffsInRange)this.props;
			}
		}

		public override void CompPostTick(ref float severityAdjustment)
		{
			if (!this.parent.pawn.Awake() || this.parent.pawn.health == null || this.parent.pawn.health.InPainShock || !this.parent.pawn.Spawned)
			{
				return;
			}
			if (!this.Props.hideMoteWhenNotDrafted || this.parent.pawn.Drafted)
			{
				if (this.Props.mote != null && (this.mote == null || this.mote.Destroyed))
				{
					this.mote = MoteMaker.MakeAttachedOverlay(this.parent.pawn, this.Props.mote, Vector3.zero, 1f, -1f);
				}
				if (this.mote != null)
				{
					this.mote.Maintain();
				}
			}
			List<Pawn> list;
			if (this.Props.onlyPawnsInSameFaction && this.parent.pawn.Faction != null)
			{
				list = this.parent.pawn.Map.mapPawns.PawnsInFaction(this.parent.pawn.Faction);
			}
			else
			{
				list = this.parent.pawn.Map.mapPawns.AllPawns;
			}
			foreach (Pawn pawn in list)
			{
				if (((Props.allowAnimals && !pawn.RaceProps.IsMechanoid) || (!Props.allowAnimals && pawn.RaceProps.Humanlike)) && !pawn.Dead && pawn.health != null && pawn != this.parent.pawn && pawn.Position.DistanceTo(this.parent.pawn.Position) <= this.Props.range && this.Props.targetingParameters.CanTarget(pawn, null))
				{
					Hediff hediff = pawn.health.hediffSet.GetFirstHediffOfDef(this.Props.hediff, false);
					if (hediff == null)
					{
						hediff = pawn.health.AddHediff(this.Props.hediff, pawn.health.hediffSet.GetBrain(), null, null);
						hediff.Severity = this.Props.initialSeverity;
						HediffComp_Link hediffComp_Link = hediff.TryGetComp<HediffComp_Link>();
						if (hediffComp_Link != null)
						{
							hediffComp_Link.drawConnection = true;
							hediffComp_Link.other = this.parent.pawn;
						}
					}
					HediffComp_Disappears hediffComp_Disappears = hediff.TryGetComp<HediffComp_Disappears>();
					if (hediffComp_Disappears == null)
					{
						Log.Error("HediffComp_GiveHediffsInRange has a hediff in props which does not have a HediffComp_Disappears");
					}
					else
					{
						hediffComp_Disappears.ticksToDisappear = 5;
					}
				}
			}
		}

		private Mote mote;
	}
}

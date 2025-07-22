using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;

namespace ESCP_RaceTools
{
	/// <summary>
	/// Basically the exact same, but can affect animals
	/// </summary>
    public class HediffComp_GiveHediffsInRange : HediffComp
    {
		public HediffCompProperties_GiveHediffsInRange Props => (HediffCompProperties_GiveHediffsInRange)props;

		public override void CompPostTick(ref float severityAdjustment)
		{
			if (!parent.pawn.Awake() || parent.pawn.health == null || parent.pawn.health.InPainShock || !parent.pawn.Spawned)
			{
				return;
			}
			if (!Props.hideMoteWhenNotDrafted || parent.pawn.Drafted)
			{
				if (Props.mote != null && (mote == null || mote.Destroyed))
				{
					mote = MoteMaker.MakeAttachedOverlay(parent.pawn, Props.mote, Vector3.zero, 1f, -1f);
				}
				mote?.Maintain();
			}
			List<Pawn> list;
			if (Props.onlyPawnsInSameFaction && parent.pawn.Faction != null)
			{
				list = parent.pawn.Map.mapPawns.PawnsInFaction(parent.pawn.Faction);
			}
			else
			{
				list = parent.pawn.Map.mapPawns.AllPawns;
			}
			foreach (Pawn pawn in list)
			{
				if (((Props.allowAnimals && !pawn.RaceProps.IsMechanoid) || (!Props.allowAnimals && pawn.RaceProps.Humanlike)) && !pawn.Dead && pawn.health != null && pawn != parent.pawn && pawn.Position.DistanceTo(parent.pawn.Position) <= Props.range && Props.targetingParameters.CanTarget(pawn, null))
				{
					Hediff hediff = pawn.health.hediffSet.GetFirstHediffOfDef(Props.hediff, false);
					if (hediff == null)
					{
						hediff = pawn.health.AddHediff(Props.hediff, pawn.health.hediffSet.GetBrain(), null, null);
						hediff.Severity = Props.initialSeverity;
						HediffComp_Link hediffComp_Link = hediff.TryGetComp<HediffComp_Link>();
						if (hediffComp_Link != null)
						{
							hediffComp_Link.drawConnection = true;
							hediffComp_Link.other = parent.pawn;
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

﻿using HarmonyLib;
using RimWorld;
using Verse;
using UnityEngine;
using Verse.AI.Group;

namespace ESCP_RaceTools
{
	public static class HeatstrokeSwitchPatch
	{
		/// <summary>
		/// Patch that can prevent specific races from recieving heatstroke
		/// Can also give a different hediff instead
		/// </summary>
		[HarmonyPatch(typeof(HediffGiver_Heat))]
		[HarmonyPatch("OnIntervalPassed")]
		public static class HediffGiver_Heat_OnIntervalPassed_Patch
		{
			[HarmonyPrefix]
			public static bool HeatstrokePatch(Pawn pawn)
			{
				if (ESCP_RaceTools_ModSettings.EnableHeatstrokeSwitch)
				{
					var props = RaceProperties.Get(pawn.def);
					if (props != null) 
					{
						if (props.completeHeatstrokeResistance) 
						{
							return false;
						}
						if (props.heatburnResistant && props.heatstrokeDef != null)
                        {
							OnIntervalPassed(pawn, props.heatstrokeDef, props.heatburnResistant);
							return false;
						}
					}
				}
				return true;
			}
		}

		/// <summary>
		/// Effectively the same base functionality as HediffGiver_Heat.OnIntervalPassed
		/// but uses a different hediff instead
		/// </summary>
		public static void OnIntervalPassed(Pawn pawn, HediffDef hediffDef, bool resistDamage)
		{
			float ambientTemperature = pawn.AmbientTemperature;
			FloatRange floatRange = pawn.ComfortableTemperatureRange();
			FloatRange floatRange2 = pawn.SafeTemperatureRange();
			Hediff firstHediffOfDef = pawn.health.hediffSet.GetFirstHediffOfDef(hediffDef, false);
			if (ambientTemperature > floatRange2.max)
			{
				float num = ambientTemperature - floatRange2.max;
				num = HediffGiver_Heat.TemperatureOverageAdjustmentCurve.Evaluate(num);
				float num2 = num * 6.45E-05f;
				num2 = Mathf.Max(num2, 0.000375f);
				HealthUtility.AdjustSeverity(pawn, hediffDef, num2);
			}
			else if (firstHediffOfDef != null && ambientTemperature < floatRange.max)
			{
				float num3 = firstHediffOfDef.Severity * 0.027f;
				num3 = Mathf.Clamp(num3, 0.0015f, 0.015f);
				firstHediffOfDef.Severity -= num3;
			}
			if (pawn.Dead)
			{
				return;
			}
			if (!resistDamage && pawn.IsNestedHashIntervalTick(60, BurnCheckInterval))
			{
				float num4 = floatRange.max + 150f;
				if (ambientTemperature > num4)
				{
					float num5 = ambientTemperature - num4;
					num5 = HediffGiver_Heat.TemperatureOverageAdjustmentCurve.Evaluate(num5);
					int num6 = Mathf.Max(GenMath.RoundRandom(num5 * 0.06f), 3);
					DamageInfo dinfo = new DamageInfo(DamageDefOf.Burn, num6, 0f, -1f, null, null, null, DamageInfo.SourceCategory.ThingOrUnknown, null, true, true);
					dinfo.SetBodyRegion(BodyPartHeight.Undefined, BodyPartDepth.Outside);
					pawn.TakeDamage(dinfo);
					if (pawn.Faction == Faction.OfPlayer)
					{
						Find.TickManager.slower.SignalForceNormalSpeed();
						if (MessagesRepeatAvoider.MessageShowAllowed("PawnBeingBurned", 60f))
						{
							Messages.Message("MessagePawnBeingBurned".Translate(pawn.LabelShort, pawn), pawn, MessageTypeDefOf.ThreatSmall, true);
						}
					}
					Lord lord = pawn.GetLord();
					if (lord != null)
					{
						lord.ReceiveMemo(HediffGiver_Heat.MemoPawnBurnedByAir);
					}
				}
			}
		}

		private const int BurnCheckInterval = 420;
	}
}

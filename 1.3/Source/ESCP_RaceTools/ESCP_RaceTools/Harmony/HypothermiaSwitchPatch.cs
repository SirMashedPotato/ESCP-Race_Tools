using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;
using System.Linq;
using UnityEngine;

namespace ESCP_RaceTools
{
    public static class HypothermiaSwitchPatch
    {
        /*
         * Patch that prevents certain races from gaining hypothermia, and instead gives them hypothermic slowdown
         */
        [HarmonyPatch(typeof(HediffGiver_Hypothermia))]
        [HarmonyPatch("OnIntervalPassed")]
        public static class HediffGiver_Hypothermia_OnIntervalPassed_Patch
        {
            [HarmonyPrefix]
            public static bool HypothermiaPatch(Pawn pawn, Hediff cause)
            {
                if (ModSettingsUtility.ESCP_RaceTools_EnableHypothermiaSwitch())
                {
                    var props = RaceProperties.Get(pawn.def);
					if (props != null)
					{
						if (props.completeHypothermiaResistance) return false;
						if (props.hypothermiaResistant && props.hypothermiaDef != null)
						{
							OnIntervalPassed(pawn, props.hypothermiaDef, props.frostbiteResistant);
							return false;
						}
					}
                }
                return true;
            }
        }

		public static void OnIntervalPassed(Pawn pawn, HediffDef hediffDef, bool resistDamage)
		{
			float ambientTemperature = pawn.AmbientTemperature;
			FloatRange floatRange = pawn.ComfortableTemperatureRange();
			FloatRange floatRange2 = pawn.SafeTemperatureRange();
			HediffSet hediffSet = pawn.health.hediffSet;
			Hediff firstHediffOfDef = hediffSet.GetFirstHediffOfDef(hediffDef, false);
			if (ambientTemperature < floatRange2.min)
			{
				float num = Mathf.Abs(ambientTemperature - floatRange2.min) * 6.45E-05f;
				num = Mathf.Max(num, 0.00075f);
				HealthUtility.AdjustSeverity(pawn, hediffDef, num);
				if (pawn.Dead)
				{
					return;
				}
			}
			if (firstHediffOfDef != null)
			{
				if (ambientTemperature > floatRange.min)
				{
					float num2 = firstHediffOfDef.Severity * 0.027f;
					num2 = Mathf.Clamp(num2, 0.0015f, 0.015f);
					firstHediffOfDef.Severity -= num2;
					return;
				}
				if (!resistDamage && ambientTemperature < 0f && firstHediffOfDef.Severity > 0.37f)
				{
					float num3 = 0.025f * firstHediffOfDef.Severity;
					if (Rand.Value < num3)
					{
						BodyPartRecord bodyPartRecord;
						if ((from x in pawn.RaceProps.body.AllPartsVulnerableToFrostbite
							 where !hediffSet.PartIsMissing(x)
							 select x).TryRandomElementByWeight((BodyPartRecord x) => x.def.frostbiteVulnerability, out bodyPartRecord))
						{
							int num4 = Mathf.CeilToInt((float)bodyPartRecord.def.hitPoints * 0.5f);
							DamageInfo dinfo = new DamageInfo(DamageDefOf.Frostbite, (float)num4, 0f, -1f, null, bodyPartRecord, null, DamageInfo.SourceCategory.ThingOrUnknown, null, true, true);
							pawn.TakeDamage(dinfo);
						}
					}
				}
			}
		}
	}
}

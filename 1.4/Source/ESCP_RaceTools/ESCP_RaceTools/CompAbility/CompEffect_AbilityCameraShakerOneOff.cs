using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using Verse.Sound;
using RimWorld;

namespace ESCP_RaceTools
{
    public class CompEffect_AbilityCameraShakerOneOff : CompAbilityEffect
	{
		public new CompProperties_AbilityEffectCameraShakerOneOff Props
		{
			get
			{
				return (CompProperties_AbilityEffectCameraShakerOneOff)this.props;
			}
		}

		public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
		{
			if (this.Props.preCastTicks <= 0)
			{
				this.DoShake(target);
			}
		}

		public override IEnumerable<PreCastAction> GetPreCastActions()
		{
			if (this.Props.preCastTicks > 0)
			{
				yield return new PreCastAction
				{
					action = delegate (LocalTargetInfo t, LocalTargetInfo d)
					{
						this.DoShake(t);
					},
					ticksAwayFromCast = this.Props.preCastTicks
				};
			}
			yield break;
		}

		public void DoShake(LocalTargetInfo t)
        {
			if (t.Pawn.Map != null && t.Pawn.Map == Find.CurrentMap)
			{
				Find.CameraDriver.shaker.SetMinShake(this.Props.mag);
			}
		}
	}
}

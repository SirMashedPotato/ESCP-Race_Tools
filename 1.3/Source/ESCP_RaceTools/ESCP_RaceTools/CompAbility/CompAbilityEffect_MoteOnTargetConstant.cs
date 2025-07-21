using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using Verse.Sound;
using RimWorld;

namespace ESCP_RaceTools
{
    class CompAbilityEffect_MoteOnTargetConstant : CompAbilityEffect
    {
		public new CompProperties_AbilityMoteOnTargetConstant Props
		{
			get
			{
				return (CompProperties_AbilityMoteOnTargetConstant)this.props;
			}
		}

		public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
		{
			if (true)
			{
				SoundDef sound = this.Props.sound;
				if (sound != null)
				{
					sound.PlayOneShot(new TargetInfo(target.Cell, this.parent.pawn.Map, false));
				}
				this.SpawnAll(target);
			}
		}

		public override IEnumerable<PreCastAction> GetPreCastActions()
		{
			float time = parent.def.verbProperties.warmupTime;
			float count = time / 5f;
			
			for (int i = 0; i < count; i++)
			{
				Log.Message("nnnnnnnoooooooooooo: " + i);
				yield return new PreCastAction
				{
					action = delegate (LocalTargetInfo t, LocalTargetInfo d)
					{
						Log.Message("aaaaaahhhhhhhhhhh: " + i);
						this.SpawnAll(t);
						SoundDef sound = this.Props.sound;
						if (sound == null)
						{
							return;
						}
						sound.PlayOneShot(new TargetInfo(t.Cell, this.parent.pawn.Map, false));
					}, 
					ticksAwayFromCast = 5 * i
				};
			}
			yield break;
		}

		private void SpawnAll(LocalTargetInfo target)
		{
			if (!this.Props.moteDefs.NullOrEmpty<ThingDef>())
			{
				for (int i = 0; i < this.Props.moteDefs.Count; i++)
				{
					this.SpawnMote(target, this.Props.moteDefs[i]);
				}
				return;
			}
			this.SpawnMote(target, this.Props.moteDef);
		}

		private void SpawnMote(LocalTargetInfo target, ThingDef def)
		{
			if (target.HasThing)
			{
				MoteMaker.MakeAttachedOverlay(target.Thing, def, Vector3.zero, this.Props.scale, -1f);
				return;
			}
			MoteMaker.MakeStaticMote(target.Cell, this.parent.pawn.Map, def, this.Props.scale);
		}
	}
}

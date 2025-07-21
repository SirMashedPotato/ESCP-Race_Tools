using RimWorld;
using Verse;
using Verse.Sound;

namespace ESCP_RaceTools
{
	class Comp_DunmerGraveWhisper : ThingComp
	{
		public CompProperties_DunmerGraveWhisper Props
		{
			get
			{
				return (CompProperties_DunmerGraveWhisper)this.props;
			}
		}

		public int nextTicks = 5;
		public int ticks = 0;

		public override void PostExposeData()
		{
			base.PostExposeData();
			Scribe_Values.Look(ref ticks, "ESCP_DunmerGraveWhisper_Ticks", 1, false);
		}

		public override void CompTickRare()
        {
            base.CompTickRare();

            if (!ESCP_RaceTools_ModSettings.DunmerGraveWhispering)
            {
				return;
            }
			if (ticks >= nextTicks && parent != null && parent.Map != null && Props.soundDef != null && Rand.Chance(Props.chance))
            {
                if (Props.onlyFull && parent is Building_Grave)
                {
					Building_Grave pit = parent as Building_Grave;
					if (!pit.HasCorpse)
					{
						return;
					}
				}
				SoundDef sound = Props.soundDef;
				sound.PlayOneShot(new TargetInfo(parent.Position, parent.Map, false));
				ticks = 0;
			}
			ticks++;
        }
    }
}
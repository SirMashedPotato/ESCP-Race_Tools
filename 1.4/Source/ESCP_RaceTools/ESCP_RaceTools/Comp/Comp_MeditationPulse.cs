using RimWorld;
using Verse;
using UnityEngine;

namespace ESCP_RaceTools
{
    class Comp_MeditationPulse : ThingComp
	{
		public CompProperties_MeditationPulse Props
		{
			get
			{
				return (CompProperties_MeditationPulse)props;
			}
		}

		public int ticks = 0;

		public override void PostExposeData()
		{
			base.PostExposeData();
            Scribe_Values.Look(ref ticks, "ESCP_Comp_MeditationPulse_Ticks", 1, false);
		}

		public override void CompTick()
        {
            base.CompTick();
			if(ticks++ >= Props.ticksBetween && parent.Spawned && parent.Map != null)
            {
				Pawn p = parent as Pawn;
                if (!p.Dead && p.Faction != null && p.Faction == Faction.OfPlayer)
                {
					DoPulse(p);
					ticks = 0;
				}
			}
        }

		public void DoPulse(Pawn p)
        {
			foreach (Thing t in GenRadial.RadialDistinctThingsAround(p.Position, p.Map, Props.radius, true))
			{
				if(t is Pawn target)
                {
					if(target.IsColonist)
                    {
						if(target.psychicEntropy != null && Props.focusDef.CanPawnUse(target))
                        {
							target.psychicEntropy.OffsetPsyfocusDirectly(Props.amount);
						}
                    }
                }
			}
			if (Props.fleck != null)
			{
				FleckMaker.AttachedOverlay(parent, Props.fleck, Vector3.zero, 1f, 1f);
			}

		}
	}
}

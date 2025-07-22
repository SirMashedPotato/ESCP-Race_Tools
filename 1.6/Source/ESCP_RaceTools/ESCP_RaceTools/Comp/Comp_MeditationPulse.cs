using RimWorld;
using Verse;
using UnityEngine;

namespace ESCP_RaceTools
{
    class Comp_MeditationPulse : ThingComp
	{
		public CompProperties_MeditationPulse Props => (CompProperties_MeditationPulse)props;

        public override void CompTickInterval(int delta)
        {
            base.CompTickInterval(delta);
			if (parent.IsHashIntervalTick(Props.ticksBetween, delta))
			{
				if (!parent.Spawned && parent.Map == null)
				{
					return;
				}

				Pawn p = parent as Pawn;
				if (!p.Dead && p.Faction != null && p.Faction == Faction.OfPlayer)
				{
					DoPulse(p);
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

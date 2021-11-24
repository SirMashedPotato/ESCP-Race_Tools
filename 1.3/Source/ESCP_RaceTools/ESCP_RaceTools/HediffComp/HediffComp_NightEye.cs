using System;
using RimWorld;
using Verse;

namespace ESCP_RaceTools
{
    class HediffComp_NightEye : HediffComp
	{
		public HediffCompProperties_NightEye Props
		{
			get
			{
				return (HediffCompProperties_NightEye)this.props;
			}
		}

		private int ticksUntil = 0;
		private readonly int ticks = 25;

        public override void CompPostTick(ref float severityAdjustment)
        {
            if (ticksUntil >= ticks)
            {
				Pawn pawn = this.Pawn;
				if (pawn.Spawned && !pawn.Dead && !pawn.Position.Fogged(pawn.Map))
				{
					if (pawn.Map.glowGrid.GameGlowAt(pawn.Position) <= Props.lightLevelRequired && parent.Severity != 1.0f)
					{
						parent.Severity = 1.0f;
						ticksUntil = 0;
						return;
					}
					if (pawn.Map.glowGrid.GameGlowAt(pawn.Position) > Props.lightLevelRequired && parent.Severity == 1.0f)
					{
						parent.Severity = 0.5f;
						ticksUntil = 0;
						return;
					}
				}
			}
			ticksUntil++;
        }
    }
}

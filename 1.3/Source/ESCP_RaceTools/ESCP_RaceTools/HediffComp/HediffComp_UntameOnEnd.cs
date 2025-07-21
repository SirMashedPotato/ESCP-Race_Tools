using System;
using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.AI;
using RimWorld.Planet;

namespace ESCP_RaceTools
{
    class HediffComp_UntameOnEnd : HediffComp
    {
		public HediffCompProperties_UntameOnEnd Props
		{
			get
			{
				return (HediffCompProperties_UntameOnEnd)this.props;
			}
		}

        public override void CompPostPostRemoved()
        {
			if(parent.pawn != null && !parent.pawn.Dead)
            {
				Pawn pawn = parent.pawn;
                if (Props.untame)
                {
					pawn.SetFaction(null, null);
					Pawn_Ownership ownership = pawn.ownership;
					if (ownership != null)
					{
						ownership.UnclaimAll();
					}
				}
				Messages.Message("MessageAnimalReturnedWildReleased".Translate(pawn.LabelShort, pawn), pawn, MessageTypeDefOf.NeutralEvent, true);
			}
		}
    }
}

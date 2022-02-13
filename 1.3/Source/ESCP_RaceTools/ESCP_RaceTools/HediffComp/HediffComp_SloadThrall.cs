using RimWorld;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Verse;

namespace ESCP_RaceTools
{
    class HediffComp_SloadThrall : HediffComp
	{
		public Pawn Master
		{
			get
			{
				return this.master;
			}
		}

		public void SetMaster(Pawn p)
		{
			if (p != null)
			{
				this.master = p;
			}
		}

		public override void CompExposeData()
		{
			base.CompExposeData();
			Scribe_References.Look(ref this.master, "master", false);
		}

        public override void Notify_PawnDied()
        {
			master.GetComp<Comp_SloadThralls>().RemoveThrall(base.Pawn);
			base.Notify_PawnDied();
			base.Pawn.health.RemoveHediff(this.parent);
		}

        public override IEnumerable<Gizmo> CompGetGizmos()
        {
			yield return new Command_Action
			{
				defaultLabel = "ESCP_SloadThrall_KillThrall".Translate(),
				defaultDesc = "ESCP_SloadThrall_KillThrall_Tooltip".Translate(this.master.Name),
				icon = ContentFinder<Texture2D>.Get("UI/Gizmos/ESCP_SloadDisbandThrall", true),
				action = delegate ()
				{
					this.Pawn.Kill(null);
				}
			};
        }

        public override string CompLabelInBracketsExtra => master != null ? master.Name.ToString() : null;

		private Pawn master = null;
	}
}

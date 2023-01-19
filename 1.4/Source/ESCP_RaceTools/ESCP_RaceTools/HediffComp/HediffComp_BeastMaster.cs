using RimWorld;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Verse;
using Verse.AI;
using Verse.AI.Group;

namespace ESCP_RaceTools
{
    class HediffComp_BeastMaster : HediffComp
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

        public override string CompLabelInBracketsExtra => master != null? master.Name.ToString() : null;

        private Pawn master = null;
	}
}

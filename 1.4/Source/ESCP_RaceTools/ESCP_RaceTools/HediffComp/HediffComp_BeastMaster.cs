using Verse;

namespace ESCP_RaceTools
{
    class HediffComp_BeastMaster : HediffComp
    {
		public Pawn Master
		{
			get
			{
				return master;
			}
		}

		public void SetMaster(Pawn p)
		{
			if (p != null)
            {
				master = p;
			}
		}

        public override void CompExposeData()
        {
            base.CompExposeData();
			Scribe_References.Look(ref master, "master", false);
		}

        public override string CompLabelInBracketsExtra => master != null? master.Name.ToString() : null;

        private Pawn master = null;
	}
}

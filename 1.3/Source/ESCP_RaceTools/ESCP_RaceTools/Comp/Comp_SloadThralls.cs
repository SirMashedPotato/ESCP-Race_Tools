using System;
using Verse;
using RimWorld;
using System.Linq;
using System.Collections.Generic;

namespace ESCP_RaceTools
{
    class Comp_SloadThralls : ThingComp
    {
        public List<Pawn> thralls = new List<Pawn>();

        public CompProperties_SloadThralls Props
        {
            get
            {
                return (CompProperties_SloadThralls)this.props;
            }
        }

        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Collections.Look(ref thralls, "ESCP_SloadThralls", LookMode.Reference);
        }

        public int ThrallCount()
        {
            return thralls.NullOrEmpty() ? 0 : thralls.Count();
        }

        public void AddThrall(Pawn pawn)
        {
            thralls.Add(pawn);
        }

        public void RemoveThrall(Pawn pawn)
        {
            thralls.Remove(pawn);
        }

        public void KillThralls()
        {
            for(int i = 0; i < thralls.Count; i++)
            {
                thralls[i].Kill(null);
            }
        }

        public override void CompTick()
        {
            base.CompTick();

            Pawn p = this.parent as Pawn;
            if (p.Downed)
            {
                KillThralls();
            }

        }
    }
}

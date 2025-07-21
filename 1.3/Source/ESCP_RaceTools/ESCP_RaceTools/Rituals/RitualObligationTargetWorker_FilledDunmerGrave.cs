using System;
using System.Collections.Generic;
using System.Linq;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class RitualObligationTargetWorker_FilledDunmerGrave : RitualObligationTargetFilter
    {
        public RitualObligationTargetWorker_FilledDunmerGrave()
        {
        }

        public RitualObligationTargetWorker_FilledDunmerGrave(RitualObligationTargetFilterDef def) : base(def)
		{
        }

        public override IEnumerable<string> GetTargetInfos(RitualObligation obligation)
        {
            yield return "ESCP_DunmerRitualTargetSeanceInfo".Translate(this.parent.ideo.Named("IDEO"));
            yield break;
        }

        public override IEnumerable<TargetInfo> GetTargets(RitualObligation obligation, Map map)
        {
            Thing thing = map.listerThings.ThingsInGroup(ThingRequestGroup.Grave).FirstOrDefault((Thing t) => ((Building_Grave)t).Corpse == obligation.targetA.Thing);
            if (thing != null)
            {
                if(thing.TryGetComp<Comp_DunmerGraveWhisper>() != null)
                {
                    yield return thing;
                }
            }
            yield break;
        }

        protected override RitualTargetUseReport CanUseTargetInternal(TargetInfo target, RitualObligation obligation)
        {
            Building_Grave building_Grave;
            return target.HasThing && (building_Grave = (target.Thing as Building_Grave)) != null && building_Grave.Corpse != null && building_Grave.TryGetComp<Comp_DunmerGraveWhisper>() != null;
        }
    }
}

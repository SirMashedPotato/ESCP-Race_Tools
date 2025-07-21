using RimWorld;
using System.Collections.Generic;
using Verse;
using UnityEngine;

namespace ESCP_RaceTools
{
    class Comp_TurnToThing : ThingComp
	{
		public CompProperties_TurnToThing Props
		{
			get
			{
				return (CompProperties_TurnToThing)props;
			}
		}

        public override IEnumerable<Gizmo> CompGetGizmosExtra()
        {
			foreach (Gizmo gizmo in base.CompGetGizmosExtra())
			{
				yield return gizmo;
			}

            if (Props.thingDef != null)
            {

				Building building = parent as Building;
				if (building.Faction != null && building.Faction.IsPlayer)
				{
					yield return new Command_Action
					{
						defaultLabel = Props.label,
						defaultDesc = Props.desc,
						icon = ContentFinder<Texture2D>.Get(Props.texPath, true),
						disabled = Disabled(building, Props.requiresFullHealth),
						disabledReason = "ESCP_IsDamaged".Translate(),
						action = delegate ()
						{
							if (Props.fleck != null)
							{
								SpawnFleck(Props.fleck, building);
							}
							Transform(building, Props.thingDef);
						}
					};
				}
			}
		}

		public void Transform(Building building, ThingDef thingDef)
        {
			IntVec3 loc = building.Position;
			Map map = building.Map;
			building.Destroy();
			GenSpawn.Spawn(thingDef, loc, map).SetFactionDirect(Faction.OfPlayer);
		}

		public void SpawnFleck(FleckDef fleck, Building building)
        {
			FleckCreationData dataStatic = FleckMaker.GetDataStatic(building.Position.ToVector3(), building.Map, fleck, 1f);
			dataStatic.rotationRate = 0.2f;
			building.Map.flecks.CreateFleck(dataStatic);
		}

		public bool Disabled(Thing building, bool maxHealth)
        {
			return maxHealth && building.HitPoints < building.MaxHitPoints;
        }
	}
}

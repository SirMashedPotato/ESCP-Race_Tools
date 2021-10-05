using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    [StaticConstructorOnStartup]
    public class PlantBuildingPod : Plant
    {

		public override void Tick()
		{
			base.Tick();
			if (this.IsHashIntervalTick(2000))
			{
				this.TickLong();
			}
		}

		/* 
		 * basically just copied from Plant 
		 * Need to check for full growth at the start
		 * If so, does the whole replacing stuff
		 */

		public override void TickLong()
		{
			this.CheckTemperatureMakeLeafless();
			if (base.Destroyed)
			{
				return;
			}

			/* the actual unique stuff */

			var modExt = PlantProperties.Get(this.def);
			if (modExt != null && modExt.matureInto != null  && this.Growth >= 1f)
            {
				IntVec3 loc = this.Position;
				Map map = this.Map;
				//plant.Destroy;
				GenSpawn.Spawn(modExt.matureInto, loc, map);
				return;
			}

			/* the actual unique stuff */

			base.TickLong();
			if (PlantUtility.GrowthSeasonNow(base.Position, base.Map, false))
			{
				float num = this.growthInt;
				bool flag = this.LifeStage == PlantLifeStage.Mature;
				this.growthInt += this.GrowthPerTick * 2000f;
				if (this.growthInt > 1f)
				{
					this.growthInt = 1f;
				}
				if (((!flag && this.LifeStage == PlantLifeStage.Mature) || (int)(num * 10f) != (int)(this.growthInt * 10f)) && this.CurrentlyCultivated())
				{
					base.Map.mapDrawer.MapMeshDirty(base.Position, MapMeshFlag.Things);
				}
			}
			if (!this.HasEnoughLightToGrow)
			{
				this.unlitTicks += 2000;
			}
			else
			{
				this.unlitTicks = 0;
			}
			this.ageInt += 2000;
			if (this.Dying)
			{
				Map map = base.Map;
				bool isCrop = this.IsCrop;
				bool harvestableNow = this.HarvestableNow;
				bool dyingBecauseExposedToLight = this.DyingBecauseExposedToLight;
				int num2 = Mathf.CeilToInt(this.CurrentDyingDamagePerTick * 2000f);
				base.TakeDamage(new DamageInfo(DamageDefOf.Rotting, (float)num2, 0f, -1f, null, null, null, DamageInfo.SourceCategory.ThingOrUnknown, null, true, true));
				if (base.Destroyed)
				{
					if (isCrop && this.def.plant.Harvestable && MessagesRepeatAvoider.MessageShowAllowed("MessagePlantDiedOfRot-" + this.def.defName, 240f))
					{
						string key;
						if (harvestableNow)
						{
							key = "MessagePlantDiedOfRot_LeftUnharvested";
						}
						else if (dyingBecauseExposedToLight)
						{
							key = "MessagePlantDiedOfRot_ExposedToLight";
						}
						else
						{
							key = "MessagePlantDiedOfRot";
						}
						Messages.Message(key.Translate(this.GetCustomLabelNoCount(false)), new TargetInfo(base.Position, map, false), MessageTypeDefOf.NegativeEvent, true);
					}
					return;
				}
			}
			this.cachedLabelMouseover = null;
			/*
			if (this.def.plant.dropLeaves)
			{
				MoteLeaf moteLeaf = MoteMaker.MakeStaticMote(Vector3.zero, base.Map, ThingDefOf.Mote_Leaf, 1f) as MoteLeaf;
				if (moteLeaf != null)
				{
					float num3 = this.def.plant.visualSizeRange.LerpThroughRange(this.growthInt);
					float treeHeight = this.def.graphicData.drawSize.x * num3;
					Vector3 vector = Rand.InsideUnitCircleVec3 * Plant.LeafSpawnRadius;
					moteLeaf.Initialize(base.Position.ToVector3Shifted() + Vector3.up * Rand.Range(Plant.LeafSpawnYMin, Plant.LeafSpawnYMax) + vector + Vector3.forward * this.def.graphicData.shadowData.offset.z, Rand.Value * 2000.TicksToSeconds(), vector.z > 0f, treeHeight);
				}
			}
			*/
		}

		private string cachedLabelMouseover;
	}
}

using System.Collections.Generic;
using Verse;
using RimWorld;
using System.Linq;
using RimWorld.Planet;
using System.Text;

namespace ESCP_RaceTools
{
    public static class SettlementPreferenceUtility
    {
        public static bool GetTileID(Faction faction, out int tileID)
        {
            tileID = 0;
            bool defaultToVanilla = false;  //return true if any checks fail, causes vanilla code to take over
            var modExt = SettlementPreference.Get(faction.def);
            bool flag = ModSettingsUtility.ESCP_SettlementPreferenceLogging();

            /* modified from  TileFinder.RandomSettlementTileFor */
            int limit = (int)ModSettingsUtility.ESCP_RaceTools_SettlementPreferenceIterations();
            for (int i = 0; i < limit; i++)
            {
                if ((from _ in Enumerable.Range(0, 100) select Rand.Range(0, Find.WorldGrid.TilesCount)).TryRandomElementByWeight(delegate (int x)
                {
                    defaultToVanilla = false;
                    Tile tile = Find.WorldGrid[x];
                    string logMessage = "Faction: " + faction + ", checking tile: " + tile + ", ";
                    if (!tile.biome.canBuildBase || !tile.biome.implemented)
                    {
                        return 0f;
                    }

                    /* modExt checks */
                    if (!modExt.biomeKeyWords.NullOrEmpty() && !modExt.biomeKeyWords.Any(y => tile.biome.defName.Contains(y)))
                    {
                        if (flag)
                        {
                            logMessage += "failed biomeKeyWords, ";
                        }
                        defaultToVanilla = true;
                    }

                    if (modExt.useTemperatureRange)
                    {
                        if (GenTemperature.MinTemperatureAtTile(x) < modExt.temperatureRangeMin || GenTemperature.MaxTemperatureAtTile(x) > modExt.temperatureRangeMax)
                        {
                            if (flag)
                            {
                                logMessage += "failed CheckTemperatureRange, ";
                            }
                            defaultToVanilla = true;
                        }
                    }

                    if (modExt.useElevationRange)
                    {
                        if (tile.elevation < modExt.elevationRangeMin || tile.elevation > modExt.elevationRangeMax)
                        {
                            if (flag)
                            {
                                logMessage += "failed CheckAltitudeRange, ";
                            }
                            defaultToVanilla = true;
                        }
                    }

                    if (modExt.useSwampinessRange)
                    {
                        if (tile.swampiness < modExt.swampinessRangeMin || tile.swampiness > modExt.swampinessRangeMax)
                        {
                            if (flag)
                            {
                                logMessage += "failed CheckSwampinessRange, ";
                            }
                            defaultToVanilla = true;
                        }
                    }

                    if (modExt.useSwampinessRange)
                    {
                        if (tile.rainfall < modExt.rainfallRangeMin || tile.rainfall > modExt.rainfallRangeMax)
                        {
                            if (flag)
                            {
                                logMessage += "failed CheckRainfallRange, ";
                            }
                            defaultToVanilla = true;
                        }
                    }

                    if (modExt.likedBiomeList != null && !modExt.likedBiomeList.Contains(tile.biome.defName))
                    {
                        if (flag)
                        {
                            logMessage += "failed likedBiomeList, ";
                        }
                        defaultToVanilla = true;
                    }

                    if (modExt.dislikedBiomeList != null && modExt.dislikedBiomeList.Contains(tile.biome.defName))
                    {
                        if (flag)
                        {
                            logMessage += "failed dislikedBiomeList, ";
                        }
                        defaultToVanilla = true;
                    }

                    if (modExt.requiredHillLevels != null && !modExt.requiredHillLevels.Contains(tile.hilliness))
                    {
                        if (flag)
                        {
                            logMessage += "failed requiredHillLevels, ";
                        }
                        defaultToVanilla = true;
                    }

                    if (modExt.disallowedHillLevels != null && modExt.disallowedHillLevels.Contains(tile.hilliness))
                    {
                        if (flag)
                        {
                            logMessage += "failed disallowedHillLevels, ";
                        }
                        defaultToVanilla = true;
                    }

                    /* Extra check for impassible hilliness, only triggers if both required and disallowed are null */

                    if (modExt.requiredHillLevels == null && modExt.disallowedHillLevels == null && tile.hilliness == Hilliness.Impassable)
                    {
                        if (flag)
                        {
                            logMessage += "failed impassible hills check, ";
                        }
                        defaultToVanilla = true;
                    }

                    if (modExt.requiresWater && (!CheckTileBiomeNeighbours(x, BiomeDefOf.Ocean) && !CheckTileBiomeNeighbours(x, BiomeDefOf.Lake) && tile.Rivers == null))
                    {
                        if (flag)
                        {
                            logMessage += "failed requiresWater, ";
                        }
                        defaultToVanilla = true;
                    }

                    if (modExt.onlyCoastal && !CheckTileBiomeNeighbours(x, BiomeDefOf.Ocean))
                    {
                        if (flag)
                        {
                            logMessage += "failed onlyCoastal, ";
                        }
                        defaultToVanilla = true;
                    }

                    if (modExt.onlyLakeside && !CheckTileBiomeNeighbours(x, BiomeDefOf.Lake))
                    {
                        if (flag)
                        {
                            logMessage += "failed onlyLakeside, ";
                        }
                        defaultToVanilla = true;
                    }

                    if (modExt.onlyRiver && tile.Rivers == null)
                    {
                        if (flag)
                        {
                            logMessage += "failed onlyRiver, ";
                        }
                        defaultToVanilla = true;
                    }

                    if (modExt.onlyRoad && tile.Roads == null)
                    {
                        if (flag)
                        {
                            logMessage += "failed onlyRoad, ";
                        }
                        defaultToVanilla = true;
                    }

                    if (ModsConfig.BiotechActive && modExt.usePollutionRange)
                    {
                        if (tile.pollution < modExt.pollutionRangeMin || tile.pollution > modExt.pollutionRangeMax)
                        {
                            if (flag)
                            {
                                logMessage += "failed checkPollutionRange, ";
                            }
                            defaultToVanilla = true;
                        }
                    }

                    /* logging */

                    if (flag && !defaultToVanilla)
                    {
                        Log.Message(logMessage + " valid tile = " + !defaultToVanilla);
                    }

                    if (ModSettingsUtility.ESCP_SettlementPreferenceLoggingExtended() && defaultToVanilla)
                    {
                        Log.Message(logMessage + " valid tile = " + !defaultToVanilla);
                    }

                    //use selection weight if enabled
                    if (!defaultToVanilla && !modExt.IgnoreBiomeSelectionWeight)
                    {
                        float num2 = tile.biome.settlementSelectionWeight;
                        Faction faction2 = faction;
                        if (((faction2 != null) ? faction2.def.minSettlementTemperatureChanceCurve : null) != null)
                        {
                            num2 *= faction.def.minSettlementTemperatureChanceCurve.Evaluate(GenTemperature.MinTemperatureAtTile(x));
                        }
                        return num2;
                    }
                    if (!defaultToVanilla)
                    {
                        return 1000;
                    }
                    return 0;

                }, out int num))
                    if (!defaultToVanilla && FinalCheckTileIsValid(num, null))
                    {
                        if (flag)
                        {
                            Log.Message("Faction: " + faction + ", passed all checks for tile: " + Find.WorldGrid[num]);
                        }
                        tileID = num;
                        return false;
                    }
            }

            if (flag) 
            {
                Log.Error("Failed to find faction base tile for " + faction + ", using ESCP_RaceTools.SettlementPreference. Defaulting to standard selection.");
            }

            return true;
        }

        public static bool FinalCheckTileIsValid(int tile, StringBuilder reason = null)
        {
            Tile tile2 = Find.WorldGrid[tile];
            if (!tile2.biome.canBuildBase)
            {
                if (reason != null)
                {
                    reason.Append("CannotLandBiome".Translate(tile2.biome.LabelCap));
                }
                return false;
            }
            if (!tile2.biome.implemented)
            {
                if (reason != null)
                {
                    reason.Append("BiomeNotImplemented".Translate() + ": " + tile2.biome.LabelCap);
                }
                return false;
            }
            /* removed hilliness check */
            Settlement settlement = Find.WorldObjects.SettlementBaseAt(tile);
            if (settlement != null)
            {
                if (reason != null)
                {
                    if (settlement.Faction == null)
                    {
                        reason.Append("TileOccupied".Translate());
                    }
                    else if (settlement.Faction == Faction.OfPlayer)
                    {
                        reason.Append("YourBaseAlreadyThere".Translate());
                    }
                    else
                    {
                        reason.Append("BaseAlreadyThere".Translate(settlement.Faction.Name));
                    }
                }
                return false;
            }
            if (Find.WorldObjects.AnySettlementBaseAtOrAdjacent(tile))
            {
                if (reason != null)
                {
                    reason.Append("FactionBaseAdjacent".Translate());
                }
                return false;
            }
            if (Find.WorldObjects.AnyMapParentAt(tile) || Current.Game.FindMap(tile) != null || Find.WorldObjects.AnyWorldObjectOfDefAt(WorldObjectDefOf.AbandonedSettlement, tile))
            {
                if (reason != null)
                {
                    reason.Append("TileOccupied".Translate());
                }
                return false;
            }
            return true;
        }

        public static bool CheckTileBiomeNeighbours(int tile, BiomeDef b)
        {
            List<int> tileList = new List<int>();
            Find.WorldGrid.GetTileNeighbors(tile, tileList);
            foreach (int x in tileList)
            {
                if(Find.WorldGrid[x].biome == b)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

using System.Collections.Generic;
using Verse;
using RimWorld;
using System.Linq;
using RimWorld.Planet;

namespace ESCP_RaceTools
{
    public static class SettlementPreferenceUtility
    {
        /// <summary>
        /// TODO
        /// Should probably be converted to a worker class system, with a list of classes defined in the mod extension
        /// That way every settlement isn't going through every single check
        /// </summary>
        public static bool GetTileID(PlanetLayer layer, Faction faction, out PlanetTile tileID)
        {
            tileID = 0;
            bool defaultToVanilla = false;  //return true if any checks fail, causes vanilla code to take over
            var modExt = SettlementPreference.Get(faction.def);
            bool logFlag = ESCP_RaceTools_ModSettings.SettlementPreferenceLogging;

            /* modified from  TileFinder.RandomSettlementTileFor */
            int limit = (int)ESCP_RaceTools_ModSettings.SettlementPreferenceIterations;
            for (int i = 0; i < limit; i++)
            {
                if ((from _ in Enumerable.Range(0, 100) select Rand.Range(0, layer.TilesCount)).TryRandomElementByWeight(delegate (int x)
                {
                    defaultToVanilla = false;
                    Tile tile = layer.Tiles[x];
                    string logMessage = "Faction: " + faction + ", checking tile: " + tile + ", ";
                    if (!tile.PrimaryBiome.canBuildBase || !tile.PrimaryBiome.implemented)
                    {
                        return 0f;
                    }

                    if (tile is not SurfaceTile surfaceTile)
                    {
                        return 0f;
                    }

                    /* modExt checks */
                    if (!modExt.biomeKeyWords.NullOrEmpty() && !modExt.biomeKeyWords.Any(y => surfaceTile.PrimaryBiome.defName.Contains(y)))
                    {
                        if (logFlag)
                        {
                            logMessage += "failed biomeKeyWords, ";
                        }
                        defaultToVanilla = true;
                    }

                    if (modExt.useTemperatureRange)
                    {
                        if (GenTemperature.MinTemperatureAtTile(x) < modExt.temperatureRangeMin || GenTemperature.MaxTemperatureAtTile(x) > modExt.temperatureRangeMax)
                        {
                            if (logFlag)
                            {
                                logMessage += "failed CheckTemperatureRange, ";
                            }
                            defaultToVanilla = true;
                        }
                    }

                    if (modExt.useElevationRange)
                    {
                        if (surfaceTile.elevation < modExt.elevationRangeMin || surfaceTile.elevation > modExt.elevationRangeMax)
                        {
                            if (logFlag)
                            {
                                logMessage += "failed CheckAltitudeRange, ";
                            }
                            defaultToVanilla = true;
                        }
                    }

                    if (modExt.useSwampinessRange)
                    {
                        if (surfaceTile.swampiness < modExt.swampinessRangeMin || surfaceTile.swampiness > modExt.swampinessRangeMax)
                        {
                            if (logFlag)
                            {
                                logMessage += "failed CheckSwampinessRange, ";
                            }
                            defaultToVanilla = true;
                        }
                    }

                    if (modExt.useRainfallRange)
                    {
                        if (surfaceTile.rainfall < modExt.rainfallRangeMin || surfaceTile.rainfall > modExt.rainfallRangeMax)
                        {
                            if (logFlag)
                            {
                                logMessage += "failed CheckRainfallRange, ";
                            }
                            defaultToVanilla = true;
                        }
                    }

                    if (modExt.likedBiomeList != null && (!modExt.likedBiomeList.Contains(surfaceTile.PrimaryBiome.defName)))
                    {
                        if (logFlag)
                        {
                            logMessage += "failed likedBiomeList, ";
                        }
                        defaultToVanilla = true;
                    }

                    if (modExt.dislikedBiomeList != null && modExt.dislikedBiomeList.Contains(surfaceTile.PrimaryBiome.defName))
                    {
                        if (logFlag)
                        {
                            logMessage += "failed dislikedBiomeList, ";
                        }
                        defaultToVanilla = true;
                    }

                    if (modExt.requiredHillLevels != null && !modExt.requiredHillLevels.Contains(surfaceTile.hilliness))
                    {
                        if (logFlag)
                        {
                            logMessage += "failed requiredHillLevels, ";
                        }
                        defaultToVanilla = true;
                    }

                    if (modExt.disallowedHillLevels != null && modExt.disallowedHillLevels.Contains(surfaceTile.hilliness))
                    {
                        if (logFlag)
                        {
                            logMessage += "failed disallowedHillLevels, ";
                        }
                        defaultToVanilla = true;
                    }

                    if (modExt.requiresWater && !(CheckTileBiomeNeighbours(x, BiomeDefOf.Ocean) || CheckTileBiomeNeighbours(x, BiomeDefOf.Lake) || !surfaceTile.Rivers.NullOrEmpty()))
                    {
                        if (logFlag)
                        {
                            logMessage += "failed requiresWater, ";
                        }
                        defaultToVanilla = true;
                    }

                    if (modExt.onlyCoastal && !CheckTileBiomeNeighbours(x, BiomeDefOf.Ocean))
                    {
                        if (logFlag)
                        {
                            logMessage += "failed onlyCoastal, ";
                        }
                        defaultToVanilla = true;
                    }

                    if (modExt.onlyLakeside && !CheckTileBiomeNeighbours(x, BiomeDefOf.Lake))
                    {
                        if (logFlag)
                        {
                            logMessage += "failed onlyLakeside, ";
                        }
                        defaultToVanilla = true;
                    }

                    if (modExt.onlyRiver && surfaceTile.Rivers.NullOrEmpty())
                    {
                        if (logFlag)
                        {
                            logMessage += "failed onlyRiver, ";
                        }
                        defaultToVanilla = true;
                    }

                    if (modExt.onlyRoad && surfaceTile.Roads.NullOrEmpty())
                    {
                        if (logFlag)
                        {
                            logMessage += "failed onlyRoad, ";
                        }
                        defaultToVanilla = true;
                    }

                    if (ModsConfig.BiotechActive && modExt.usePollutionRange)
                    {
                        if (surfaceTile.pollution < modExt.pollutionRangeMin || surfaceTile.pollution > modExt.pollutionRangeMax)
                        {
                            if (logFlag)
                            {
                                logMessage += "failed checkPollutionRange, ";
                            }
                            defaultToVanilla = true;
                        }
                    }

                    /* logging */

                    if (logFlag && !defaultToVanilla)
                    {
                        Log.Message(logMessage + " valid tile = " + !defaultToVanilla);
                    }

                    if (ESCP_RaceTools_ModSettings.SettlementPreferenceLoggingExtended && defaultToVanilla)
                    {
                        Log.Message(logMessage + " valid tile = " + !defaultToVanilla);
                    }

                    //use selection weight if enabled
                    if (!defaultToVanilla && !modExt.IgnoreBiomeSelectionWeight)
                    {
                        float num2 = surfaceTile.PrimaryBiome.settlementSelectionWeight;
                        Faction faction2 = faction;
                        if ((faction2?.def.minSettlementTemperatureChanceCurve) != null)
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
                    if (!defaultToVanilla && TileFinder.IsValidTileForNewSettlement(num, null))
                    {
                        if (logFlag)
                        {
                            Log.Message("Faction: " + faction + ", passed all checks for tile: " + Find.WorldGrid[num]);
                        }
                        tileID = num;
                        return false;
                    }
            }

            if (logFlag)
            {
                Log.Error("Failed to find faction base tile for " + faction + ", using ESCP_RaceTools.SettlementPreference. Defaulting to standard selection.");
            }

            return true;
        }

        public static bool CheckTileBiomeNeighbours(PlanetTile tile, BiomeDef b)
        {
            List<PlanetTile> tileList = [];
            Find.WorldGrid.GetTileNeighbors(tile, tileList);
            foreach (int x in tileList)
            {
                if (Find.WorldGrid[x].PrimaryBiome == b)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
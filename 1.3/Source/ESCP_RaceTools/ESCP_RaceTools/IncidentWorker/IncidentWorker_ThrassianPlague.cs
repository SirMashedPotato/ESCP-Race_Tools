using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld.Planet;
using UnityEngine;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    class IncidentWorker_ThrassianPlague : IncidentWorker_DiseaseHuman
    {
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            return SloadsLoaded() && ModSettingsUtility_Race.ESCP_RaceTools_SloadThrassianPlagueIncident() && this.PotentialVictims(parms.target).Any<Pawn>() && !Immune() && Hostile();
        }

        private bool SloadsLoaded()
        {
            return LoadedModManager.RunningModsListForReading.Any(x => x.Name == "ESCP - Sload");
        }

        private bool Immune()
        {
            return Faction.OfPlayer.ideos.PrimaryIdeo.PreceptsListForReading.Where(x => x.def.defName == "ESCP_SloadThrassianImmunity").Any();
        }

        private bool Hostile()
        {
            World world = Find.World;
            foreach(Faction f in world.factionManager.GetFactions().InRandomOrder())
            {
                var props = FactionProperties.Get(f.def);
                if(props != null && props.isSloadFaction && f.HostileTo(Faction.OfPlayer))
                {

                    return true;
                }
            }
            return false;
        }
    }
}

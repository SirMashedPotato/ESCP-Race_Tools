using Verse;

namespace ESCP_Birthsigns
{
    public static class DebugTools
    {
        [DebugAction("ESCP - Birthsign Framework", "Add appropriate birthsign", false, false, actionType = DebugActionType.ToolMapForPawns, allowedGameStates = AllowedGameStates.PlayingOnMap)]
        private static void BirthsignFramework_AddBirthsign(Pawn p)
        {
            if (BirthSigns_ModSettings.CurrentSetDef != null)
            {
                if (p.RaceProps.Humanlike)
                {
                    BirthsignSetDef signs = BirthSigns_ModSettings.CurrentSetDef;
                    BirthSignUtility.GenerateBirthsign(p, signs);
                }
            }
        }
    }
}

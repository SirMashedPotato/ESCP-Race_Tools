using Verse;
using System.Linq;

namespace ESCP_RaceTools
{
    public static class RaceToolsUtility
    {
        public static bool ModLoaded(string modID, string modName)
        {
            return LoadedModManager.RunningModsListForReading.Any(x => x.PackageId == modID || x.Name == modName);
        }
    }
}

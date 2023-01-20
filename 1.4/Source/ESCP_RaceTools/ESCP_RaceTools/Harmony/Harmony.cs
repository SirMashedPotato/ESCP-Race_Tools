using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;

namespace ESCP_RaceTools
{
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.ESCP_RaceTools");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}


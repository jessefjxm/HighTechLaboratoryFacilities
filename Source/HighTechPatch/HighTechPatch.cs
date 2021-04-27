using System.Reflection;
using HarmonyLib;
using Verse;

namespace HighTechPatch
{
    [StaticConstructorOnStartup]
    internal class HighTechPatch
    {
        static HighTechPatch()
        {
            var harmony = new Harmony("Mlie.HighTechLaboratoryFacilities");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
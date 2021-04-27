using Verse;

namespace HighTechLaboratoryFacilities
{
    internal class HighTechLaboratoryFacilitiesModSettings : ModSettings
    {
        public bool HideApparel;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref HideApparel, "HideApparel");
        }
    }
}
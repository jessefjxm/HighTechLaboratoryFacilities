using Verse;

namespace HighTechLaboratoryFacilities
{
    internal class HighTechLaboratoryFacilitiesModSettings : ModSettings
    {
        public bool HideApparel = false;
               
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look<bool>(ref HideApparel, "HideApparel", false, false);
        }


    }
}

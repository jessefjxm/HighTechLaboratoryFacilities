using UnityEngine;
using Verse;

namespace HighTechLaboratoryFacilities
{
    [StaticConstructorOnStartup]
    internal class HighTechLaboratoryFacilitiesMod : Mod
    {
        public HighTechLaboratoryFacilitiesMod(ModContentPack content) : base(content)
        {
            HighTechLaboratoryFacilitiesMod.instance = this;
        }

        internal HighTechLaboratoryFacilitiesModSettings Settings
        {
            get
            {
                HighTechLaboratoryFacilitiesModSettings result;
                if ((result = this.settings) == null)
                {
                    result = (this.settings = base.GetSettings<HighTechLaboratoryFacilitiesModSettings>());
                }
                return result;
            }
            set
            {
                this.settings = value;
            }
        }

        public override string SettingsCategory()
        {
            return "High Tech Laboratory Facilities";
        }
        
        public override void DoSettingsWindowContents(Rect rect)
        {
            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(rect);
            listing_Standard.CheckboxLabeled("Hide apparel", ref settings.HideApparel, "Hide the Labcoat, cybersuit and Leviathan Powerarmor");
            listing_Standard.End();
            settings.Write();
            HighTechLaboratoryFacilities.SetApparelVisibility();
        }

        private HighTechLaboratoryFacilitiesModSettings settings;

        public static HighTechLaboratoryFacilitiesMod instance;

    }
}

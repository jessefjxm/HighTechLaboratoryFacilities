using UnityEngine;
using Verse;

namespace HighTechLaboratoryFacilities
{
    [StaticConstructorOnStartup]
    internal class HighTechLaboratoryFacilitiesMod : Mod
    {
        public HighTechLaboratoryFacilitiesMod(ModContentPack content) : base(content)
        {
            instance = this;
        }

        internal HighTechLaboratoryFacilitiesModSettings Settings
        {
            get
            {
                if (settings == null)
                {
                    settings = GetSettings<HighTechLaboratoryFacilitiesModSettings>();
                }
                return settings;
            }
            set
            {
                settings = value;
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
            listing_Standard.CheckboxLabeled("Hide apparel", ref Settings.HideApparel, "Hide the Labcoat, cybersuit and Leviathan Powerarmor");
            listing_Standard.End();
            Settings.Write();
            HighTechLaboratoryFacilities.SetApparelVisibility();
        }

        public static HighTechLaboratoryFacilitiesMod instance;

        private HighTechLaboratoryFacilitiesModSettings settings;

    }
}

using System.Collections.Generic;
using System.Linq;
using Verse;

namespace HighTechLaboratoryFacilities
{
    [StaticConstructorOnStartup]
    internal static class HighTechLaboratoryFacilities
    {
        static HighTechLaboratoryFacilities()
        {
            SetApparelVisibility();
        }

        internal static void SetApparelVisibility()
        {
            //Log.Message("HighTechLaboratoryFacilities: SetApparelVisibility" );
            if (HighTechLaboratoryFacilitiesMod.instance.Settings == null)
            {
                //Log.Message("HighTechLaboratoryFacilities: settings null");
                HighTechLaboratoryFacilitiesMod.instance.Settings = new HighTechLaboratoryFacilitiesModSettings
                {
                    HideApparel = false
                };
            }

            //Log.Message("HighTechLaboratoryFacilities: var hidden");
            var hidden = HighTechLaboratoryFacilitiesMod.instance.Settings.HideApparel;

            var recipeList = DefDatabase<RecipeDef>.AllDefs.ToList();
            foreach (var recipe in recipeList)
            {
                if (recipe.defName != "Make_LabCoat" && recipe.defName != "Make_Apparel_CyberSuit" &&
                    recipe.defName != "Make_Apparel_Leviathan" && recipe.defName != "Make_Apparel_LeviathanH")
                {
                    continue;
                }

                if (hidden)
                {
                    recipe.factionPrerequisiteTags = new List<string> {"Not_available_for_you"};
                }
                else
                {
                    recipe.factionPrerequisiteTags?.Clear();
                }

                //Log.Message("HighTechLaboratoryFacilities: " + recipe.defName + " hidden set to " + hidden);
            }

            var researchList = DefDatabase<ResearchProjectDef>.AllDefs.ToList();
            foreach (var research in researchList)
            {
                if (research.defName != "TranscendentTech")
                {
                    continue;
                }

                research.requiredResearchBuilding =
                    hidden ? DefDatabase<ThingDef>.GetNamedSilentFail("UnobtainableResearchBench") : null;

                //Log.Message("HighTechLaboratoryFacilities: " + research.defName + " hidden set to " + hidden);
            }

            var list = DefDatabase<ThingDef>.AllDefs.ToList();
            foreach (var thing in list)
            {
                if (thing.defName != "LabCoat")
                {
                    continue;
                }

                if (hidden)
                {
                    thing.generateCommonality = 0;
                }
                else
                {
                    thing.generateCommonality = 0.01f;
                }

                //Log.Message("HighTechLaboratoryFacilities: " + thing.defName + " commonality set to " + thing.generateCommonality);
            }
        }
    }
}
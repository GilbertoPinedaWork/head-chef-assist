using System;

namespace ChefManager
{
    public sealed class GM_Main
    {
        //TODO Delete old ingredientfile after modifying it since it will create a new file
        public static void IM_Main()
        {
            const int maxOption = 4;
            int answerSelected;
            var ingredientFolderPath = $"{Environment.SpecialFolder.MyDocuments.ToString()}\\Ingredients";
            do
            {
                var ingredientLoader = new IM_Loader(ingredientFolderPath);
                answerSelected = IM_PublicInterface.ActionSelection();

                //TODO decide return or reference
                ingredientLoader.IngredientList = IM_Modifier.Action(answerSelected, ingredientLoader.IngredientList);
                IM_Loader.LoadToFiles(ingredientLoader.IngredientList, ingredientFolderPath);
            } while (answerSelected > 0 && answerSelected < maxOption + 1);
        }

        public static void RM_Main()
        {
            var recipe = new RecipeInfo();
        }
    }
}
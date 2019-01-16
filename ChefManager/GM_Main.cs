using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ChefManager
{
    public sealed class GM_Main
    {
        //TODO ENCRYPTION
        //TODO Exception Handling, 
        //TODO Delete old ingredientfile after modifying it since it will create a new file
        public static void IM_Main()
        {
            int answer;
            do
            {
                var iLoader = new IM_IngredientLoader($"{Environment.SpecialFolder.MyDocuments.ToString()}\\Ingredients");
                answer = IM_PublicInterface.ActionSelection();

                IM_Modifier.Action(answer, iLoader.IngredientList);
                IM_IngredientLoader.ToFiles(iLoader.IngredientList);
            } while (answer < 0);
        }

        public void RecipeManagerMain()
        {
            var recipe = new RecipeInfo();
        }
    }
}
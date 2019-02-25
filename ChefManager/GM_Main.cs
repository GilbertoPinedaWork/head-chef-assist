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
                var iLoader = new IM_Loader($"{Environment.SpecialFolder.MyDocuments.ToString()}\\Ingredients");
                Console.Write(iLoader.IngredientList.Count);
                Console.ReadLine();
                answer = IM_PublicInterface.ActionSelection();

                iLoader.IngredientList=
                IM_Modifier.Action(answer, ref iLoader.IngredientList);
                
                IM_Loader.ToFiles(iLoader.IngredientList, $"{Environment.SpecialFolder.MyDocuments.ToString()}\\Ingredients");
            } while (answer > 0);
        }

        public void RecipeManagerMain()
        {
            var recipe = new RecipeInfo();
        }
    }
}
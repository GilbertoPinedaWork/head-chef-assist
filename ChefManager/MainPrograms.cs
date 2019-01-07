using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ChefManager
{

    public class MainPrograms
    {
        //TODO ENCRYPTION
        // TODO Refactor
        //TODO  Check For File Existence,
        public void IngredientManagerMain()
        {
            var iManager = new IngredientManagerMethods();
            var ingredientList = iManager.IngredientList;
           

            int answer = -1;
            do
            {
                answer = iManager.MainMenu();
                iManager.Action(answer, ingredientList);
               
            } while (answer > 0);

           IngredientManagerMethods.IngredientListToFile(ingredientList);
        }

        public void RecipeManagerMain()
        {
            var recipe = new RecipeInfo();
        }
    }
}
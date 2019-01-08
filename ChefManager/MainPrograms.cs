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
            var iManager = new IM_IngredientLoader();
          
           

            int answer = -1;
            do
            {
                answer = IM_PublicInterface.MainMenu(iManager.IngredientList);
               
            } while (answer > 0);

           IM_IngredientLoader.ToFiles(iManager.IngredientList);
        }

        public void RecipeManagerMain()
        {
            var recipe = new RecipeInfo();
        }
    }
}
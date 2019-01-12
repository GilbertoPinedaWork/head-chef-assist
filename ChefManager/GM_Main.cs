using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ChefManager
{
    public class GM_Main
    {
        //TODO ENCRYPTION
        // TODO Refactor
        //TODO  Check For File Existence,
        public static void IM_Main()
        {
            var iLoader = new IM_IngredientLoader(Environment.SpecialFolder.MyDocuments.ToString());
            var answer = 1;
            do
            {
                answer = IM_PublicInterface.ActionSelection(iLoader.IngredientList);
               
            } while (answer > 0);

           IM_IngredientLoader.ToFiles(iLoader.IngredientList);
        }

        public void RecipeManagerMain()
        {
            var recipe = new RecipeInfo();
        }
    }
}
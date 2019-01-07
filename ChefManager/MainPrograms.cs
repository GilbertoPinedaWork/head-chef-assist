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
            var ingredientList = new List<IngredientInfo>();
            var firstUseFlag = new FileInfo("useIngFlag.txt");

            if (!firstUseFlag.Exists)
            {
                firstUseFlag.Create();
                var closable = firstUseFlag.OpenText();
                closable.Close();
            }

            if (firstUseFlag.Length == 0)
            {
                iManager.Tutorial(ingredientList);

                var flagwriter = firstUseFlag.CreateText();
                flagwriter.WriteLine("1");
                flagwriter.Close();
            }

            else
               IngredientInfo.ReadIngredientsFromFiles(ingredientList);
      
            int answer = -1;
            do
            {
                answer = iManager.MainMenu();
                iManager.Action(answer, ingredientList);
               
            } while (answer > 0);

           IngredientInfo.IngredientListToFile(ingredientList);
        }

        public void RecipeManagerMain()
        {
            var recipe = new RecipeInfo();
        }
    }
}
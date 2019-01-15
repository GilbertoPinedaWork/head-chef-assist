using System.Collections.Generic;
using System;
using System.CodeDom.Compiler;


namespace ChefManager
{
    public class RecipeManagerMethods 
    {
        //Teamo

        public string GetRecipeNames(List<RecipeInfo> recipeList)
        {
            string names = "";
            foreach (var recipe in recipeList)
            {
                names += (recipeList.IndexOf(recipe) + 1) + ")" + recipe.Name;
            }

            return names;
        }
        public void ViewRecipeDetails(List<RecipeInfo> recipeList)
        {
            string tempString = GetRecipeNames(recipeList)+"\nWrite the Number of the Recipe to View Details";
            int answer = Convert.ToInt32(GM_Methods.NumberOnlyInput(tempString)-1);

            Console.WriteLine(recipeList[answer].Name);
            Console.WriteLine("For" +recipeList[answer].Servings + "Servings");
            
        }
        public void AddRecipe(List<RecipeInfo> recipeList)
        {
            string tempString = "Name:";
            var newRecipe = new RecipeInfo {Name = Console.ReadLine() };
            tempString += newRecipe.Name;
            tempString += "\nServings:";
            newRecipe.Servings = Convert.ToInt32(GM_Methods.NumberOnlyInput(tempString));
        }
    }
}
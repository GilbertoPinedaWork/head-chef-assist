using System.CodeDom;
using System.Runtime.InteropServices.ComTypes;
using System.Collections.Generic;
namespace ChefManager
{
    public class RecipeInfo
    {
        public string Name { get; set; }
        public int Servings { get; set; }
        public string Procedure { get; set;}
        public List<IngredientInfo> IngredientList { get; set; }       
       
       
        
        private double  GetRecipeCost(List<IngredientInfo> ingredientList )
        {
            double cost = 0.0;
            foreach (var ingredient in ingredientList)
            {
                cost += ingredient.Cost;
            }
            return cost;
        }

      //  public double Cost = GetRecipeCost();

    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ChefManager
{
    public class IM_IngredientLoader
    {
        public  List<IngredientInfo> IngredientList = new List<IngredientInfo>();
        public IM_IngredientLoader(string ingredientFolderPath)
        {
            LoadFromFiles(IngredientList, ingredientFolderPath);
        }
         private static void LoadFromFiles(ICollection<IngredientInfo> ingredientList, string ingredientFolderPath)
         {
            GM_Methods.MakeSureFolderExist(ingredientFolderPath);
            var ingredientFiles = Directory.GetFiles(ingredientFolderPath);
            
            foreach (var file in ingredientFiles)
            {
                string[] ingredientData = File.ReadAllLines(file).
                    SelectMany(s => s.Split('\t')).
                    ToArray();
               
                
                double.TryParse(ingredientData[1], out var cost);
                double.TryParse(ingredientData[2], out var yield);
                int.TryParse(ingredientData[4], out var quantity);
                
                ingredientList.Add(new IngredientInfo
                {
                    Name = ingredientData[0],
                    Cost = cost,
                    Yield = yield,
                    Unit = ingredientData[3],
                    Quantity = quantity,
                });
                var descriptionIndex = 5;
                do
                {
                    ingredientList.Last().Description += ingredientData[descriptionIndex];
                    descriptionIndex++;
                } while (descriptionIndex < ingredientData.Length);
            }
        }
         public static void ToFiles(IEnumerable<IngredientInfo> ingredientList)
         {
             foreach (var ingredient in ingredientList)
             {
                 using (var fWriter = new StreamWriter(ingredient.Name + ".ing"))
                 {
                     fWriter.WriteLine(ingredient.Name); 
                     fWriter.WriteLine(ingredient.Cost); 
                     fWriter.WriteLine(ingredient.Yield);  
                     fWriter.WriteLine(ingredient.Unit);   
                     fWriter.WriteLine(ingredient.Quantity); 
                     fWriter.WriteLine(ingredient.Description);  
                 }
             }
         }

        
    }
}
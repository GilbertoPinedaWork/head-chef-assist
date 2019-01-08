using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ChefManager
{
    public class IM_IngredientLoader
    {
        public readonly List<IngredientInfo> IngredientList = new List<IngredientInfo>();

        public IM_IngredientLoader()
        {
            LoadFromFiles(IngredientList);
            using (var veriFile = new StreamReader("IMTutorial.txt"))
            {
                if (veriFile.ReadLine() != null)
                {
                    //    ReadIngredientsFromFiles(IngredientList);
                    return;
                }
            }
            using (var writer = new StreamWriter("IMTutorial"))
            {
                writer.Write("1");
            }
            
         //TODO   IM_Modifier.Tutorial(IngredientList);
        }
         private static void LoadFromFiles(IList<IngredientInfo> ingredientList)
        {
            var currentDirectory = new DirectoryInfo(Environment.CurrentDirectory);
            var ingredientFiles = currentDirectory.GetFiles();
            foreach (var file in ingredientFiles)
            {
                string[] ingredientData = File.ReadAllLines(file.Name).
                    SelectMany(s => s.Split('\n')).
                    ToArray();
                
                double.TryParse(ingredientData[1], out var cost);
                double.TryParse(ingredientData[2], out var yield);
                int.TryParse(ingredientData[4], out var quantity);
                
                ingredientList.Add(new IngredientInfo
                {
                    Name = ingredientData[0],
                    Cost = cost,
                    Yield = yield,
                    MeasurementUnit =ingredientData[3],
                    Quantity = quantity,
                });
                var descriptionIndex = 5;
                do
                {
                    ingredientList[0].Description += ingredientData[descriptionIndex];
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
                     fWriter.WriteLine(ingredient.MeasurementUnit);   
                     fWriter.WriteLine(ingredient.Quantity); 
                     fWriter.WriteLine(ingredient.Description);  
                 }
             }
         }
         
    }
}
using System;
using System.Collections.Generic;
using System.IO;

namespace ChefManager
{
    public class IngredientInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }// Use SetDescription to set it
        public string MeasurementUnit { get; set; }
        public double Quantity { get; set; }
        public double Cost { get; set; }
        public double Yield { get; set; }

        public void SetDescription(string input, string existing = "")
        {
            string description = existing;
            string temp = input;

            if (temp == "")
                return;
           
            description += temp;
            Description = description;
        }
       
        public static void IngredientListToFile(List<IngredientInfo> ingredientList)
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
        public static void IngredientToFile(IngredientInfo ingredient)
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

        public static void ReadIngredientsFromFiles(List<IngredientInfo> ingredientList)
        {
            var currentDirectory = new DirectoryInfo(Environment.CurrentDirectory);
            var ingredientFiles = currentDirectory.GetFiles();
            foreach (var file in ingredientFiles)
            {
              using (var fReader = new StreamReader(file.Name))
               {
                 ingredientList.Add (new IngredientInfo
                 {
                  Name =fReader.ReadLine(),
                  Cost = Convert.ToDouble(fReader.ReadLine()),
                  Yield = Convert.ToDouble(fReader.ReadLine()),
                  MeasurementUnit = fReader.ReadLine(),
                  Description = fReader.ReadToEnd()
                  });
               } 
            }
        }
        public static string GetIngredientNames(List<IngredientInfo> list)
        {
            string target = "";
            int index = 0;
            foreach (var ingredient in list)
            {
                index = list.IndexOf(ingredient)+1; 
                target+= (index+") "+ ingredient.Name);
                target += "\n";
            }
            return target;
        }
    }
}    

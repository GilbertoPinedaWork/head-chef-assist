using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
    }
}    

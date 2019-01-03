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
                    description += temp;
            
            Description = description;
        }
        
        public static void WritePropertiesToFiles(List<IngredientInfo> ingredientList)
        {
            using (StreamWriter nameWriter = new StreamWriter("IngredientName.txt"))
            using (StreamWriter descWriter = new StreamWriter("IngredienDescription.txt"))
            using (StreamWriter unitWriter = new StreamWriter("IngredientUnit.txt"))
            using (StreamWriter costWriter = new StreamWriter("IngredientCost.txt"))
            using (StreamWriter yieldWriter = new StreamWriter("IngredientYield.txt"))
            using (StreamWriter quantityWriter = new StreamWriter("IngredientQuantity.txt"))
            {
                foreach (var ingredient in ingredientList)
                {
                
                    nameWriter.WriteLine(ingredient.Name);
                    descWriter.WriteLine(ingredient.Description);
                    unitWriter.WriteLine(ingredient.MeasurementUnit);
                    costWriter.WriteLine(ingredient.Cost);
                    yieldWriter.WriteLine(ingredient.Yield);
                    quantityWriter.WriteLine(ingredient.Quantity);
                }
            }
        }
        public static void WritePropertiesToFiles(IngredientInfo ingredient)
        {
            using (StreamWriter nameWriter = new StreamWriter("IngredientName.txt"))
            using (StreamWriter descWriter = new StreamWriter("IngredienDescription.txt"))
            using (StreamWriter unitWriter = new StreamWriter("IngredientUnit.txt"))
            using (StreamWriter costWriter = new StreamWriter("IngredientCost.txt"))
            using (StreamWriter yieldWriter = new StreamWriter("IngredientYield.txt"))
            using (StreamWriter quantityWriter = new StreamWriter("IngredientQuantity.txt"))
            {
               
                    nameWriter.WriteLine(ingredient.Name);
                    descWriter.WriteLine(ingredient.Description);
                    unitWriter.WriteLine(ingredient.MeasurementUnit);
                    costWriter.WriteLine(ingredient.Cost);
                    yieldWriter.WriteLine(ingredient.Yield);
                    quantityWriter.WriteLine(ingredient.Quantity);
            }
        }
        public static void LoadProperties(List<IngredientInfo> ingredientList)
        {  
           
            using(var nameReader = new StreamReader("IngredientName.txt")) 
            using(var descriptionReader =new StreamReader("IngredientDescription.txt"))
            using(var unitReader = new StreamReader("IngredientUnit.txt"))
            using(var costReader = new StreamReader("IngredientCost.txt"))
            using (var quantityReader = new StreamReader("IngredientQuantity.txt"))
            using (var yieldReader = new StreamReader("IngredientYield.txt"))
            {
                string name = nameReader.ReadLine();
                int index = 0;
                while(name!=null)
                    //foreach (var ingredient in ingredientList)
                { 
                    var ingredient = new IngredientInfo();
                    ingredientList.Add(ingredient);
                    ingredientList[index].Name = name;
                    ingredientList[index].Description = descriptionReader.ReadLine();
                    ingredientList[index].MeasurementUnit = unitReader.ReadLine();
                    ingredientList[index].Cost = Convert.ToDouble(costReader.ReadLine());
                    ingredientList[index].Quantity = Convert.ToDouble(quantityReader.ReadLine());
                    ingredientList[index].Yield = Convert.ToDouble(yieldReader.ReadLine());

                    name = nameReader.ReadLine();
                    index++;
                }
            }
        }
        public static string GetIngredientNames(List<IngredientInfo> list)
        {
            string target = "";
            int index = 0;
            foreach (var ingredient in list)
            {
                index = list.IndexOf(ingredient); 
                target+= ("\n"+index+") "+ ingredient.Name);
            }

            return target;
        }
    }
}    

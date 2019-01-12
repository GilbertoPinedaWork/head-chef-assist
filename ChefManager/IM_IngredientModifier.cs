using System;
using System.Collections.Generic;
using System.IO;
namespace  ChefManager
{
    public class IM_Modifier
    {
        //TODO Find a Way TO make this Dissappear
        private static string GetIngredientNames(List<IngredientInfo> list)
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
        //Front End Reliant
      public static void Action(int answer, List<IngredientInfo> ingredientList)
        { 
            switch (answer)
            {
                case 1:
                {
                    ingredientList.Add(IM_PublicInterface.IAddIngredient());
                    ingredientList.Sort();
                    break;
                }
                case 2:
                {
                    IM_PublicInterface.ShowIngredientList(ingredientList);
                    int id = IM_PublicInterface.IDeleteIngredient();
                    DeleteIngredient(ingredientList,id);
                    break;
                }
                case 3:
                {
                    ModifyIngredient(ingredientList);
                    break;
                }
                case 4:
                {
                    ViewIngredientDetails(ingredientList);
                    break;
                }
               
                case 0:
                    break;
                default:
                {
                    return;
                }
            }
        }

      private static void AddIngredient(IList<IngredientInfo>list,Tuple<string,string,string,int,double,double> t)
      {
          var ingredient = new IngredientInfo
          {
              Name=t.Item1,
              Description = t.Item2,
              MeasurementUnit = t.Item3,
              Quantity = t.Item4,
              Cost   = t.Item5,
              Yield = t.Item6
          };
             
        list.Add(ingredient);
      }
      private static void ModifyIngredient(List<IngredientInfo> list)
       {
            if (list.Count == 0)
                return;
            
            int answer = -1;
            while(answer<0 || answer>list.Count-1)
                answer = Convert.ToInt32(GM_Methods.NumberOnlyInput(GetIngredientNames(list)+
                         "\nWrite the Number of the Ingredient You Wish to Modify : "));
            
            var newIngredient = list[answer];
            string tempString = " ";
            while (tempString == " ")
            {
                Console.Clear();
                Console.Write("Ingredient Name: ");
                tempString = Console.ReadLine();
            }
            newIngredient.Name = tempString;
            tempString = ("Ingredient Name: " + newIngredient.Name +
                          "\nIngredient Cost $");

            newIngredient.Cost = GM_Methods.NumberOnlyInput(tempString);

            tempString += (newIngredient.Cost+"\nIngredient Yield: ");
            newIngredient.Yield = GM_Methods.NumberOnlyInput(tempString);

            tempString += (newIngredient.Yield + "\nIngredient Unit: ");
            Console.Write("Ingredient Unit: ");//TODO Restrict Unit
            newIngredient.MeasurementUnit = Console.ReadLine();

            tempString += (newIngredient.MeasurementUnit+"\nIngredient Description: ");
            Console.Clear();
            Console.Write(tempString);
            newIngredient.Description = Console.ReadLine();
        }
    

      private static void DeleteIngredient(IList<IngredientInfo> list,int id)
      {
         list.RemoveAt(id);
      }
     
      private static void ViewIngredientDetails(IList<IngredientInfo> list)
        {
            if (list.Count == 0)
                return;
            IM_PublicInterface.ShowIngredientList(list);

            int answer = -1;
            while (answer < 0 || answer > list.Count - 1)
            {
                answer = Convert.ToInt32(GM_Methods.NumberOnlyInput(Console.ReadLine()));
                Console.Clear();
                Console.Write("Write the Number of the Ingredients which details you wish to see: ");
            }
        }
     
      
      
    }
}
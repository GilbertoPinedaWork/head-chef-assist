using System;
using System.Collections.Generic;

namespace ChefManager
{
    public class IM_PublicInterface
    {
        public static int ActionSelection(List<IngredientInfo> ingredientList)
        {
            int answerRead;
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to The Ingredient Managerv1");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("What Do You Want To Do?");
                Console.WriteLine("1 = Add An Ingredient\n2 = Delete An Ingredient");
                Console.WriteLine("3 = Modify An Existing Ingredient\n4 = View Ingredients" +
                                   "\n0 = Save & Exit");
                Console.Write("Answer : ");

                answerRead = GM_Methods.NumberOnlyInput(Console.ReadLine(), 3);
                Console.Clear();
            } while (answerRead<0);
            IM_Modifier.Action(answerRead,ingredientList);
            return answerRead;
        }
        private static string ISetName()
        {
            Console.Write("Name:");
            return Console.ReadLine();
        }
        private static double ISetCost(string currentScreen)
        {
            double input;
            do
            {
                Console.Clear();
                Console.WriteLine(currentScreen);
                Console.Write("Cost:");
            } while (double.TryParse(Console.ReadLine(), out input) == false);

            return input;
        }
        private static string ISetDescription()
         {
            Console.Write("Description:");
            string input = "";
            string temp = "";
            do
            {
              input += temp;
              temp = Console.ReadLine();
                    
            } while (temp != "");

          return input;
        }

        private static string ISetUnit()
        {
            Console.Write("Unit:");
            return Console.ReadLine();
        }
        public static IngredientInfo IAddIngredient()
        {
            Console.WriteLine("Setup New Ingredient: ");
            var ingredient = new IngredientInfo
            {
                Name = ISetName(), Description = ISetDescription()
            };
            ingredient.Cost = ISetCost("Setup New Ingredient: " + "\nName:" + ingredient.Name);
            ingredient.MeasurementUnit = ISetUnit();
            return ingredient;
        }
        public static int IDeleteIngredient()
        {
            Console.WriteLine("Write The Number of The Ingredient You Wish To Delete : ");
            int id;
            do
            {
                id = GM_Methods.NumberOnlyInput(Console.ReadLine());
            } while (id == -1);

            return id;
        }
        public  void ShowIngredientDetails(IngredientInfo ingredient)
        {
            Console.Clear();
            Console.WriteLine("Ingredient Details");
            Console.WriteLine("Name: "+ingredient.Name);
            Console.WriteLine("Description:"+ingredient.Description);
            Console.WriteLine("Cost: $"+ ingredient.Cost);
            Console.WriteLine("Yield: " + (ingredient.Yield) + "%");
            Console.WriteLine("Unit: "+ ingredient.MeasurementUnit);
        }
        public static void ShowIngredientList(IList<IngredientInfo> list)
        {
            Console.WriteLine("Ingredient List: ");
            foreach (var ingredient in list)
            {
                var index = list.IndexOf(ingredient); 
                Console.WriteLine(index+") "+ ingredient.Name);
            }
        } 
        
      /*   private static void Tutorial(List<IngredientInfo> ingredientList)
        {
            var imanager = new IM_Modifier();
            //Add Ingredient
            do
            {
                Console.Clear();
                Console.WriteLine("Since This is Your First Time Using"+
                                  "\nIngredient Manager a Quick Tutorial");
                Console.WriteLine("Will Show You Around Enjoy!");
                Console.WriteLine("\nPress Any Key To Begin...");
                Console.ReadKey();
                Console.Clear();
                
                Console.WriteLine("\n\nFirst We Will Add an Ingredient");
                Console.Write("Press 1 Then Enter: ");
            } while (Console.ReadLine() != "1");
            
            Console.Clear();
            imanager.AddIngredient(ingredientList);
            do
            {
                Console.Clear();
                Console.WriteLine("Now We Are Going to View The Ingredient List");
                Console.Write("\nPress 4 Then Enter: ");
            } while (Console.ReadLine() != "4");

            Console.Clear();
            Console.WriteLine("This Is Your Ingredient List");
            Console.WriteLine("Now Press 0 Then Enter");
            
            imanager.ViewIngredientDetails(ingredientList);
            Console.WriteLine("This Will Show You The Details of The Ingredient You Chose");
            Console.WriteLine("\nPress Any Key To Continue...");
            Console.ReadKey();
            do
            {
                Console.Clear();
                Console.Write("Now Press 3 Then Enter to Modify The Data of An Ingredient: ");
            } while (Console.ReadLine() != "3");

            Console.WriteLine("Press 0 and fill the spaces with new information");
            
            imanager.ModifyIngredient(ingredientList);
            do
            {
                Console.Clear();
                Console.Write("Now let's Check the details of our ingredient again enter 4 then enter 0");
            } while (Console.ReadLine() != "4");

            imanager.ViewIngredientDetails(ingredientList);
            
            Console.WriteLine("\nPress Any Key To Continue");
            Console.ReadKey();
            do
            {
                Console.Clear();
                Console.WriteLine("Ingredient Updated!\n Now Press 2 Then Enter to Delete an Ingredient: ");
            } while (Console.ReadLine() != "2");

            Console.WriteLine("Now Press 0 Then Write Yes ");
            imanager.DeleteIngredient(ingredientList);

            Console.Clear();
            Console.WriteLine("Now Press 4 Then Enter to View The Ingredient List:");
            IM_PublicInterface.ShowIngredientList(ingredientList);
            Console.WriteLine("No Ingredient Is Shown Because The List Is Empty");
            Console.WriteLine("\n This  Is It for the Ingredient Manager Tutorial\n"+
                              "Now Press any key to go to Main Menu");
            Console.ReadKey();
        }*/
    }
}
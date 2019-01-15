using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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
                Console.WriteLine("3 = Modify An Existing Ingredient\n4 = View Ingredient");
                Console.WriteLine( "\n0 = Save & Exit");
                Console.Write("Answer : ");

                answerRead = GM_Methods.NumberOnlyInput(Console.ReadLine(), 3);
                Console.Clear();
                
            } while (answerRead<0);
            
            IM_Modifier.Action(answerRead,ingredientList);
            return answerRead;
        }
        private static string InputName()
        {
            string input;
            do
            {
                Console.Clear();
                Console.Write("Name:");
                input = GM_Methods.WordFirstInput(Console.ReadLine());

            } while (input == "");

            return input;
        }
        private static double InputCost(string currentScreen)
        {
            double input;
            do
            {
                Console.Clear();
                Console.WriteLine(currentScreen);
                Console.Write("Cost:");
                input = GM_Methods.DecimalOnlyInput(Console.ReadLine());
                
            } while ( input < 0.009);

            return input;
        }

        private static double InputYield(string currentScreen)
        {
            double input;
            do
            {
                Console.Clear();
                Console.WriteLine(currentScreen);
                Console.Write("Yield:");
                input = GM_Methods.DecimalOnlyInput(Console.ReadLine());
                
            } while ( input < 0.009);

            return input;
        }
        private static string InputDescription()
         {
            Console.Write("Description:");
            string input = "";
            string temp = "";
            do
            {
              input =$"{input} {temp}";
              temp = Console.ReadLine();
              temp = $"{temp} \n";

            } while (temp != "\n");

          return input;
        }
        private static string InputUnit(string screen)
        {
            string input;
            do
            {
                Console.Clear();
                Console.Write($"{screen} \nUnit:");
                input = GM_Methods.WordFirstInput(Console.ReadLine());
            } while (input=="");

            return input;
        }
        //TODO SEParate input from setting
        public static IngredientInfo InputAddIngredientProperties(bool modify = false)
        {
           
            var screenString = modify ? "Modify Ingredient" : "Create Ingredient:";
            Console.WriteLine(screenString);
            
            var ingredient = new IngredientInfo
            {
                Name = InputName(), Description = InputDescription()
            };
            
            screenString = $"{screenString}\nName: {ingredient.Name} \n Description {ingredient.Description}";
            ingredient.Cost = InputCost(screenString);
            
            screenString = $"{screenString} Cost: {ingredient.Cost}";
            ingredient.Unit = InputUnit(screenString);
            
            return ingredient;
        }
        private static string GetInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        public static string InputDeleteIngredient()
        {
           return GetInput("Write The Number of The Ingredient You Wish To Delete : ");
        }
        public static string InputModifyIngredient()
        {
            return GetInput("Write The Number of The Ingredient You Wish To Modify : ");
        }
        public static string InputShowIngredient()
        {
            Console.WriteLine("Write The Number of The Ingredient's Details You Wish To See : ");
            return Console.ReadLine();
        }

        public  static void ShowIngredientDetails(IngredientInfo ingredient)
        {
            Console.Clear();
            Console.WriteLine("Ingredient Details");
            Console.WriteLine($"Name: {ingredient.Name}");
            Console.WriteLine($"Description:{ingredient.Description}");
            Console.WriteLine($"Cost:{ingredient.Cost}" );
            Console.WriteLine($"Yield: {ingredient.Yield}%");
            Console.WriteLine($"Unit: {ingredient.Unit}" );
        }
        public static void ShowListOnScreen(IList<IngredientInfo> list)
        {
            Console.WriteLine("Ingredient List: ");
            foreach (var ingredient in list)
            {
                var index = list.IndexOf(ingredient); 
                Console.WriteLine($"{index}) {ingredient.Name}");
            }
        } 
        
    }
}
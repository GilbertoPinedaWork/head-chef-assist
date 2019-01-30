using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ChefManager
{
    public sealed class IM_PublicInterface
    {
        public static int ActionSelection()
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

                answerRead = GM_Methods.NumberOnlyInput(Console.ReadLine(), 4);
                Console.Clear();
                
            } while (answerRead<0);
            return answerRead;
        }
        public static string InputName()
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
        public static double InputCost()
        {
            double input;
            do
            {
                Console.Clear();
                Console.Write("Cost:");
                input = GM_Methods.DecimalOnlyInput(Console.ReadLine());
                
            } while ( input < 0.009);
            return input;
        }
        public static double InputYield()
        {
            double input;
            do
            {
                Console.Clear();
                Console.Write("Yield:");
                input = GM_Methods.DecimalOnlyInput(Console.ReadLine());
                
            } while ( input < 0.009);

            return input;
        }
        public static string InputDescription()
         {
            Console.Clear();
            Console.Write("Description:");
            string input = "";
            string temp = "";
            do
            {
              input =$"{input} {temp}";
              temp = Console.ReadLine();
              temp = $"{temp}\n";

            } while (temp != "\n");

          return input;
        }
        public static string InputUnit()
        {
            string input;
            do
            {
                Console.Clear();
                Console.Write("Unit:");
                input = GM_Methods.WordFirstInput(Console.ReadLine());
            } while (input=="");

            return input;
        }
        //TODO SEParate input from setting
       
        public static string InputDeleteIngredient()
        {
           return GM_Methods.GetInput("Write The Number of The Ingredient You Wish To Delete : ");
        }
        public static string InputModifyIngredient()
        {
            return GM_Methods.GetInput("Write The Number of The Ingredient You Wish To Modify : ");
        }
        public static string InputShowIngredient()
        {
            Console.WriteLine("Write The Number of The Ingredient's Details You Wish To See : ");
            return Console.ReadLine();
        }
        public  static void ShowIngredientDetails(Ingredient ingredient)
        {
            Console.Clear();
            Console.WriteLine("Ingredient Details");
            Console.WriteLine($"Name: {ingredient.Name}");
            Console.WriteLine($"Description:{ingredient.Description}");
            Console.WriteLine($"Cost:{ingredient.Cost}" );
            Console.WriteLine($"Yield: {ingredient.Yield}%");
            Console.WriteLine($"Unit: {ingredient.Unit}" );
        }
        public static void ShowListOnScreen(IList<Ingredient> list)
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
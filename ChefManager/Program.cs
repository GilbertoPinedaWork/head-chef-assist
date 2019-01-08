using System;
using System.IO;

namespace ChefManager
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
          var mainCaller =  new MainPrograms();
            int input;
            do
            {
              input = GM_Methods.NumberOnlyInput
              ("\tWelcome To Chef Manager"+
               "\n1 = Ingredient Manager" +
               "\n2 = Recipe Manager"+
               "\nAnswer: ");
                switch (input)
                {
                    case 1:
                    {
                        Console.Clear(); 
                        mainCaller.IngredientManagerMain();
                        break;
                    }
                }
            } while (input!=0);
        }
    }
}
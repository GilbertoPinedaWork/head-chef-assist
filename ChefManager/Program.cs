using System;
using System.IO;

namespace ChefManager
{
    internal class Program
    {
        public static void Main(string[] args)
        {
          var mainCaller =  new MainPrograms();
          var genericMethods = new GenericManagerMethods();
            int input;
            do
            {
              input = genericMethods.NumberOnlyInput
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
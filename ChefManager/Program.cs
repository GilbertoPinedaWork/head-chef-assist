using System;
using System.IO;

namespace ChefManager
{
    internal class Program
    {
        private static void CreateTextFile(string fileName)
        {
            var file = new FileInfo(fileName);
            var closebale = file.CreateText();
            closebale.Close();

        }

        
        private static void CreateNeccesaryFiles()
        {
            CreateTextFile("IngredientName.txt");
            CreateTextFile("IngredientCost.txt");
            CreateTextFile("IngredientYield.txt");
            CreateTextFile("IngredientUnit.txt");
            CreateTextFile("IngredientDescription.txt");
            CreateTextFile("IngredientQuantity.txt");
            CreateTextFile("Recipe");
        }
        
        public static void Main(string[] args)
        {
          var mainCaller =  new MainPrograms();
          var genericMethods = new GenericManagerMethods();
          FileInfo flag = new FileInfo("FirtsLoad.txt");
            if (flag.Length == 0)
            {
                CreateNeccesaryFiles();

                using (var writer = flag.CreateText())
                {
                    writer.Write("1");
                }
            }

            int input;
            do
            {
              input =  (int)genericMethods.ForceInputNumber
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
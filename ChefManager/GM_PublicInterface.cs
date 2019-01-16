using System;

namespace ChefManager
{
    public sealed class GM_PublicInterface
    {
        public static int ManagerSelection()
        {
                Console.Clear();
                Console.WriteLine("Welcome To your Chef Assistant\n" +
                                  "\n1=Ingredient Manager" + "\n2=RecipeManager" +
                                  "\n0=Exit");

                Console.Write("\nChoose Your Manager: ");
              
                return GM_Methods.NumberOnlyInput(Console.ReadLine(),2);
        }
        
    }
}
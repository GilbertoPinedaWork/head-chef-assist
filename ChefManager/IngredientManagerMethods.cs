using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Win32;


namespace  ChefManager
{
    public class IngredientManagerMethods : GenericManagerMethods
    {
      public List<IngredientInfo> IngredientList = new List<IngredientInfo>();
      public IngredientManagerMethods()
        {
            using (var veriFile = new StreamReader("IMTutorial.txt"))
            {
                if (veriFile.ReadLine() != null)
                {
                    ReadIngredientsFromFiles(IngredientList);
                    return;
                }
            }
            using (var writer = new StreamWriter("IMTutorial"))
            {
                writer.Write("1");
            }
            
            IngredientManagerMethods.Tutorial(IngredientList);
        }
      public static void IngredientListToFile(List<IngredientInfo> ingredientList)
        {
          foreach (var ingredient in ingredientList)
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
      private static void ReadIngredientsFromFiles(List<IngredientInfo> ingredientList)
        {
            var currentDirectory = new DirectoryInfo(Environment.CurrentDirectory);
            var ingredientFiles = currentDirectory.GetFiles();
            foreach (var file in ingredientFiles)
            {
                string[] ingredientData = File.ReadAllLines(file.Name).
                                SelectMany(s => s.Split('\n')).
                                ToArray();
                
                double.TryParse(ingredientData[1], out double cost);
                double.TryParse(ingredientData[2], out double yield);
                int.TryParse(ingredientData[4], out int quantity);
                
               ingredientList.Add(new IngredientInfo
               {
                   Name=ingredientData[0],
                   Cost = cost,
                   Yield = yield,
                   MeasurementUnit =ingredientData[3],
                   Quantity = quantity,
                   
               });
                
                var descriptionIndex = 5;
                do
                {
                    ingredientList[0].Description += ingredientData[descriptionIndex];
                    descriptionIndex++;
                } while (descriptionIndex < ingredientData.Length);
            }
        }
      public static string GetIngredientNames(List<IngredientInfo> list)
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
      private void ModifyIngredient(List<IngredientInfo> list)
       {
            if (list.Count == 0)
                return;
            
            int answer = -1;
            while(answer<0 || answer>list.Count-1)
                answer = Convert.ToInt32(NumberOnlyInput(GetIngredientNames(list)+
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
            
            newIngredient.Cost = NumberOnlyInput(tempString);

            tempString += (newIngredient.Cost+"\nIngredient Yield: ");
            newIngredient.Yield = NumberOnlyInput(tempString);

            tempString += (newIngredient.Yield + "\nIngredient Unit: ");
            Console.Write("Ingredient Unit: ");//TODO Restrict Unit
            newIngredient.MeasurementUnit = Console.ReadLine();

            tempString += (newIngredient.MeasurementUnit+"\nIngredient Description: ");
            Console.Clear();
            Console.Write(tempString);
            newIngredient.Description = Console.ReadLine();


        }
      private void AddIngredient(List<IngredientInfo>list)
        {
            var newIngredient = new IngredientInfo();
            
            string tempString = " ";
            while (tempString == " "){
                Console.Clear();
                Console.Write("Ingredient Name: ");
                tempString = Console.ReadLine();
            }
            newIngredient.Name = tempString;

            tempString = ("Ingredient Name: " + newIngredient.Name +
                          "\nIngredient Cost $");
            
            newIngredient.Cost = NumberOnlyInput(tempString);

            tempString += (newIngredient.Cost+"\nIngredient Yield: ");
            newIngredient.Yield = NumberOnlyInput(tempString);

            tempString += (newIngredient.Yield + "\nIngredient Unit: ");
            Console.Write("Ingredient Unit: ");//TODO Restrict Unit
            newIngredient.MeasurementUnit = Console.ReadLine();

            tempString += (newIngredient.MeasurementUnit+"\nIngredient Description: ");
            Console.Clear();
            Console.Write(tempString);
            newIngredient.SetDescription(Console.ReadLine());//TODO LOOP
            
            list.Add(newIngredient);
            
        }
      private void DeleteIngredient(List<IngredientInfo> list)
      {
            ViewIngredientList(list);
            Console.Write("Write The Number of the Ingredient you Wish to Delete:");
            int answer = -1;
            while(answer<0 || answer>list.Count-1)
                answer = Convert.ToInt32(NumberOnlyInput(Console.ReadLine()));
            
            Console.WriteLine("Are you Sure you want to delete? This action cannot be undone");
            Console.WriteLine("Yes or No?");
            string validAnswer = "";
            while (validAnswer != "yes" && validAnswer != "Yes" 
                  && validAnswer != "no" && validAnswer != "No")
                
            { validAnswer = Console.ReadLine();}
            
            if (validAnswer == "yes" || validAnswer == "Yes")
                list.RemoveAt(answer);
      }
      private void ViewIngredientDetails(List<IngredientInfo> list)
        {
            if (list.Count == 0)
                return;
            ViewIngredientList(list);
           
            
           
            int answer = -1;
            while (answer < 0 || answer > list.Count - 1)
            {
                answer = Convert.ToInt32(NumberOnlyInput(Console.ReadLine()));
                Console.Clear();
                Console.Write("Write the Number of the Ingredients which details you wish to see: ");
            }
            
            Console.Clear();
            Console.WriteLine("Name: "+list[answer].Name);
            Console.WriteLine("Description:"+list[answer].Description);
            Console.WriteLine("Cost: $"+ list[answer].Cost);
            
            if(list[answer].Yield>=1)//correcting Yield
                Console.WriteLine("Yield: " + (list[answer].Yield) + "%");
            else
                Console.WriteLine("Yield: " + (list[answer].Yield)*100 + "%");
            
            Console.WriteLine("Unit: "+ list[answer].MeasurementUnit);

            
        }
      private void ViewIngredientList(List<IngredientInfo> list)
        {
            foreach (var ingredient in list)
            {
                int index = list.IndexOf(ingredient); 
                Console.WriteLine(index+") "+ ingredient.Name);
            }
        } 
      private  static void Tutorial(List<IngredientInfo> ingredientList)
        {
            var imanager = new IngredientManagerMethods();

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
            imanager.ViewIngredientList(ingredientList);
            Console.WriteLine("No Ingredient Is Shown Because The List Is Empty");
            Console.WriteLine("\n This  Is It for the Ingredient Manager Tutorial\n"+
                              "Now Press any key to go to Main Menu");
            Console.ReadKey();
        }
      public  int MainMenu()
        {
            bool isANumber = false;
            int answerRead;
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to The Ingredient Managerv1");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("What Do You Want To Do?");
                Console.WriteLine("1 = Add An Ingredient\n2 = Delete An Ingredient");
                Console.WriteLine("3 = Modify An Existing Ingredient\n4 = View Ingredients\n0 = Save & Exit");
                Console.Write("Answer : ");

                isANumber = int.TryParse(Console.ReadLine(), out answerRead);

            } while (!isANumber && (answerRead < 0 || answerRead > 4));
            return answerRead;
        }
      public  int Action(int answer, List<IngredientInfo> ingredientList)
        { 
            switch (answer)
            {
                case 1:
                {
                    AddIngredient(ingredientList);
                    Console.WriteLine("\nPress Any Key to Return to Main Menu...");
                    Console.ReadKey();
                    break;
                }
                case 2:
                {
                    DeleteIngredient(ingredientList);
                    Console.WriteLine("\nPress Any Key to Return to Main Menu...");
                    Console.ReadKey();
                    break;
                }
                case 3:
                {
                    ModifyIngredient(ingredientList);
                    Console.WriteLine("\nPress Any Key to Return to Main Menu...");
                    Console.ReadKey();
                    break;
                }
                case 4:
                {
                    ViewIngredientDetails(ingredientList);
                    Console.WriteLine("\nPress Any Key to Return to Main Menu...");
                    Console.ReadKey();
                    break;
                }
                default:
                {
                    answer = -1;
                    break;
                }
            }
            return answer;
        }
    }
}
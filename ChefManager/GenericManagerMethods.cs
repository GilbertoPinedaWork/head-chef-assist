using System;
using System.Collections.Generic;
using System.IO;
namespace ChefManager
{
    public class GenericManagerMethods
    {

        public  double ForceInputNumber()//use .ToX to change to float int 
        {
            double answer = 0;
            bool notANumber = true;
            do
            {
                notANumber = !double.TryParse(Console.ReadLine(), out answer);
            } while (notANumber);

            return answer;
        }
        public  double ForceInputNumber(string message)//use .ToX to change to float int //clear before message
        {
            double answer =-1;
            bool notANumber = true;
            while (notANumber || answer<0)
            {
                Console.Clear();
                Console.Write(message);
               
                notANumber = !(double.TryParse(Console.ReadLine(), out answer));
               
            } 

            return answer;
        }
        public void  FileToList(string filePath, List<string> list)
        {
            using (var sreader = new StreamReader(filePath))
            {
                string item = " ";
                
                while(item!=null)
                {
                    item = sreader.ReadLine();
                    list.Add(item);
                }
            }
        }
       
        public  void ListToFile<T> (List<T> list , string fileName)
        { 
            using (var swriter = new StreamWriter(fileName))
            {
                foreach (var item in list)
                {
                    swriter.WriteLine(item);
                }
            }
        }
        public List<double> StringToDoubleLists(List<string> stringList)
        {
            var doubleList = new List<double>();
            doubleList.Capacity = stringList.Count-1;

            foreach (var doubleNumber in stringList)
            {
                doubleList.Add(Convert.ToDouble(doubleNumber));
            }

            return doubleList;
        }
        public List<IngredientInfo> StringToIngredientLists(List<string> stringList)
        {
            var ingredientList =  new List<IngredientInfo>();

            foreach (var item in stringList)
            {
                var ingredient = new IngredientInfo {Name = item};
                ingredientList.Add(ingredient);
            }

            return ingredientList; 
        }  
    }
}
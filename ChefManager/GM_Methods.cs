using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace ChefManager
{
    public sealed class GM_Methods
    {
        public static double DecimalOnlyInput(string input)
        {//look for a better place for this1
            if (input.Contains('%'))
            {
               input = input.Replace('%',' ');
            }

           var isAcceptedValue = double.TryParse(input, out var answer);
           return isAcceptedValue?  answer : 0.000;
        }
        public static int NumberOnlyInput(string input)
        {
            var isAcceptedValue = int.TryParse(input, out var answer);
            return isAcceptedValue ? answer : -1;
        }
        public static int NumberOnlyInput(string input, int max, int min = 0)
        {
            var aNumber = int.TryParse(input, out var answer);
            var isAcceptedValue = !(aNumber == false || answer > max || answer < min);
           return  isAcceptedValue? answer : -1;
               
        }
        public static string WordFirstInput(string input)
        {
            char[] numbers = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            return numbers.Contains(input[0])? "" : input;
        }
        public static void MakeSureFolderExist(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        
        public static string GetInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}
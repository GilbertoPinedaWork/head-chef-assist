using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChefManager
{
    public class GM_Methods
    {
        public static double DecimalOnlyInput(string input)
        {
            if (double.TryParse(input, out var answer) == false)
                return 0.000;
            return answer;
        }
        public static int NumberOnlyInput(string input)//use .ToX to change to float int 
        {
            var aNumber = int.TryParse(input, out var answer);
            if (aNumber == false)
               return -1;
               return answer;
        }

        public static int NumberOnlyInput(string input, int max, int min = 0)
        {
            var aNumber = int.TryParse(input, out var answer);
            if (aNumber == false || answer>max || answer<min)
                return -1;
            return answer;
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
    }
}
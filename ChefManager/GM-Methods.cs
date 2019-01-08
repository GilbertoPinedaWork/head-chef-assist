using System;
using System.Collections.Generic;
using System.IO;
namespace ChefManager
{
    public class GM_Methods
    {
        public static int NumberOnlyInput(string input)//use .ToX to change to float int 
        {
           bool aNumber = int.TryParse(input, out var answer);
            if (aNumber == false)
               return -1;
               return answer;
        }

        public static int NumberOnlyInput(string input, int max, int min = 0)
        {
            bool aNumber = int.TryParse(input, out var answer);
            if (aNumber == false || answer>max || answer<min)
                return -1;
            return answer;
        }
      
    }
}
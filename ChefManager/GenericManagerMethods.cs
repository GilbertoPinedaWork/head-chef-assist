using System;
using System.Collections.Generic;
using System.IO;
namespace ChefManager
{
    public class GenericManagerMethods
    {

        public  int NumberOnlyInput(string input)//use .ToX to change to float int 
        {
            bool aNumber = int.TryParse(input, out var answer);
            if (aNumber == false)
               return -1;
            
               return answer;
        }
      
    }
}
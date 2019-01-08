using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChefManager
{
    public class IngredientInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }// Use SetDescription to set it
        public string MeasurementUnit { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }
        public double Yield { get; set; }
       
        public void ToFile()
        {
            using (var fWriter = new StreamWriter(Name + ".ing"))
            {
                fWriter.WriteLine(Name); 
                fWriter.WriteLine(Cost); 
                fWriter.WriteLine(Yield);  
                fWriter.WriteLine(MeasurementUnit);   
                fWriter.WriteLine(Quantity); 
                fWriter.WriteLine(Description);  
            }
        }
    }
}    

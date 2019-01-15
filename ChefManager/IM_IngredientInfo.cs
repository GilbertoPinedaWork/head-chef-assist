using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChefManager
{
    public struct IngredientInfo{
        public string Name { get; set; }
        public double Cost { get; set; }
        public double Yield { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
       
        public void ToFile()
        {
            using (var fWriter = new StreamWriter(Name + ".txt"))
            {
                fWriter.Write(Name + "\t" +
                              Cost + "\t" +
                              Yield + "\t" +
                              Unit + "\t" +
                              Description);
            }
        }
    }
}    

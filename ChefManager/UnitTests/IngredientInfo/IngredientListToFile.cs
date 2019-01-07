using NUnit.Framework;
using ChefManager;
using System.Collections.Generic;
using System.IO;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[TestFixture]
public class IngredientListToFile
{
    [Test]
    public void  Default_Ingredient_List_Received()
    {
        var ingredient = new IngredientInfo
        {   Cost = 5,
            Name = "Coal",
            Description = "A Fresh Coal",
            Yield = .4,
            MeasurementUnit = "g",
            Quantity = 1
        };
        
        var ingredient2 = new IngredientInfo
        {   Cost = 6,
            Name = "Goal",
            Description = "B Fresh Coal",
            Yield = .4,
            MeasurementUnit = "g",
            Quantity = 1
        };
            
        var ingredientList = new List<IngredientInfo> {ingredient, ingredient2};

        string workingDir = Environment.CurrentDirectory;
        Environment.CurrentDirectory =
            "C:\\Users\\pined\\Documents";
        
        using (StreamWriter swriter = new StreamWriter("TestFile.tst"))
        using (StreamWriter swriter2 = new StreamWriter("TestFile2.tst"))
        {
            
            swriter.Write("Coal\n5\n0.4\ng\n1\nA Fresh Coal");
            swriter2.Write("Goal\n6\n0.4\ng\n1\nB Fresh Coal");
            
        }  
        IngredientManagerMethods.IngredientListToFile(ingredientList);
        
        using (StreamReader destinationReader = new StreamReader(ingredient.Name + ".ing"))
        using(StreamReader expectedReader = new StreamReader("TestFile.tst"))
            
        using(StreamReader destinationReader2 = new StreamReader(ingredient2.Name + ".ing"))
        using(StreamReader expectedReader2 = new StreamReader("TestFile2.tst"))
        {
            string line = expectedReader.ReadLine();
            do
            {
                Assert.AreEqual(line, destinationReader.ReadLine());
                Assert.AreEqual(expectedReader2.ReadLine(), destinationReader2.ReadLine());
                line = expectedReader.ReadLine();
            } while (line != null);
        } 
        File.Delete(Environment.CurrentDirectory+"\\TestFile.tst");
        File.Delete(Environment.CurrentDirectory+"\\TestFile2.tst");
        File.Delete(Environment.CurrentDirectory+"\\Coal.ing");
        File.Delete(Environment.CurrentDirectory+"\\Goal.ing");
        Environment.CurrentDirectory = workingDir;
    }
    
}
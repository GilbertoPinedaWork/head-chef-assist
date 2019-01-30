using System;
using System.Collections.Generic;
using System.IO;
using ChefManager;
using NUnit.Framework;

[TestFixture]
public class IngredientToFileTest
{
    [Test]
    public void Default_Ingredient_Received()
    {
       
        var ingredient = new Ingredient
        {   Cost = 5,
            Name = "Coal",
            Description = "A Fresh Coal",
            Yield = .3,
            Unit = "g",
            Quantity = 1
        };

        string workingDir = Environment.CurrentDirectory;
        Environment.CurrentDirectory =
            "C:\\Users\\pined\\Documents";
        
        using (var swriter = new StreamWriter("TestFile.tst"))
        {
            swriter.Write("Coal\n5\n0.3\ng\n1\nA Fresh Coal");
        }  
           ingredient.ToFile();
        
        using (StreamReader destinationReader = new StreamReader(ingredient.Name + ".ing"))
        using (StreamReader expectedReader = new StreamReader("TestFile.tst"))
        {
            string line = expectedReader.ReadLine();
            do
            {
                Assert.AreEqual(line, destinationReader.ReadLine());
                line = expectedReader.ReadLine();
            } while (line != null);
        }
        
        var file =new FileInfo("TestFile.tst");
        file.Delete();
        Environment.CurrentDirectory = workingDir;
    }   
}
    
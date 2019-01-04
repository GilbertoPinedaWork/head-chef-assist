using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using ChefManager;

[TestFixture]
public class ReadIngredientFromFileTest
{
    [Test]
    public void Default_File()
    {
        var workingDir = Environment.CurrentDirectory;
        Environment.CurrentDirectory = "C:\\Users\\pined\\Documents";
            
        using (var file = new StreamWriter("MockIngredient.tst"))
        {
            file.Write("Goal\n6\n0.4\ng\n1\nfresh goal");
        }
        
        var ingredientList = new List<IngredientInfo>();
        IngredientInfo.ReadIngredientsFromFiles(ingredientList);

        Assert.AreEqual(ingredientList[0].Name, "Goal");
        Assert.AreEqual(ingredientList[0].Cost, "6");
        Assert.AreEqual(ingredientList[0].Yield, 0.4);
        Assert.AreEqual(ingredientList[0].MeasurementUnit, "g");
        Assert.AreEqual(ingredientList[0].Quantity, 1);
        Assert.AreEqual(ingredientList[0].Description, "fresh goal");

        var filEnd = new FileInfo("MockIngredient.tst");
            filEnd.Delete();
        Environment.CurrentDirectory = workingDir;
    }
    
}
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
        using (var file = new StreamWriter("MockIngredient.tst"))
        {
            file.Write("Goal\n6\n.4\ng\n1\nfresh goal");
        }
        
        
        var ingredientList = new List<IngredientInfo>();
        Environment.CurrentDirectory =
            "C:\\Users\\pined\\Documents\\repos\\Head-Chef\\" +
            "head-chef-assist\\ChefManager\\UnitTests\\IngredientInfo";
        
        IngredientInfo.ReadIngredientsFromFiles(ingredientList);

        Assert.AreEqual(ingredientList[0].Name, "Goal");
        Assert.AreEqual(ingredientList[0].Cost, "6");
        Assert.AreEqual(ingredientList[0].Yield, .4);
        Assert.AreEqual(ingredientList[0].MeasurementUnit, "g");
        Assert.AreEqual(ingredientList[0].Description, "fresh goal");

        var filEnd = new FileInfo("MockIngredient.tst");
            filEnd.Delete();
        
    }
    
}
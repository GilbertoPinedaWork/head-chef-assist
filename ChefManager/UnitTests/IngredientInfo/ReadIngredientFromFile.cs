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
        DirectoryInfo mockFolder = new DirectoryInfo("\\MockIngredients");
        var ingredient = new IngredientInfo();
        IngredientInfo.ReadIngredientFromFile(ingredient, "MockIngredients");

        Assert.Equals(ingredient.Name, "Goal");
        Assert.Equals(ingredient.Cost, "6");
        Assert.Equals(ingredient.Yield, .4);
        Assert.Equals(ingredient.MeasurementUnit, "g");
        Assert.Equals(ingredient.Description, "fresh goal");
    }
    
}
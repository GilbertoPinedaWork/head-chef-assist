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
        var ingredient = new IngredientInfo
        {   Cost = 5,
            Name = "Coal",
            Description = "A Fresh Coal",
            Yield = .3,
            MeasurementUnit = "g",
            Quantity = 1
        };
        using (StreamWriter swriter = new StreamWriter("TestFile.tst"))
        {
            swriter.Write("Coal\n5\n.3\ng\n1\nA Fresh Coal");
        }  
            IngredientInfo.IngredientToFile(ingredient, destination);
        
        using (StreamReader destinationReader = new StreamReader(ingredient.Name + ".ing"))
        using(StreamReader expectedReader = new StreamReader("TestFile.tst"))
        {
            Assert.Equals(expectedReader.ReadToEnd(), destinationReader.ReadToEnd());
        }
    }   
}
    
using System.Collections.Generic;
using System.IO;
using ChefManager;
using NUnit.Framework;

[TestFixture]
public class WritePropertiesToFileTest
{
    [Test]
    public void IngredientToFile()
    {
        var ingredient = new IngredientInfo
        {   Cost = 5,
            Name = "Coal",
            Description = "A Fresh Coal",
            Yield = .3,
            MeasurementUnit = "g",
            Quantity = 1
        };
        using (MemoryStream mstream = new MemoryStream())
        {
            
            IngredientInfo.IngredientToFile(ingredient, destination);

            Assert()
        }
    }
        
    [Test]
    public void NullProperties()
    {
        
    }
    
}
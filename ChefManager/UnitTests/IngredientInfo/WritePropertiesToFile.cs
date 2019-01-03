using ChefManager;
using NUnit.Framework;

[TestFixture]
public class WritePropertiesToFileTest
{
    [Test]
    public void AllPropertiesToFiles()
    {
        var ingredient = new IngredientInfo
        {   Cost = 5,
            Name = "Coal",
            Description = "A Fresh Coal",
            Yield = .3,
            MeasurementUnit = "g",
            Quantity = 1
        };
        
     

    }

    [Test]
    public void NullProperties()
    {
        
    }
    
}
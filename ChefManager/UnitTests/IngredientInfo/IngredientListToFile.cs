using NUnit.Framework;
using ChefManager;
using System.Collections.Generic;
using System.IO;
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
            Yield = .3,
            MeasurementUnit = "g",
            Quantity = 1
        };
        
        var ingredient2 = new IngredientInfo
        {   Cost = 6,
            Name = "Goal",
            Description = "B Fresh Coal",
            Yield = .4,
            MeasurementUnit = "tz",
            Quantity = 1
        };

        var ingredientList = new List<IngredientInfo> {ingredient, ingredient2};
        
        using (StreamWriter swriter = new StreamWriter("TestFile.tst"))
        using (StreamWriter swriter2 = new StreamWriter("TestFile2.tst"))
        {
            
            swriter.Write("Coal\n5\n.3\ng\n1\nA Fresh Coal");
            swriter2.Write("Goal\n6\n.3\ng\n1\nA Fresh Coal");
            
        }  
        IngredientInfo.IngredientListToFile(ingredientList, destination);
        
        using (StreamReader destinationReader = new StreamReader(ingredient.Name + ".ing"))
        using(StreamReader expectedReader = new StreamReader("TestFile.tst"))
            
        using(StreamReader destinationReader2 = new StreamReader(ingredient2.Name + ".ing"))
        using(StreamReader expectedReader2 = new StreamReader("TestFile2.tst"))
        {
            Assert.Equals(expectedReader.ReadToEnd(), destinationReader.ReadToEnd());
            Assert.Equals(expectedReader2.ReadToEnd(), destinationReader2.ReadToEnd());
        } 
        
    }
    
}
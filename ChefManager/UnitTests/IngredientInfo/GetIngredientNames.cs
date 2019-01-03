using NUnit.Framework;
using ChefManager;
using System.Collections.Generic;

[TestFixture]
public class GetIngredientNames
{
    [Test]
    public void Default_Case()
    {
        var list = new List<IngredientInfo>
        {
            new IngredientInfo {Name = "Coal"}
        };

        var ingredientNames = IngredientInfo.GetIngredientNames(list);

        Assert.AreEqual("Coal", ingredientNames);
    }
    
    [Test]
    public void Receeive_Multiple_Ingredients()
    {
        var list = new List<IngredientInfo>
        {
            new IngredientInfo {Name = "Coal"},
            new IngredientInfo {Name = "Chicken"}
        };
        
        var ingredientNames = IngredientInfo.GetIngredientNames(list);
        
        Assert.AreEqual("1)Coal\n2)Chicken",ingredientNames);
    }
    
}
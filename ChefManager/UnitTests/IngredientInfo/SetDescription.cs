using ChefManager;
using NUnit.Framework;

[TestFixture]
public class SetDescriptionTest
{
    [Test]
    public void Receive_One_Line_Input()
    {
        var ingredient = new IngredientInfo();
        string description = "A Fresh Tasty Ingredient";
        
        ingredient.SetDescription(description);
        
        Assert.AreEqual(description,ingredient.Description);
    }
    
    [Test]
    public void Receive_MultiLine_Input()
    {
        var ingredient = new IngredientInfo();
        string[] multlineDescription = {"A Tasty, ","Fresh Ingredient","" };

        string temp = multlineDescription[0];
        for (int i = 1; i < multlineDescription.Length; i++)
        {
            ingredient.SetDescription(multlineDescription[i],temp);
        }
        
        Assert.AreEqual("A Tasty, Fresh Ingredient",ingredient.Description);
    }
}
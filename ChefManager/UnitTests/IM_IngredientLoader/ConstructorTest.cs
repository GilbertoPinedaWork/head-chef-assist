using System;
using System.IO;
using NUnit.Framework;
using ChefManager;

[TestFixture]
public class IM_IngredientLoaderTest
{
    [Test]
    public void LoadExistingFiles()
    {
        //Setup
        var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\IngredientsTest";
        var ingFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\IngredientsTest\\Test";
        Directory.CreateDirectory(folderPath);
        
        using (var fwriter = new StreamWriter(ingFilePath))
        {
            fwriter.WriteLine("Name");
            fwriter.WriteLine("1.33");
            fwriter.WriteLine("1.22");
            fwriter.WriteLine("g");
            fwriter.WriteLine("1");
            fwriter.WriteLine("ThisIs\nAMultiline\nDescription");
        }
        
        //Test
        var loader = new IM_IngredientLoader();
       Assert.AreEqual("Name", loader.IngredientList[0].Name);
       Assert.AreEqual(1.33,loader.IngredientList[0].Cost);
       Assert.AreEqual("ThisIsAMultilineDescription",loader.IngredientList[0].Description);
       
       //CleanUp
       File.Delete(ingFilePath);
       Directory.Delete(folderPath);
       
    }
    
}
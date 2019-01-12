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
        var ingFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\IngredientsTest\\Test.txt";
        Directory.CreateDirectory(folderPath);
        
        using (var fileWriter = new StreamWriter(ingFilePath))
        {
            fileWriter.Write("Name" +
                             "\t1.33" +
                             "\t1.22" +
                             "\tg" +
                             "\t1" +
                             "\tThisIs" +
                             "\tAMultiline" +
                             "\tDescription");
        }
        
        //Test
        var loader = new IM_IngredientLoader(folderPath);
        
       Assert.AreEqual("Name", loader.IngredientList[0].Name);
       Assert.AreEqual(1.33,loader.IngredientList[0].Cost);
       Assert.AreEqual("ThisIsAMultilineDescription",loader.IngredientList[0].Description);
       
       //CleanUp
       File.Delete(ingFilePath);
       Directory.Delete(folderPath);
       
    }
    
}
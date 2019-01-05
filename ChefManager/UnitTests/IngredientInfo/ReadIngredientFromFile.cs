using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using ChefManager;

[TestFixture]
public class ReadIngredientFromFileTest
{
   
     private readonly string  workingDir = Environment.CurrentDirectory;
     private DirectoryInfo testFolder = new DirectoryInfo("C:\\Users\\pined\\Documents\\IngredientInfoTest");

    [Test]
    public void DirectoryCreation()
    {
        testFolder.Create();
    }
    [Test]
    public void Default_File()
    {
        Environment.CurrentDirectory = testFolder.FullName;
           
        using (var file = new StreamWriter("MockIngredient.tst"))
        {
            file.Write("Goal\n6\n0.4\ng\n1\nfresh goal");
        }
        
        var ingredientList = new List<IngredientInfo>();
        IngredientInfo.ReadIngredientsFromFiles(ingredientList);

        Assert.AreEqual(ingredientList[0].Name, "Goal");
        Assert.AreEqual(ingredientList[0].Cost, "6");
        Assert.AreEqual(ingredientList[0].Yield, 0.4);
        Assert.AreEqual(ingredientList[0].MeasurementUnit, "g");
        Assert.AreEqual(ingredientList[0].Quantity, 1);
        Assert.AreEqual(ingredientList[0].Description, "fresh goal");

        var filEnd = new FileInfo("MockIngredient.tst");
            filEnd.Delete();
       
    }
    [Test]
    public void DirectoryReset()
    {
        Environment.CurrentDirectory = workingDir;
        Assert.AreEqual(Environment.CurrentDirectory,workingDir);
        testFolder.Delete();
    }
}
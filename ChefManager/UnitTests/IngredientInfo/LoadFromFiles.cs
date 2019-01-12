using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using ChefManager;

[TestFixture]
public class ReadIngredientFromFileTest: IM_Modifier
{
   
     private readonly string  workingDir = Environment.CurrentDirectory;
     private readonly DirectoryInfo testFolder = new DirectoryInfo("C:\\Users\\pined\\Documents");
   
    [Test]
    public void Default_File()
    {
        testFolder.CreateSubdirectory("TestFolder");
        Environment.CurrentDirectory = testFolder.FullName+"\\TestFolder";
           
        using (var file = new StreamWriter("MockIngredient.tst"))
        {
            file.Write("Goal\n6\n0.4\ng\n1\nfresh goal");
        }

        var imanager = new IM_IngredientLoader(testFolder.ToString());
        var ingredientList = imanager.IngredientList.ToList();
       

        Assert.AreEqual(ingredientList[0].Name, "Goal");
        Assert.AreEqual(ingredientList[0].Cost, 6.0);
        Assert.AreEqual(ingredientList[0].Yield, 0.4);
        Assert.AreEqual(ingredientList[0].MeasurementUnit, "g");
        Assert.AreEqual(ingredientList[0].Quantity, 1);
        Assert.AreEqual(ingredientList[0].Description, "fresh goal");

        var filEnd = new FileInfo("MockIngredient.tst");
        filEnd.Delete();
        Environment.CurrentDirectory = workingDir;
       //TODO FIX Exception testFolder.Delete();
       
    }
}
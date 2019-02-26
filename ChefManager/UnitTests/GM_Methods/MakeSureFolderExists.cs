using System;
using System.IO;
using ChefManager;
using NUnit.Framework;

[TestFixture]
public class MakeSureFolderExists
{
    [Test]
    public void DoesntExists()
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\IngredientsTest";
        
        GM_Methods.MakeSureFolderExist(path);
        
        Assert.AreEqual(true,Directory.Exists(path));
        
        Directory.Delete(path);
    }
    
    [Test]
    public void Exists()
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\IngredientsTest";
        Directory.CreateDirectory(path);
        
        GM_Methods.MakeSureFolderExist(path);
        
        Assert.AreEqual(true,Directory.Exists(path));
        
        Directory.Delete(path);
    }
    
}
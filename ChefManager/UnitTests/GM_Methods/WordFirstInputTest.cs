using ChefManager;
using NUnit.Framework;

[TestFixture]
public class WordFirstInputTest
{
    [Test]
    public void ReceiveNumberFirst()
    {
        string input = "1L";
        string result = GM_Methods.WordFirstInput(input);
        
        Assert.AreEqual(string.Empty, result);

    }
    [Test]
        public void ReceiveNumberLetter()
        {
            string input = "L1";
            string result = GM_Methods.WordFirstInput(input);
            
            Assert.AreEqual("L1", result);
    
        }
        [Test]
                public void ReceiveEmpty()
                {
                    string input = " ";
                    string result = GM_Methods.WordFirstInput(input);
                    
                    Assert.AreEqual(" ", result);
            
                }
    
}
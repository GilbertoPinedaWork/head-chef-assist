using NUnit.Framework;

namespace ChefManager.UnitTests.GM_Methods
{
   [TestFixture]
   public class NumberOnlyInputMinTest
   {
       [Test]
       public void ReceiveOverTheLimitInteger()
       {
           const string input = "2";
           var output = ChefManager.GM_Methods.NumberOnlyInput(input,1);
           
           Assert.AreEqual(-1,output);
       }
       [Test]
       public void ReceiveInteger()
       {
           const string input = "0";
           var output = ChefManager.GM_Methods.NumberOnlyInput(input,1);
           
           Assert.AreEqual(0,output);
       }

       [Test]
       public void ReceiveFloat()
       {
           const string input = "1.1";
           var output = ChefManager.GM_Methods.NumberOnlyInput(input,2);
           
           Assert.AreEqual(-1,output);
       }

       [Test]
       public void ReceiveLetters()
       {
           const string input = "test";
           var output = ChefManager.GM_Methods.NumberOnlyInput(input,2);
           
           Assert.AreEqual(-1,output);
       }

       [Test]
       public void ReceiveEmptyString()
       {
           const string input = "";
           var output =ChefManager.GM_Methods.NumberOnlyInput(input,2);
           
           Assert.AreEqual(-1,output);
       }

       [Test]
       public void ReceiveNull()
       {
           const string input = null;
           var output = ChefManager.GM_Methods.NumberOnlyInput(input,2);
           
           Assert.AreEqual(-1,output);
       }
   }
}
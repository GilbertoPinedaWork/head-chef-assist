using NUnit.Framework;

namespace ChefManager.UnitTests.GenericManagerMethods
{
   [TestFixture]
   public class ForceInputNumberTest
   {
      
       [Test]
       public void ReceiveInteger()
       {
           const string input = "0";
           var output = GM_Methods.NumberOnlyInput(input);
           
           Assert.AreEqual(0,output);
       }

       [Test]
       public void ReceiveFloat()
       {
           const string input = "1.1";
           var output = GM_Methods.NumberOnlyInput(input);
           
           Assert.AreEqual(-1,output);
       }

       [Test]
       public void ReceiveLetters()
       {
           const string input = "test";
           var output = GM_Methods.NumberOnlyInput(input);
           
           Assert.AreEqual(-1,output);
       }

       [Test]
       public void ReceiveEmptyString()
       {
           const string input = "";
           var output =GM_Methods.NumberOnlyInput(input);
           
           Assert.AreEqual(-1,output);
       }

       [Test]
       public void ReceiveNull()
       {
           var classBeingTested = new ChefManager.GM_Methods();
           const string input = null;
           
           var output = GM_Methods.NumberOnlyInput(input);
           
           Assert.AreEqual(-1,output);
       }
   }
}
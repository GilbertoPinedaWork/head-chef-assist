using NUnit.Framework;

namespace ChefManager.UnitTests.GenericManagerMethods
{
   [TestFixture]
   public class ForceInputNumberTest
   {
      
       [Test]
       public void ReceiveInteger()
       {
           var classBeingTested = new ChefManager.GenericManagerMethods();
           const string input = "0";

           var output = classBeingTested.NumberOnlyInput(input);
           
           Assert.AreEqual(0,output);
       }

       [Test]
       public void ReceiveFloat()
       {
           var classBeingTested = new ChefManager.GenericManagerMethods();
           const string input = "1.1";
           
           var output = classBeingTested.NumberOnlyInput(input);
           
           Assert.AreEqual(-1,output);
       }

       [Test]
       public void ReceiveLetters()
       {
           var classBeingTested = new ChefManager.GenericManagerMethods();
           const string input = "test";
           
           var output = classBeingTested.NumberOnlyInput(input);
           
           Assert.AreEqual(-1,output);
       }

       [Test]
       public void ReceiveEmptyString()
       {
           var classBeingTested = new ChefManager.GenericManagerMethods();
           const string input = "";
           
           var output = classBeingTested.NumberOnlyInput(input);
           
           Assert.AreEqual(-1,output);
       }

       [Test]
       public void ReceiveNull()
       {
           var classBeingTested = new ChefManager.GenericManagerMethods();
           const string input = null;
           
           var output = classBeingTested.NumberOnlyInput(input);
           
           Assert.AreEqual(-1,output);
       }
   }
}
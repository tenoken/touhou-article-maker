using Microsoft.VisualStudio.TestTools.UnitTesting;
using TouhouArticleMaker.Domain;

namespace TouhouArticleMaker.Tests
{
    [TestClass]
    public class NameTests
    {
        private const string INVALID_NAME = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";

        [TestMethod]
        public void Should_ReturnTrue_When_Given_ValidName()
        {
            var name = new Name("Jhon","Smith");            
               Assert.IsTrue(name.IsValid);     
        }

        [TestMethod]
        public void Should_ReturnFalse_When_Given_EmptyName()
        {
            var name = new Name("","");            
           Assert.IsFalse(name.IsValid);
        }

        [TestMethod]
        public void Should_ReturnFalse_When_Given_ShortName()
        {
            var name = new Name("Jh","Sm");            
            Assert.IsFalse(name.IsValid);
        }

        [TestMethod]
        public void Should_ReturnFalse_When_Given_LargeName()
        {
            var firstName = INVALID_NAME;
            var lastName = INVALID_NAME;
            var name = new Name(firstName, lastName);            
            Assert.IsFalse(name.IsValid);  
        }

          [TestMethod]
        public void Should_ReturnFalse_When_Given_LargeFirstName()
        {
            var firstName = INVALID_NAME;
            var lastName = "Smith";
            var name = new Name(firstName, lastName);            
            Assert.IsFalse(name.IsValid);  
        }

          [TestMethod]
        public void Should_ReturnFalse_When_Given_LargeLastName()
        {
            var firstName = "Jhon";
            var lastName = INVALID_NAME;
            var name = new Name(firstName, lastName);            
            Assert.IsFalse(name.IsValid);  
        }
    }
}
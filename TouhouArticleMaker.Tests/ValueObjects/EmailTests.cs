using Microsoft.VisualStudio.TestTools.UnitTesting;
using TouhouArticleMaker.Domain;

namespace TouhouArticleMaker.Tests
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        public void Should_ReturnTrue_When_Given_ValidEmail()
        {
            var email = new Email("Smith.Jhon@gmail.com");            
            Assert.IsTrue(email.IsValid);     
        }

        [TestMethod]
        public void Should_ReturnFalse_When_Given_EmptyEmail()
        {
            var email = new Email("");                     
            Assert.IsFalse(email.IsValid);
        }

        [TestMethod]
        public void Should_ReturnFalse_When_Given_InvalidEmail()
        {
            var email = new Email("Smith@g.");            
            Assert.IsFalse(email.IsValid);
        }
    }
}
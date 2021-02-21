using Microsoft.VisualStudio.TestTools.UnitTesting;
using TouhouArticleMaker.Domain;

namespace TouhouArticleMaker.Tests
{
    [TestClass]
    public class TitleTests
    {
        [TestMethod]
        public void Should_ReturnTrue_When_Given_ValidTitle()
        {
            var email = new Title("It is a title about Jhon Smith.");            
            Assert.IsTrue(email.IsValid);     
        }

        [TestMethod]
        public void Should_ReturnFalse_When_Given_EmptyTitle()
        {
            var email = new Title("");                     
            Assert.IsFalse(email.IsValid);
        }

        [TestMethod]
        public void Should_ReturnFalse_When_Given_InvalidTitle()
        {
            var email = new Title("S");            
            Assert.IsFalse(email.IsValid);
        }
    }
}
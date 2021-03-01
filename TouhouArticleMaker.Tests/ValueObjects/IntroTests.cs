using Microsoft.VisualStudio.TestTools.UnitTesting;
using TouhouArticleMaker.Domain;

namespace TouhouArticleMaker.Tests
{
    [TestClass]
    public class IntroTests
    {
        [TestMethod]
        public void Should_ReturnTrue_When_Given_ValidIntro()
        {
            var intro = new Intro("It is a intro about Jhon Smith.");            
            Assert.IsTrue(intro.IsValid);     
        }

        [TestMethod]
        public void Should_ReturnFalse_When_Given_EmptyText()
        {
            var intro = new Intro("");                     
            Assert.IsFalse(intro.IsValid);
        }
    }
}
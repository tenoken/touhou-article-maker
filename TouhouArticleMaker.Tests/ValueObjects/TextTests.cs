using Microsoft.VisualStudio.TestTools.UnitTesting;
using TouhouArticleMaker.Domain;

namespace TouhouArticleMaker.Tests
{
    [TestClass]
    public class TextTests
    {
        [TestMethod]
        public void Should_ReturnTrue_When_Given_ValidText()
        {
            var text = new Text("It is a text about Jhon Smith.");            
            Assert.IsTrue(text.IsValid);     
        }

        [TestMethod]
        public void Should_ReturnFalse_When_Given_EmptyText()
        {
            var text = new Text("");                     
            Assert.IsFalse(text.IsValid);
        }
    }
}
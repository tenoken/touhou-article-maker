using Microsoft.VisualStudio.TestTools.UnitTesting;
using TouhouArticleMaker.Domain;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Tests
{
    [TestClass]
    public class SectionTests
    {
        [TestMethod]
        public void Should_ReturnTrue_When_Given_ValidSection()
        {
            //Arrange
            var title = new Title("The Embodiment of Scarlet Devil");
            var text = new Text("This is a text about touhou game series.");
            var validation = new EntityValidation();

            //Act
            var sut = new Section(title, text, validation);
            //Assert
            Assert.IsTrue(sut.IsValid);
        }

        [TestMethod]
        public void Should_ReturnTrue_When_Given_InvalidTitle()
        {
            //Arrange
            var title = new Title("");
            var text = new Text("This is a text about touhou game series.");
            var validation = new EntityValidation();

            //Act
            var sut = new Section(title, text, validation);
            //Assert
            Assert.IsFalse(sut.IsValid);
        }

        [TestMethod]
        public void Should_ReturnTrue_When_Given_InvalidText()
        {
            //Arrange
            var title = new Title("The Embodiment of Scarlet Devil");      
            var text = new Text("");
            var validation = new EntityValidation();

            //Act
            var sut = new Section(title, text, validation);
            //Assert
            Assert.IsFalse(sut.IsValid);
        }
    }
}
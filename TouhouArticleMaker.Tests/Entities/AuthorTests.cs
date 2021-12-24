using Microsoft.VisualStudio.TestTools.UnitTesting;
using TouhouArticleMaker.Domain;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Tests
{
    [TestClass]
    public class AuthorTests
    {
        [TestMethod]
        public void Should_ReturnTrue_When_Given_ValidAuthor()
        {
            //Arrange
            var name = new Name("Flandre", "Scartlet");
            var username = new Title("Youkai");
            var password = "F1@ndre$";
            var email = new Email("flandre.scarlet@gensoukyo.com");
            var validation =  new EntityValidation();

            //Act
            var sut = new Author(name, username, password, email, validation);
            //Assert
            Assert.IsTrue(sut.IsValid);
        }

        [TestMethod]
        public void Should_ReturnFalse_When_Given_InvalidEmail()
        {
            //Arrange
            var name = new Name("Flandre", "Scartlet");
            var username = new Title("Youkai");
            var password = "F1@ndre$";
            var email = new Email("");
            var validation =  new EntityValidation();

            //Act
            var sut = new Author(name, username, password, email, validation);
            //Assert
            Assert.IsFalse(sut.IsValid);
        }

        [TestMethod]
        public void Should_ReturnFalse_When_Given_InvalidName()
        {
            //Arrange
            var name = new Name("", "");
            var username = new Title("Youkai");
            var password = "F1@ndre$";
            var email = new Email("flandre.scarlet@gensoukyo.com");
            var validation =  new EntityValidation();

            //Act
            var sut = new Author(name, username, password, email, validation);
            //Assert
            Assert.IsFalse(sut.IsValid);
        }

        [TestMethod]
        public void Should_ReturnFalse_When_Given_InvalidUserName()
        {
            //Arrange
            var name = new Name("Flandre", "Scartlet");
            var username = new Title("");
            var password = "F1@ndre$";
            var email = new Email("flandre.scarlet@gensoukyo.com");
            var validation =  new EntityValidation();

            //Act
            var sut = new Author(name, username, password, email, validation);
            //Assert
            Assert.IsFalse(sut.IsValid);
        }

        [TestMethod]
        public void Should_ReturnFalse_When_Given_InvalidPassword()
        {
            //Arrange
            var name = new Name("Flandre", "Scartlet");
            var username = new Title("Youkai");
            var password = "flandres";
            var email = new Email("flandre.scarlet@gensoukyo.com");
            var validation =  new EntityValidation();

            //Act
            var sut = new Author(name, username, password, email, validation);
            //Assert
            Assert.IsFalse(sut.IsValid);
        }

        [TestMethod]
        [Ignore]
        public void Should_ReturnFalse_When_Given_PasswordTooLong()
        {
            //Arrange
            var name = new Name("Flandre", "Scartlet");
            var username = new Title("Youkai");
            var password = "F1@ndre$SSSSSSSSSSSSSSSSSSSSSSSSSSSSSS";
            var email = new Email("flandre.scarlet@gensoukyo.com");
            var validation =  new EntityValidation();

            //Act
            var sut = new Author(name, username, password, email, validation);
            //Assert
            Assert.IsFalse(sut.IsValid);
        }
    }
}
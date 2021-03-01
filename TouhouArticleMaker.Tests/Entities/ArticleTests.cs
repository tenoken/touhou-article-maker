using Microsoft.VisualStudio.TestTools.UnitTesting;
using TouhouArticleMaker.Domain;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Tests
{
    [TestClass]
    public class ArticleTests
    {
        private Author CreateAuthor()
        {
            var name = new Name("Flandre", "Scartlet");
            var username = new Title("Youkai");
            var password = "F1@ndre$";
            var email = new Email("flandre.scarlet@gensoukyo.com");
            var validation =  new EntityValidation();

            var author = new Author(name, username, password, email, validation);

            return author;
        }

        [TestMethod]
        public void Should_ReturnTrue_When_Given_ValidArticle()
        {
            //Arrange
            //var author = CreateAuthor();

            var title = new Title("The Embodiment of Scarlet Devil");
            var intro = new Intro("This is a intro.");
            //Act
            var aritcle = new Article(title, intro, ECategory.Games, new EntityValidation());

            //Assert
            Assert.IsTrue(aritcle.IsValid);
        }

        [TestMethod]
        public void Should_ReturnFalse_When_Given_ArticleWithoutTitle()
        {
            //Arrange
            //var author = CreateAuthor();

            var title = new Title("");
            var intro = new Intro("This is a intro.");

            //Act
            var aritcle = new Article(title, intro, ECategory.Games, new EntityValidation());

            //Assert
            Assert.IsFalse(aritcle.IsValid);
        }

                [TestMethod]
        public void Should_ReturnFalse_When_Given_ArticleWithoutIntro()
        {
            //Arrange
            //var author = CreateAuthor();

            var title = new Title("The Embodiment of Scarlet Devil");
            var intro = new Intro("");

            //Act
            var aritcle = new Article(title, intro, ECategory.Games, new EntityValidation());            

            //Assert
            Assert.IsFalse(aritcle.IsValid);
        }
    }
}
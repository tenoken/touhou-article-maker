using Microsoft.VisualStudio.TestTools.UnitTesting;
using TouhouArticleMaker.Domain;

namespace TouhouArticleMaker.Tests
{
    [TestClass]
    public class ArticleCommandTests
    {
        [TestMethod]
        public void Should_ReturnFalse_When_Given_InvalidCreateArticleCommand()
        {
            var command = new CreateArticleCommand();            
            command.Validate();    

            Assert.IsFalse(command.IsValid);     
        }
    }
}
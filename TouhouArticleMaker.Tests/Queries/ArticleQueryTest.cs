using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TouhouArticleMaker.Domain;
using Moq;

namespace TouhouArticleMaker.Tests
{
    [TestClass]
    public class ArticleQueryTests
    {
        private IList<Article> _article;

        public ArticleQueryTests()
        {
            _article = new List<Article>();
            for (int i = 0; i < 10; i++)
            {
                _article.Add(new Article(new Title($"Title{i}"), new Intro($"Intro{i}"), ECategory.Games, new Shared.EntityValidation()));
            }
        }
        
        [TestMethod]
        public void Should_ReturnFalse_When_Given_ArticleNotExists()
        {
            var exp = ArticleQuery.GetArticleByTitle("Title3");            
            var article = _article.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual("Title3", article.Title.Text);
        }
    }
}
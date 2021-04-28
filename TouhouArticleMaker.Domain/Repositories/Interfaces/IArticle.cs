using System;

namespace TouhouArticleMaker.Domain{

    public interface IArticleRepository
    {
        bool ArticleExists(string articleId);
        void CreateArticle(Author author);
    }
}
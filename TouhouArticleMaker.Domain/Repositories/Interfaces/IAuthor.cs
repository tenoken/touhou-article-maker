using System;

namespace TouhouArticleMaker.Domain{

    public interface IAuthorRepository
    {
        bool AuthorExists(string articleId);
        void CreateAuthor(Author article);
    }
}
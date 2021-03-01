using System;
using System.Collections.Generic;
using System.Linq;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class Author : User
    {
        private IList<Article> _articles;

        public Author(Name name, Title userName, string password, Email email, EntityValidation validation) 
                : base(name, userName, password, email, validation)
        {
            _articles = new List<Article>();
        }

        public void AddArticle(Article article){
            _articles.Add(article);
        }

        public IReadOnlyCollection<Article> Articles { get {return _articles.ToArray();} }
    }
}

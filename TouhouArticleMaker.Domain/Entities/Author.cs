using System;
using System.Collections.Generic;
using System.Linq;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class Author : User
    {
        private IList<Article> _articles;

        protected Author()
        {

        }

        public Author(Name name, Title userName, string password, Email email, EntityValidation validation, string id = null) 
                : base(name, userName, password, email, validation, id)
        {
            _articles = new List<Article>();
        }

        public void AddArticle(Article article){
            _articles.Add(article);
        }

        public IReadOnlyCollection<Article> Articles { get {return _articles?.ToArray();} }
    }
}

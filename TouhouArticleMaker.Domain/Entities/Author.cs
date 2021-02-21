using System;
using System.Collections.Generic;
using System.Linq;

namespace TouhouArticleMaker.Domain
{
    public class Author : User
    {
        private IList<Article> _articles;

        public Author(Name name, Title userName, string password, Email email) 
            : base(name, userName, password, email)
        {
            _articles = new List<Article>();
        }

        public IReadOnlyCollection<Article> Articles { get {return _articles.ToArray();} }
    }
}

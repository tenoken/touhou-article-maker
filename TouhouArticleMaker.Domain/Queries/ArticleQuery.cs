using System;
using System.Linq.Expressions;

namespace TouhouArticleMaker.Domain{

    public static class ArticleQuery 
    {        
        public static Expression<Func<Article, bool>> GetArticle(string guid)
        {
            return x => x.Id == guid;
        }

         public static Expression<Func<Article, bool>> GetArticleByTitle(string title)
        {
            return x => x.Title.Text == title;
        }
    }
}
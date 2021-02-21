using System;
using Flunt.Validations;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class Section : Contract<Entity> 
    {
        public Section(Title title, string text)
        {
            Title = title;
            Text = text;

            AddNotifications(this.Requires()
                .IsNotNullOrEmpty(text, "Article.Text", "Text should be not null or empty.")
            );
        }

        public Guid ArticleId { get; private set; }
        public Title Title { get; private set; }
        public string Text { get; private set; }
    }
}

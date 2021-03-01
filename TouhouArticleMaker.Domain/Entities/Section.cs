using System;
using Flunt.Validations;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class Section : Entity
    {
        public Section(Title title, Text text, EntityValidation validation) 
                : base(validation)
        {
            //ArticleId = article.Id;
            Title = title;
            Text = text;

            if(!title.IsValid)
                validation.AddNotifications(title.Notifications);

            if(!text.IsValid)
                validation.AddNotifications(text.Notifications);
        }

        public Guid ArticleId { get; private set; }
        public Title Title { get; private set; }
        public Text Text { get; private set; }
    }
}

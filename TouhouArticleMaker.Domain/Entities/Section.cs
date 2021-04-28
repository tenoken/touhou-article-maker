using System;
using Flunt.Validations;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class Section : Entity
    {
        protected Section()
        {

        }

        public Section(Title title, Text text, EntityValidation validation, string id = null) 
                : base(validation)
        {
            //ArticleId = article.Id;
            if (!string.IsNullOrEmpty(id))
                Id = id;

            Title = title;
            Text = text;

            if(!title.IsValid)
                validation.AddNotifications(title.Notifications);

            if(!text.IsValid)
                validation.AddNotifications(text.Notifications);
        }

        public string ArticleId { get; private set; }
        public Title Title { get; private set; }
        public Text Text { get; private set; }
    }
}

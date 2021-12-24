using System;
using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Validations;
using TouhouArticleMaker.Domain.Entities.Interfaces;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class Section : Entity, ISection
    {
        protected Section()
        {

        }

        public Section(Title title, Text text, EntityValidation validation, string id = null, string articleId = null) 
                : base(validation)
        {
            ArticleId = articleId;
            if (!string.IsNullOrEmpty(id))
                Id = id;

            Title = title;
            Text = text;
            Validation = validation;

            if (!title.IsValid)
                Validation.AddNotifications(title.Notifications);

            if(!text.IsValid)
                Validation.AddNotifications(text.Notifications);
        }
        
        public string ArticleId { get; private set; }
        public Title Title { get; private set; }
        public Text Text { get; private set; }
        [NotMapped]
        public EntityValidation Validation { get; private set; }

        public void SetArticleId(Article article)
        {
            ArticleId = article.Id;
        }
    }
}

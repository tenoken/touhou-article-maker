using System;
using Flunt.Validations;
using TouhouArticleMaker.Domain;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class CreateSectionCommand : Command
    {        
        public string ArticleId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public override void Validate()
        {
            AddNotifications(new Contract<EntityValidation>()
                .Requires()
                .IsNotNullOrEmpty(ArticleId, "CreateSectionCommand.ArticleId", "ArticleId should be not null.")
                .IsNotNullOrEmpty(Title, "CreateSectionCommand.Title", "Title should be not null.")
                .IsNotNullOrEmpty(Text, "CreateSectionCommand.Text", "Text should be not null.")
            );
        }
    }
}
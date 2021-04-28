using System;
using Flunt.Notifications;
using Flunt.Validations;
using TouhouArticleMaker.Domain;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class CreateArticleCommand : Command
    {
        public string FirstName { get; set; }        
        public string LastName { get; set; }   
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string AuthorId { get; set; }
        public string CardId { get; set; }
        public string GalleryId { get; set; }
        public string Title { get; set; }
        public string Intro { get; set; }
        public ECategory Category { get; set; }

        public override void Validate(){
            AddNotifications(new Contract<EntityValidation>()
                .Requires()
                .IsNotNullOrEmpty(AuthorId, "CreateArticleCommand.AuthorId", "AuthorId should be not null.")
                .IsNotNullOrEmpty(CardId, "CreateArticleCommand.CardId", "CardId should be not null.")
                .IsNotNullOrEmpty(GalleryId, "CreateArticleCommand.GalleryId", "GalleryId should be not null.")
                .IsNotNullOrEmpty(Title, "CreateArticleCommand.Title", "Title should be not null.")
                .IsNotNullOrEmpty(Intro, "CreateArticleCommand.Intro", "Intro should be not null.")
            );
        }
    }
}
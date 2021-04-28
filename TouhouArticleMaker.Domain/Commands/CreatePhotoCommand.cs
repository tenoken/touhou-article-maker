using System;
using Flunt.Validations;
using TouhouArticleMaker.Domain;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class CreatePhotoCommand : Command
    {        
        public string GalleryId { get; set; }
        public string Title { get; set; }

        public override void Validate()
        {
            AddNotifications(new Contract<EntityValidation>()
                .Requires()
                .IsNotNullOrEmpty(GalleryId, "CreatePhotoCommand.Name", "GalleryId should be not null.")
                .IsNotNullOrEmpty(Title, "CreatePhotoCommand.Title", "Title should be not null.")
            );
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Validations;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class Photo : Entity
    {
        protected Photo()
        {

        }

        public Photo(Title title, URL imageUri, string base64EncodedImage, EntityValidation validation) : base(validation)
        {
            Title = title;
            ImageURI = imageUri;
            Base64EncodedImage = base64EncodedImage;
            Validation = validation;

            if (!title.IsValid)
                Validation.AddNotifications(title.Notifications);

            if (!imageUri.IsValid)
                Validation.AddNotifications(imageUri.Notifications);
        }

        public string GalleryId { get; private set; }
        public Title Title { get; private set; }
        public URL ImageURI { get; private set; }
        public string Base64EncodedImage { get; private set; }
        [NotMapped]
        public EntityValidation Validation { get; private set; }

        public void SetGallery(Gallery gallery)
        {
            this.GalleryId = gallery.Id;
        }
    }
}
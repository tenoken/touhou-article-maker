using System;
using Flunt.Validations;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class Photo : Entity
    {
        public Photo(Title title, EntityValidation validation) : base(validation)
        {
            Title = title;
        }

        public Guid GalleryId { get; private set; }
        public Title Title { get; private set; }
    }
}
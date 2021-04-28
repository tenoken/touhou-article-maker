using System;
using Flunt.Validations;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class Photo : Entity
    {
        protected Photo()
        {

        }

        public Photo(Title title, EntityValidation validation) : base(validation)
        {
            Title = title;
        }

        public string GalleryId { get; private set; }
        public Title Title { get; private set; }
    }
}
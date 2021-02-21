using System;
using Flunt.Validations;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class Photo : Contract<Entity> 
    {
        public Photo(Title title)
        {
            Title = title;
        }

        public Guid GalleryId { get; private set; }
        public Title Title { get; private set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class Gallery : Entity
    {
        protected Gallery()
        {

        }

        private IList<Photo> _photos;
        public Gallery(EntityValidation validation) : base(validation)
        {
            _photos = new List<Photo>();
        }

        public void AddPhoto(Photo photo){
            _photos.Add(photo);
        }
        public IReadOnlyCollection<Photo> Photos { get {return _photos.ToArray();} }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class Gallery : Contract<Entity> 
    {
        private IList<Photo> _photos;
        public Gallery()
        {
            _photos = new List<Photo>();
        }
        public IReadOnlyCollection<Photo> Photos { get {return _photos.ToArray();} }
    }
}
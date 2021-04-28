using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;
using Flunt.Validations;
using TouhouArticleMaker.Shared;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace TouhouArticleMaker.Domain
{
    public class Article : Entity
    {
        private IList<Section> _sections;
        private EntityValidation _validation;

        protected Article() : base()
        {

        }

        public Article(Title title, Intro intro, ECategory category, EntityValidation validation, string id = null)
                : base(validation)
        {
            if (!string.IsNullOrEmpty(id))
                Id = id;

            Title = title;
            Intro = intro;
            Category = category;
            _sections = new List<Section>();
            CreateDate = DateTime.Now;
            _validation = validation;

            if (!title.IsValid)
                _validation.AddNotifications(title.Notifications);

            if (!intro.IsValid)
                _validation.AddNotifications(intro.Notifications);
        }

        public void AddCard(Card card) {
            CardId = card.Id;
        }

        public void AddGallery(Gallery gallery) {
            GalleryId = gallery.Id;
        }

        public void AddSection(Section section) {
            _sections.Add(section);
        }

        public string AuthorId { get; private set; }
        public string CardId { get; private set; }
        public string GalleryId { get; private set; }
        public Title Title { get; private set; }
        public Intro Intro { get; private set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ECategory Category { get; private set; }
        public IReadOnlyCollection<Section> Sections { get{ return _sections.ToArray();} }
        public DateTime CreateDate { get; private set; }        
    }
}
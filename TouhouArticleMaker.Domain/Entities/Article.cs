using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;
using Flunt.Validations;
using TouhouArticleMaker.Shared;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using TouhouArticleMaker.Domain.Entities.Interfaces;

namespace TouhouArticleMaker.Domain
{
    public class Article : Entity
    {
        private IList<Section> _sections;
        private EntityValidation _validation;

        protected Article() : base()
        {

        }
        //TODO: implement dependency injection
        public Article(Title title, Intro intro, ECategory category, EntityValidation validation, string id = null, List<Section> sections = null, string authorId = null)
                : base(validation)
        {
            if (!string.IsNullOrEmpty(id))
                Id = id;

            if (!string.IsNullOrEmpty(authorId))
                AuthorId = authorId;

            Title = title;
            Intro = intro;
            Category = category;
            _sections = sections;
            CreateDate = DateTime.Now;
            Validation = validation ?? new EntityValidation();

            if (!title.IsValid)
                Validation.AddNotifications(title.Notifications);

            if (!intro.IsValid)
                Validation.AddNotifications(intro.Notifications);

            if (_sections == null)
                _sections = new List<Section>();
        }

        public void AddCard(Card card) 
        {
            CardId = card.Id;
        }

        public void AddGallery(Gallery gallery) 
        {
            GalleryId = gallery.Id;
        }

        public void AddSection(ISection section) 
        {
            section.SetArticleId(this);
            //_sections.Add(section);
        }

        public void SetAuthor(Author author)
        {
            AuthorId = author.Id;
        }

        public string AuthorId { get; private set; }
        public string CardId { get; private set; }
        public string GalleryId { get; private set; }
        public Title Title { get; private set; }
        public Intro Intro { get; private set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ECategory Category { get; private set; }
        public IReadOnlyCollection<Section> Sections { get{ return _sections?.ToArray();} }
        public DateTime CreateDate { get; private set; }
        [NotMapped]
        public EntityValidation Validation { get; private set; }
    }
}
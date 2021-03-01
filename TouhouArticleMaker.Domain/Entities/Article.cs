using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;
using Flunt.Validations;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class Article : Entity
    {
        private IList<Section> _sections;
        private EntityValidation _validation;

        public Article(Title title, Intro intro, ECategory category, EntityValidation validation) 
                : base(validation)
        {
            //AuthorId = author.Id;
            Title = title;
            Intro = intro;
            Category = category;
            _sections = new List<Section>();
            CreateDate = DateTime.Now;
            _validation = validation;

            // if(!author.IsValid)
            //     _validation.AddNotifications(author.Notifications);

            if(!title.IsValid)
                _validation.AddNotifications(title.Notifications);

            if(!intro.IsValid)
                _validation.AddNotifications(intro.Notifications); 
        }

        public void AddCard(Card card){
            CardId = card.Id;
        }

        public void AddGallery(Gallery gallery){
            GalleryId = gallery.Id;
        }

        public void AddSection(Section section){
            _sections.Add(section);
        }

        public Guid AuthorId { get; private set; }
        public Guid CardId { get; private set; }
        public Guid GalleryId { get; private set; }
        public Title Title { get; private set; }
        public Intro Intro { get; private set; }
        public ECategory Category { get; private set; }
        public IReadOnlyCollection<Section> Sections { get{ return _sections.ToArray();} }
        public DateTime CreateDate { get; private set; }        
    }
}
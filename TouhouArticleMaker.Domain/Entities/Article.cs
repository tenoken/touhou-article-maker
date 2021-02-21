using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class Article : Contract<Entity> 
    {
        private IList<Section> _sections;

        public Article(Title title, string intro, string category)
        {
            Title = title;
            Intro = intro;
            Category = category;
            _sections = new List<Section>();
            CreateDate = DateTime.Now;

            AddNotifications(this.Requires()
                .IsNotNullOrEmpty(intro, "Article.Intro", "Intro should be not null or empty..")
                .IsNotNullOrEmpty(category, "Article.Category", "Category should be not null or empty.")
            );
        }

        public Guid AuthorId { get; private set; }
        public Guid CardId { get; private set; }
        public Guid GalleryId { get; private set; }
        public Title Title { get; private set; }
        public string Intro { get; private set; }
        public string Category { get; private set; }
        public IReadOnlyCollection<Section> Sections { get{ return _sections.ToArray();} }
        public DateTime CreateDate { get; private set; }        
    }
}
using System;
using System.Collections.Generic;
using Flunt.Validations;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class Card : Contract<Entity> 
    {
        public Card(Title title, Title developer, Title publisher, DateTime released, Title genre, IList<Title> platforms, IList<Title> requirements)
        {
            Title = title;
            Developer = developer;
            Publisher = publisher;
            Released = released;
            Genre = genre;
            Platforms = platforms;
            Requirements = requirements;

            AddNotifications(
                this.IsMinValue(released, "Card.Released", "Released should be valid date, not a minvalue.")
                .IsMaxValue(released, "Card.Released", "Released should be a valid date, not a maxvalue.")
            );
        }

        public Guid PhotoId { get; private set; }
        public Title Title { get; private set; }
        public Title Developer { get; private set; }
        public Title Publisher { get; private set; }
        public DateTime Released { get; private set; }
        public Title Genre { get; private set; }
        public IList<Title> Platforms { get; private set; }
        public IList<Title> Requirements { get; private set; }
    }
}
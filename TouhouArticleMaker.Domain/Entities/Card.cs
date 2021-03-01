using System;
using System.Collections.Generic;
using Flunt.Notifications;
using Flunt.Validations;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class Card : Entity
    {
        public Card(Title title, 
                    Title developer, 
                    Title publisher, 
                    DateTime released, 
                    Title genre, 
                    IList<Title> platforms, 
                    IList<Title> requirements, 
                    EntityValidation validation) 
                : base(validation)
        {
            Title = title;
            Developer = developer;
            Publisher = publisher;
            Released = released;
            Genre = genre;
            Platforms = platforms;
            Requirements = requirements;

            if(!title.IsValid)
                validation.AddNotifications(title.Notifications);

            if(!developer.IsValid)
                validation.AddNotifications(developer.Notifications);

            if(!publisher.IsValid)
                validation.AddNotifications(publisher.Notifications);

            if(!genre.IsValid)
                validation.AddNotifications(genre.Notifications);

            foreach (var requirement in requirements)
            {
                if(!requirement.IsValid)
                    validation.AddNotifications(requirement.Notifications);
            }

            foreach (var platform in platforms)
            {
                if(!platform.IsValid)
                    validation.AddNotifications(platform.Notifications);
            }

            validation.AddNotifications(new Contract<EntityValidation>().Requires()
                .IsNotMinValue(released, "Card.Released", "Released should be valid date, not a minvalue.")
                .IsNotMaxValue(released, "Card.Released", "Released should be a valid date, not a maxvalue.")
            );
        }

        public void AddPhoto(Photo photo){
            PhotoId = photo.Id;
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
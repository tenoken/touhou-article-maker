using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Notifications;
using Flunt.Validations;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class Card : Entity
    {
        protected Card()
        {

        }

        public Card(Title title, 
                    Title developer, 
                    Title publisher, 
                    DateTime released, 
                    Title genre, 
                    Title gameplay,
                    Title platforms, 
                    Title requirements, 
                    EntityValidation validation,
                    Photo photo = null) 
                : base(validation)
        {
            Title = title;
            Developer = developer;
            Publisher = publisher;
            Released = released;
            Genre = genre;
            Gameplay = gameplay;
            Platforms = platforms;
            Requirements = requirements;
            Validation = validation;
            Photo = photo;

            if(!title.IsValid)
                Validation.AddNotifications(title.Notifications);

            if(!developer.IsValid)
                Validation.AddNotifications(developer.Notifications);

            if(!publisher.IsValid)
                Validation.AddNotifications(publisher.Notifications);

            if(!genre.IsValid)
                Validation.AddNotifications(genre.Notifications);

            if (!gameplay.IsValid)
                Validation.AddNotifications(genre.Notifications);

            if (!requirements.IsValid)
                Validation.AddNotifications(publisher.Notifications);

            if (!platforms.IsValid)
                Validation.AddNotifications(genre.Notifications);

            //foreach (var requirement in requirements)
            //{
            //    if(!requirement.IsValid)
            //        validation.AddNotifications(requirement.Notifications);
            //}

            //foreach (var platform in platforms)
            //{
            //    if(!platform.IsValid)
            //        validation.AddNotifications(platform.Notifications);
            //}

            validation.AddNotifications(new Contract<EntityValidation>().Requires()
                .IsNotMinValue(released, "Card.Released", "Released should be valid date, not a minvalue.")
                .IsNotMaxValue(released, "Card.Released", "Released should be a valid date, not a maxvalue.")
            );
        }

        public void SetPhotoId(Photo photo){
            PhotoId = photo.Id;
        }

        public string PhotoId { get; private set; }
        public Title Title { get; private set; }
        public Title Developer { get; private set; }
        public Title Publisher { get; private set; }
        public DateTime Released { get; private set; }
        public Title Genre { get; private set; }
        //TODO: create a requirements and platforms class
        //public IList<Title> Platforms { get; private set; }
        //public IList<Title> Requirements { get; private set; }
        public Title Gameplay { get; private set; }
        public Title Platforms { get; private set; }
        public Title Requirements { get; private set; }
        [NotMapped]
        public EntityValidation Validation { get; private set; }
        [NotMapped]
        public Photo Photo { get; private set; }
    }
}
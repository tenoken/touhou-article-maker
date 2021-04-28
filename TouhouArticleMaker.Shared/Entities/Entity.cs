using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Notifications;

namespace TouhouArticleMaker.Shared
{
    public abstract class Entity
    {        
        private EntityValidation _validation;
        public Entity(EntityValidation validation = null)
        {
            Id = Guid.NewGuid().ToString().Replace("-","");
            _validation = validation;
        }
        public string Id { get; protected set; }
        public bool IsValid { get{ return _validation.IsValid;} }
        [NotMapped]
        public IReadOnlyCollection<Notification> Notifications { get{ return _validation.Notifications;} }
    }
}
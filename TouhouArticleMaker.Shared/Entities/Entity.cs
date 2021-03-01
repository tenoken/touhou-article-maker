using System;
using System.Collections.Generic;
using Flunt.Notifications;

namespace TouhouArticleMaker.Shared
{
    public abstract class Entity
    {        
        private EntityValidation _validation;
        public Entity(EntityValidation validation)
        {
            Id = Guid.NewGuid();
            _validation = validation;
        }
        public Guid Id { get; private set; }
        public bool IsValid { get{ return _validation.IsValid;} }
        public IReadOnlyCollection<Notification> Notifications { get{ return _validation.Notifications;} }
    }
}
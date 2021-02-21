using System;
using System.Collections.Generic;
using Flunt.Notifications;

namespace TouhouArticleMaker.Shared
{
    public abstract class Entity //: INotifiable
    {        
        public Guid Id { get; private set; }
        public Entity()
        {
            Id = new Guid();
        }

        // public void AddNotifications(IEnumerable<Notification> notifications)
        // {
        //     throw new NotImplementedException();
        // }
    }
}
using System;
using System.Collections.Generic;
using Flunt.Notifications;

namespace TouhouArticleMaker.Shared
{
    public abstract class Command : Notifiable<Notification>, ICommand
    {        
        public abstract void Validate();
    }
}
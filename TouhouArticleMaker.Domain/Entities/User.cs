using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using Flunt.Notifications;
using Flunt.Validations;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class User : Entity
    {
        protected User()
        {

        }

        public User(Name name, Title userName, string password, Email email, EntityValidation validation, string id = null) 
                : base(validation)
        {
            if (!string.IsNullOrEmpty(id))
                Id = id;

            Name = name;
            UserName = userName;
            Password = password;
            Email = email;
            CreateDate = DateTime.Now;
            Active = true;
            Validation = validation;

            if(!name.IsValid)
                Validation.AddNotifications(name.Notifications);

            if(!userName.IsValid)
                Validation.AddNotifications(userName.Notifications);

            if(!email.IsValid)
                Validation.AddNotifications(email.Notifications);

            if(IsPasswordValid(password)){

                //Do shomething;
            }
        }

        private bool IsPasswordValid(string password)
        {
            //_validation.AddNotifications(new Contract<EntityValidation>().Requires()
            //    .IsGreaterThan(password, 7, "Title.Text", "Password length should be greater or equals than 7.")
            //    .IsLowerThan(password, 25, "User.Password", "Password length is greater than 25.")
            //);

            if(!IsPasswordHasANumber(password))
                 return false;

            if(!IsPasswordHasAUpperCaseChar(password))
                return false;
           
            return true;
        }

        private bool IsPasswordHasANumber(string password)
        {            
            var hasNumber = new Regex(@"[0-9]+");

            if(hasNumber.IsMatch(password))
                return true;

            Validation.AddNotification("User.Password", "Password should have at least one number.");
            return false;
        }

        private bool IsPasswordHasAUpperCaseChar(string password)
        {
            var hasUpperChar = new Regex(@"[A-Z]+");

            if(hasUpperChar.IsMatch(password))
                return true;

            Validation.AddNotification("User.Password", "Password should have at least one upper case char.");
            return false;
        }

        public Name Name { get; private set; }        
        public Title UserName { get; private set; }
        public string Password { get; private set; }
        public Email Email { get; private set; }
        public DateTime CreateDate { get; private set; }
        public bool Active { get; private set; }

        [NotMapped]
        public EntityValidation Validation { get; private set; }
    }
}

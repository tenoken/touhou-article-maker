using System;
using System.Text.RegularExpressions;
using Flunt.Validations;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public abstract class User : Contract<Entity> 
    {
        protected User(Name name, Title userName, string password, Email email)
        {
            Name = name;
            UserName = userName;
            Password = password;
            Email = email;
            CreateDate = DateTime.Now;
            Active = true;

            if(IsPasswordValid(password)){

                //Do shomething;
            }
        }

        private bool IsPasswordValid(string password)
        {
            AddNotifications(this.Requires()
                .IsLowerThan(password, 8, "User.Password", "Password length is lower than 8.")
                .IsGreaterThan(password, 25, "User.Password", "Password length is greater than 25.")
            );

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

            AddNotification("User.Password", "Password should have at least one number.");
            return false;
        }

        private bool IsPasswordHasAUpperCaseChar(string password)
        {
            var hasUpperChar = new Regex(@"[A-Z]+");

            if(hasUpperChar.IsMatch(password))
                return true;                

            AddNotification("User.Password", "Password should have at least one upper case char.");
            return false;
        }

        public Name Name { get; private set; }        
        public Title UserName { get; private set; }
        public string Password { get; private set; }
        public Email Email { get; private set; }
        public DateTime CreateDate { get; private set; }
        public bool Active { get; private set; }
    }
}

using System;
using Flunt.Validations;
using TouhouArticleMaker.Domain;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class CreateAuthorCommand : Command
    {
        
        public string FirstName { get; set; }        
        public string LastName { get; set; }   
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }

        public override void Validate()
        {
            AddNotifications(new Contract<EntityValidation>()
                .Requires()
                .IsNotNullOrEmpty(FirstName, "CreateAuthorCommand.FirstName", "Name should be not null.")
                .IsNotNullOrEmpty(LastName, "CreateAuthorCommand.LastName", "Name should be not null.")
                .IsNotNullOrEmpty(UserName, "CreateAuthorCommand.UserName", "UserName should be not null.")
                .IsNotNullOrEmpty(Password, "CreateAuthorCommand.Password", "Password should be not null.")
                .IsNotNullOrEmpty(Email, "CreateAuthorCommand.Email", "Email should be not null.")
            );
        }
    }
}
using Flunt.Validations;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class Email : Contract<ValueObject>
    {
        protected Email()
        {

        }

        public Email(string address)
        {
            Address = address;

            AddNotifications(this.Requires()
                .IsEmail(address, "Email.Address", "E-mail not valid.")
                .IsEmailOrEmpty(address, "Email.Address", "E-mail empty."));
        }
        public string Address { get; private set; }
    }
}
using System.Linq;
using Flunt.Validations;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class Name : Contract<ValueObject>
    {
        public Name(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;

            AddNotifications(base.Requires()
                .IsGreaterOrEqualsThan(firstname, 3, "Name.FirstName", "Firstname length should be greater or equals than 3.")
                .IsGreaterOrEqualsThan(lastname, 3, "Name.LastName", "LastName length should be greater or equals than 3.")
                .IsLowerOrEqualsThan(firstname, 40, "Name.FirstName", "Firstname length should be lower or equals than 40.")
                .IsLowerOrEqualsThan(lastname, 40, "Name.LastName", "LastName length should be lower or equals than 40.")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
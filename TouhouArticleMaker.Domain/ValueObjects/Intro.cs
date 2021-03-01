using System.Linq;
using Flunt.Validations;
using TouhouArticleMaker.Shared;

namespace  TouhouArticleMaker.Domain
{
    public class Intro : Contract<ValueObject>
    {
        public Intro(string text)
        {
            Text = text;

            AddNotifications(this.Requires()
                .IsLowerOrEqualsThan(text, 10000, "Intro.Text", "Intro length should be lower or equals than 10000.")
                .IsGreaterThan(text, 0, "Intro.Text", "Intro length should be greater than 0.")
            );
        }

        public string Text { get; private set; }
    }
}
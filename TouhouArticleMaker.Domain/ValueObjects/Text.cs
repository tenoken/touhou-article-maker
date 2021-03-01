using Flunt.Validations;
using TouhouArticleMaker.Shared;

namespace  TouhouArticleMaker.Domain
{
    public class Text : Contract<ValueObject>
    {
        public Text(string text)
        {
            TextCotnent = text;

            AddNotifications(this.Requires()
                .IsLowerOrEqualsThan(text, 1000000, "Text.TextCotnent", "Text length should be lower or equals than 1.000.000.")
                .IsGreaterThan(text, 0, "Text.TextCotnent", "Text length should be greater than 0.")
            );
        }

        public string TextCotnent { get; private set; }
    }
}
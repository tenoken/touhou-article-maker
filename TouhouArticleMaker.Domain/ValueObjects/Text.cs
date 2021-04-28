using Flunt.Validations;
using TouhouArticleMaker.Shared;

namespace  TouhouArticleMaker.Domain
{
    public class Text : Contract<ValueObject>
    {
        protected Text()
        {

        }

        public Text(string textContent)
        {
            TextContent = textContent;

            AddNotifications(this.Requires()
                .IsLowerOrEqualsThan(textContent, 1000000, "Text.TextCotnent", "Text length should be lower or equals than 1.000.000.")
                .IsGreaterThan(textContent, 0, "Text.TextCotnent", "Text length should be greater than 0.")
            );
        }

        public string TextContent { get; private set; }
    }
}
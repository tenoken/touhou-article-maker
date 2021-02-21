using System;
using Flunt.Validations;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class Title : Contract<ValueObject>
    {
        public Title(string text)
        {
            Text = text;

            AddNotifications(this.Requires()
                .IsGreaterOrEqualsThan(text, 2, "Title.Text", "Firstname length should be greater or equals than 3.")
                .IsGreaterOrEqualsThan(text, 2, "Title.Text", "LastName length should be greater or equals than 3.")
                .IsLowerOrEqualsThan(text, 50, "Title.Text", "Firstname length should be lower or equals than 20.")
                .IsLowerOrEqualsThan(text, 50, "Title.Text", "LastName length should be lower or equals than 20.")
            );
        }
        public string Text { get; private set; }
    }
}
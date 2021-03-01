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
                .IsGreaterThan(text, 2, "Title.Text", "Title length should be greater or equals than 2.")
                .IsLowerOrEqualsThan(text, 50, "Title.Text", "Title length should be lower or equals than 50.")
            );
        }
        public string Text { get; private set; }
    }
}
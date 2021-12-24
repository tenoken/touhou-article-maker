using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Domain
{
    public class URL : Contract<ValueObject>
    {
        protected URL()
        {

        }

        public URL(string path)
        {
            Path = path;

            AddNotifications(this.Requires()
                .IsGreaterThan(path, 5, "URI.Path", "Path length should be greater or equals than 2.")
                .IsLowerOrEqualsThan(path, 255, "URI.Path", "Path length should be lower or equals than 50.")
            );
        }

        public string Path { get; private set; }
    }
}

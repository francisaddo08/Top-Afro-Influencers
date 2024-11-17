using SharedKenel.Errors;
using SharedKenel.GUARD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKenel.ValuesObjects
{
    public sealed record FirstName
    {
        public const int FirstNameFieldNumber = 1;
        public const int MaxLength = 50;
        private FirstName(string value) { Value = value; }
        public string Value { get; private set; }
        public static FirstName Create(string firstName)
        {
            Ensure.NotNullOrWhiteSpace(firstName, nameof(firstName) );
            Ensure.NotGreaterThan(firstName.Length, MaxLength, DomainErrors.FirstName.TooLong);

          return new FirstName(firstName);
        }
    }
}

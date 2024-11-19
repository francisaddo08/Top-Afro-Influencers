using SharedKenel.Errors;
using SharedKenel.GUARD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKenel.Primitives
{
    public class AdminUserPrimitives
    {

    }

    public sealed record FirstName
    {
        public const int FirstNameFieldNumber = 1;
        public const int MaxLength = 50;
        private FirstName(string value) { Value = value; }
        public string Value { get; private set; }
        public static FirstName Create(string firstName)
        {
            Ensure.NotNullOrWhiteSpace(firstName, nameof(firstName));
            Ensure.NotGreaterThan(firstName.Length, MaxLength, DomainErrors.FirstName.TooLong);

            return new FirstName(firstName);
        }
    }
    public sealed record LastName
    {
        public const int LastNameFieldNumber = 2;
        public const int MaxLength = 50;
        private LastName(string value) { Value = value; }
        public string Value { get; private set; }
        public static LastName Create(string lastName)
        {
            Ensure.NotNullOrWhiteSpace(lastName, nameof(lastName));
            Ensure.NotGreaterThan(lastName.Length, MaxLength, DomainErrors.LastName.TooLong);

            return new LastName(lastName);
        }
    }
    public sealed record Password
    {
        public const int PasswordFieldNumber = 3;
        public const int MaxLength = 256;
        private Password(string value) { Value = value; }
        public string Value { get; private set; }
        public static Password Create(string password)
        {
            Ensure.NotNullOrWhiteSpace(password, nameof(password));
            Ensure.NotGreaterThan(password.Length, MaxLength, DomainErrors.Password.TooLong);

            return new Password(password);
        }
    }
    public sealed record PasswordConfirm
    {
        public const int PasswordFieldNumber = 3;
        public const int MaxLength = 256;
        private PasswordConfirm(string value) { Value = value; }
        public string Value { get; private set; }
        public static PasswordConfirm Create(string confirmPassword)
        {
            Ensure.NotNullOrWhiteSpace(confirmPassword, nameof(confirmPassword));
            Ensure.NotGreaterThan(confirmPassword.Length, MaxLength, DomainErrors.Password.TooLong);

            return new PasswordConfirm(confirmPassword);
        }
    }







    public sealed record Email
    {
        public const int EmailFieldNumber = 4;
        public const int MaxLength = 256;
        private Email(string value) { Value = value; }
        public string Value { get; private set; }
        public static Email Create(string email)
        {
            Ensure.NotNullOrWhiteSpace(email, nameof(email));
            Ensure.NotGreaterThan(email.Length, MaxLength, DomainErrors.Email.TooLong);

            return new Email(email);
        }
    }
}

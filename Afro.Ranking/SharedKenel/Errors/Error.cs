namespace SharedKenel.Errors
{
    public sealed record Error(string Code, string Message)
    {
        public static readonly Error None = new Error(string.Empty, string.Empty);
        public static readonly Error NullValue = new Error("Error.NullValue", "Can not Provide Null Value");
        public static readonly Error FirstName = new Error(string.Empty, "");

        public static implicit operator Result(Error error) => Result.Failure(error);
    }
}
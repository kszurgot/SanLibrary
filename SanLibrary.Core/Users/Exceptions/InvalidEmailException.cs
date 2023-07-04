using SanLibrary.Core.Shared.Exceptions;

namespace SanLibrary.Core.Users.Exceptions;

public sealed class InvalidEmailException : CustomException
{
    public string Email { get; }

    public InvalidEmailException(string email) : base($"Email: '{email}' is invalid.")
    {
        Email = email;
    }
}
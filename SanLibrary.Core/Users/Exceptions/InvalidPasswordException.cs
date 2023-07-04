using SanLibrary.Core.Shared.Exceptions;

namespace SanLibrary.Core.Users.Exceptions;

public sealed class InvalidPasswordException : CustomException
{
    public InvalidPasswordException() : base("Invalid password.")
    {
    }
}
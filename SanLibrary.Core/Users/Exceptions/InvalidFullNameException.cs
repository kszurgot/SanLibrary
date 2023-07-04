using SanLibrary.Core.Shared.Exceptions;

namespace SanLibrary.Core.Users.Exceptions;

public sealed class InvalidFullNameException : CustomException
{
    public string? FullName { get; }

    public InvalidFullNameException(string? fullName) : base($"Full name: '{fullName}' is invalid.")
    {
        FullName = fullName;
    }
}
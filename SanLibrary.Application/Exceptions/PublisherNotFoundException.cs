using SanLibrary.Core.Shared.Exceptions;

namespace SanLibrary.Application.Exceptions;

internal sealed class PublisherNotFoundException : CustomException
{
    public Guid PublsherId { get; }

    public PublisherNotFoundException(Guid publisherId) : base($"Publisher with ID: '{publisherId}' was not found.")
    {
        PublsherId = publisherId;
    }
}
using SanLibrary.Core.Shared.Exceptions;

namespace SanLibrary.Application.Exceptions;

internal sealed class BookNotFoundException : NotFoundException
{
    public Guid BookId { get; }

    public BookNotFoundException(Guid bookId) : base($"Book with ID: '{bookId}' was not found.")
    {
        BookId = bookId;
    }
}
﻿using SanLibrary.Core.Shared.Exceptions;

namespace SanLibrary.Application.Exceptions;

internal sealed class AuthorNotFoundException : CustomException
{
    public Guid AuthorId { get; }

    public AuthorNotFoundException(Guid authorId) : base($"Author with ID: '{authorId}' was not found.")
    {
        AuthorId = authorId;
    }
}
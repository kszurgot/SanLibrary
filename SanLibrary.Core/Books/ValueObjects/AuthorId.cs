﻿using SanLibrary.Core.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Books.ValueObjects
{
    public record AuthorId
    {
        public Guid Value { get; }

        public AuthorId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidEntityIdException(value);
            }

            Value = value;
        }

        public static AuthorId Create() => new(Guid.NewGuid());

        public static implicit operator Guid(AuthorId date)
            => date.Value;

        public static implicit operator AuthorId(Guid value)
            => new(value);

        public override string ToString() => Value.ToString("N");
    }
}
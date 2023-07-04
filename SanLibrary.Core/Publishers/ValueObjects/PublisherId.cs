﻿using SanLibrary.Core.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Publishers.ValueObjects
{
    public record PublisherId
    {
        public Guid Value { get; }

        public PublisherId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidEntityIdException(value);
            }

            Value = value;
        }

        public static PublisherId Create() => new(Guid.NewGuid());

        public static implicit operator Guid(PublisherId date)
            => date.Value;

        public static implicit operator PublisherId(Guid value)
            => new(value);

        public override string ToString() => Value.ToString("N");
    }
}

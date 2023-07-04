using SanLibrary.Core.Books.ValueObjects;
using SanLibrary.Core.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Books.Exceptions
{
    public sealed class InvalidMonthException : CustomException
    {
        public int Month { get; }

        public InvalidMonthException(int month) 
            : base($"Month: '{month}' is invalid.")
        {
            Month = month;
        }
    }
}

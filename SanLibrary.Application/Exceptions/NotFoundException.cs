using SanLibrary.Core.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Application.Exceptions
{
    public abstract class NotFoundException : CustomException
    {
        protected NotFoundException(string message) : base(message)
        {
        }
    }
}

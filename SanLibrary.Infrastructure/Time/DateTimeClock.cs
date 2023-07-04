using SanLibrary.Core.Shared.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Infrastructure.Time
{
    internal class DateTimeClock : IClock
    {
        public DateTime Current() => DateTime.UtcNow;
    }
}

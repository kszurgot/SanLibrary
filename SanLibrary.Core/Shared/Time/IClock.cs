﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core.Shared.Time
{
    public interface IClock
    {
        DateTime Current();
    }
}

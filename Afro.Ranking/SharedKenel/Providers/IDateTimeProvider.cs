﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKenel.Providers
{
    public interface IDateTimeProvider
    {
    public DateTime UtcNow { get; }
    }
}
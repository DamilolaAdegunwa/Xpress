﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Xpress.Core.BackgroundJobs
{
    public interface IBackgroundJobNameProvider
    {
        string Name { get; }
    }
}

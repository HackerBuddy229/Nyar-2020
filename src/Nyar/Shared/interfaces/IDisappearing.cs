﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyar.Shared.interfaces
{
    public interface IDisappearing
    {
        public DateTime CreatedAt { get; }
        public DateTime DisappearingAt { get; set; }
    }
}

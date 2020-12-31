﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Extensions.Canvas.Canvas2D;

namespace Nyar.Shared.interfaces
{
    public interface IRendered
    {
        public void Update(Canvas2DContext context);
    }
}

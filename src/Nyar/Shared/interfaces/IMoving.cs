﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyar.Shared.interfaces
{
    public interface IMoving
    {
        public double VelocityX { get; }
        public double VelocityY { get; }

        public void AccelerateX(float amount);
        public void AccelerateY(float amount);
    }
}

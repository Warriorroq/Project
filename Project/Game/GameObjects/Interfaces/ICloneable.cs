﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Game.Interfaces
{
    public interface ICloneable<T>
    {
        public T Clone();
    }
}

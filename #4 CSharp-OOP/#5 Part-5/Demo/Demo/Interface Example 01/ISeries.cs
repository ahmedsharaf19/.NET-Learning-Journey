﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Interface_Example_01
{
    internal interface ISeries
    {
        public int Current { get; set; }

        public void GetNext();

        public void Reset()
        {
            Current = 0;
        }
    }
}

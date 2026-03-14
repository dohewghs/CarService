using System;
using System.Collections.Generic;
using System.Text;

namespace CarService
{
    internal struct Interval
    {
        public double Lower { get; set; }
        public double Upper { get; set; }

        public Interval(int low = 0, int upp = 0)
        {
            this.Lower = low;
            this.Upper = upp;
        }
        public bool IsInInterval(int value)
        {
            return this.Lower <= value && this.Upper >= value;
        }

        public bool IsInInterval(double value)
        {
            return this.Lower <= value && this.Upper >= value;
        }
    }
}

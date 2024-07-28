using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxAndRabit
{
    internal interface CanEat
    {
        public void Eat();
        public int EatCount { get; set; }
    }
}

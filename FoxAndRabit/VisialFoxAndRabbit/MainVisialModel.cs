using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxAndRabit;

namespace VisialFoxAndRabbit
{
    internal class MainVisialModel
    {
        public MainVisialModel()
        {
            ReadFile read = new ReadFile();
            Field field = new Field(read);
        }
    }
}

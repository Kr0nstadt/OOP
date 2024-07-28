using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxAndRabit
{
    internal class Field
    {
        private List<Cell> field;
        private int n;
        private int m;

        public Field(int n,int m)
        {
            this.n = n;
            this.m = m;
        }
        public int Coordinate(int x, int y)
        {
            return y*n + x;// вот вообще не уверена 3 часа ночи
        }
        public int Coordination(Animals A)
        {
            return A.Y * n + A.X;
        }
        // сюда цикл на изменение состояния, потом метод менять места клеткам
        // и метод перегруженный для смены места
    }
}

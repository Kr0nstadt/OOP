using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxAndRabit
{
    internal class Fox : Animals,IComparable<Fox>, CanEat
    {
        private int CountEat = 0;
        private int val = 0;

        public Fox(int stability, int x, int y, int direction) :
            base(stability, x, y, direction)
        { year += val;val++; }


        public override void Aging()
        {
            year++;
            if (year == 15)
            {
                life = false;
            }
        }

        public override void Movement()
        {
            int NewX = 0, NewY = 0;
            switch (direction)
            {
                case 0:
                    NewX = x; NewY = y + 2; break;
                case 1:
                    NewX = x + 2; NewY = y; break;
                case 2:
                    NewX = x; NewY = y - 2; break;
                case 3:
                    NewX = x - 2; NewY = y; break;
                default:
                    break;
            }
            x = NewX; y = NewY;
            //нужно еще метод в моделе, что б оно их на другую сторону перекидывало если выход за границы
        }

        public override Animals Reproduction()
        {
            return new Fox(stability, x, y, direction);
        }

        public void Eat()
        {
            CountEat++;
        }

        public int CompareTo(Fox? other)
        {
            if(this.year > other.year) { return 1; }
            if(this.year < other.year) { return -1; }
            else {  return 0; }
        }

        public int EatCount
        {
            get { return CountEat; }
            set { CountEat = value; }
        }
    }
}

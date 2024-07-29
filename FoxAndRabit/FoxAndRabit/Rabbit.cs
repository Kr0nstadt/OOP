using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxAndRabit
{
    public class Rabbit : Animals
    {
        public Rabbit(int stability, int x, int y, int direction) : 
            base(stability, x, y, direction) { }

        public override void Aging()
        {
            year++;
            if(year == 10)
            {
                life = false;
            }
        }
        public override void Movement()
        {
            int NewX = 0,NewY = 0;
            switch(direction)
            {
                case 0:
                    NewX = x; NewY = y + 1; break;
                case 1:
                    NewX = x + 1; NewY = y; break;
                case 2:
                    NewX = x; NewY = y - 1; break;
                case 3:
                    NewX = x - 1; NewY = y; break;
                default:
                    break;
            }
            x = NewX; y = NewY;
            //нужно еще метод в моделе, что б оно их на другую сторону перекидывало если выход за границы
        }
        public override Animals Reproduction()
        {
            return new Rabbit(stability, x, y, direction);
        }

        public int Year//что б рожали вовремя
        {
            get { return year; }
        }
    }
}

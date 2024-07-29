using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxAndRabit
{
    public class Field
    {
        private List<Cell> field;
        private int n;
        private int m;

        public Field(int n,int m, List<Animals> animals)
        {
            for(int i = 0;i < animals.Count; i++)
            {
                SetAnimals(animals[i]);
            }
            this.n = n;
            this.m = m;
        }
        private int Coordination(int x, int y)
        {
            if(x <= this.n && y <= this.m)
            {
                return y * n + x;
            }
            if(x > n)
            {
                x = x - n;
            }
            if(y > m)
            {
                y = y - m;
            }
            return y*n + x;
        }
        private int Coordination(Animals A)
        {
            int y = 0, x = 0;
            if(A.X <= this.n &&  A.Y <= this.m)
            {
                return A.Y * n + A.X;
            }
            if(A.X > this.n)
            {
                x = A.X - this.n;
            }
            if(A.Y > this.m)
            {
                x = A.Y - this.m;
            }
            return y * n + x;
        }

        private void SetAnimals(Animals animals)
        {
            int index = Coordination(animals);
            field[index].SetAnimals(animals);
            //добавляет животного в конкретный список по координатам
        }

        public void StageField()
        {
            for(int i  = 0; i < field.Count; i++)
            {
                field[i].Iteration();//меняет состояние каждой клетки
            }
            for(int i = 0;i < field.Count; i++)
            {
                List<Animals> ListAnimals = field[i].list;
                for(int j = 0; j < ListAnimals.Count; j++)
                {
                    SetAnimals(ListAnimals[j]);//меняет положение
                }
            }
        }
    }
}

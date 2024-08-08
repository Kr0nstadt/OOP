using System;
using System.Collections;
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

        public List<Cell> Cells => field;
        public Field(int n,int m, List<Animals> animals)
        {
            for(int i = 0;i < animals.Count; i++)
            {
                SetAnimalsField(animals[i]);
            }
            this.n = n;
            this.m = m;
        }
        public Field()
        {
            ReadFile read = new ReadFile();
            this.m = read.mfile;
            this.n = read.nfile;
            field = new List<Cell>();   
            for(int i = 0; i < m * n; i++)
            {
                field.Add(new Cell());
            }
            List<Animals> animals = read.animalsfile;
            for(int i = 0;i < animals.Count; i++)
            {
                SetAnimalsField(animals[i]);
            }

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
            return (y - 1) * n + (x - 1);
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
                while(x > this.n)
                {
                    x = Math.Abs(A.X - this.n);
                }
            }
            if(A.Y > this.m)
            {
                while(y > this.m)
                {
                    y = Math.Abs(A.Y - this.m);
                }
            }
            return Math.Abs(y - 1) * n + Math.Abs(x - 1);
        }

        private void SetAnimalsField(Animals animals)
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
            List<Cell> cells = new List<Cell>();
            
            for(int i = 0;i < field.Count; i++)
            {
                cells.Add(new Cell());
            }

            foreach (Cell cell in field)
            {
                foreach (Animals animal in cell.list)
                {
                    int index = Coordination(animal);//
                    cells[index].SetAnimals(animal);
                }
            }

            this.field = cells;
        }
        public string ToStringCert()
        {
            string txt = "";
            
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    int index = Coordination(j, i);
                    txt += field[index].CountAnimalse;
                }
                txt += "\n";
            }
            return txt;
        }

    }
}

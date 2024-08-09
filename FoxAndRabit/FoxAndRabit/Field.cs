using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FoxAndRabit
{
    public class Field
    {
        private List<Cell> field;
        private int n;
        private int m;
        private string _actionList;

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
                return (y - 1) * n + (x - 1);
            }
            if(x > n)
            {
                while (x > this.n)
                {
                    x = x - this.n;
                }
            }
            else if (x <= 0)
            {
                while (x <= 0)
                {
                    x = x + this.n;
                }
            }
            if (y > m)
            {
                while (y > this.m)
                {
                    y = y - this.m;
                }
            }
            else if (y <= 0)
            {
                while (y <= 0)
                {
                    y = y + this.n;
                }
            }
            return (y - 1) * n + (x - 1);
        }
        private int Coordination(Animals A)
        {
            int y = A.Y, x = A.X;
            if (A.X <= this.n && A.Y <= this.m && A is { X: > 0, Y: > 0 })
            {
                return (y - 1) * n + (x - 1);
            }
            if (A.X > this.n)
            {
                while (x > this.n)
                {
                    x = x - this.n;
                }
            }
            else if (A.X <= 0)
            {
                while (x <= 0)
                {
                    x = x + this.n;
                }
            }
            if (A.Y > this.m)
            {
                while (y > this.m)
                {
                    y = y - this.m;
                }
            }
            else if (A.Y <= 0)
            {
                while (y <= 0)
                {
                    y = y + this.m;
                }
            }
            return (y - 1) * n + (x - 1);
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
                _actionList += field[i].Actions;
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

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int index = Coordination(j + 1, i + 1);
                    txt += field[index].CountAnimalse;
                }
                txt += "\n";
            }
            txt += "\n" + _actionList;
            _actionList = "";
            return txt;
        }

    }
}

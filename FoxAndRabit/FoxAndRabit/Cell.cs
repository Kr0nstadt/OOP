using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxAndRabit
{
    public class Cell
    {
        private List<Animals> animals;
        public List<Animals> list => animals;

        public string CountAnimalse;
        public Cell()
        {
            animals = new List<Animals>();
        }
        public void Iteration()
        {
            List<Rabbit> rabbit = new List<Rabbit>();
            List<Fox> fox = new List<Fox>();
            string countAnimalse = "";
            for(int i = 0; i < animals.Count; i++)
            {
                if(animals[i] is Rabbit)
                {
                    rabbit.Add((Rabbit)animals[i]);
                }
                else
                {
                    fox.Add((Fox)animals[i]);
                }
            }
            if(fox.Count > 0)
            {
                for(int i = 0;i < fox.Count; i++)
                {
                    fox[i].Movement();
                    fox[i].Aging();
                    if (!fox[i].IsAlive)
                    {
                        RemoveAnimals(fox[i]);
                        fox.Remove(fox[i]); 
                    }
                }
                Fox AgeFox;
                if(fox.Count > 1 && rabbit.Count > 0)
                {
                    AgeFox = MaxFox(fox);

                    for(int i = 0;i < rabbit.Count; i++)
                    {
                        animals.Remove(rabbit[i]);
                        AgeFox.Eat();
                        if(AgeFox.EatCount == 2)
                        {
                            AgeFox.EatCount = 0;
                            animals.Add(AgeFox.Reproduction());
                        }
                    }
                }

            }
            else if(rabbit.Count > 0)
            {
                for(int i = 0; i < rabbit.Count; i++)
                {
                    rabbit[i].Movement();
                    if (!rabbit[i].IsAlive)
                    {
                        RemoveAnimals(rabbit[i]);
                    }
                    else if (rabbit[i].Year == 5 || rabbit[i].Year == 10)
                    {
                        SetAnimals(rabbit[i].Reproduction());
                    }
                    rabbit[i].Aging();
                }
            }
            countAnimalse = $"{fox.Count} / {rabbit.Count}";
        }

        public void SetAnimals(Animals a)
        {
            animals.Add(a);
        }

        private void RemoveAnimals(Animals a)
        {
            animals.Remove(a);
        }
        private Fox MaxFox(List<Fox> fox)
        {
                fox.Sort();
                return fox[0];
        }
        public override string ToString()
        {
            return CountAnimalse;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxAndRabit
{
    internal class Cell
    {
        private List<Animals> animals;
        public Cell()
        {
            animals = new List<Animals>();
        }
        private void Iteration()
        {
            List<Rabbit> rabbit = new List<Rabbit>();
            List<Fox> fox = new List<Fox>();
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
                        animals.Remove(fox[i]);
                        fox.Remove(fox[i]); 
                    }
                }
                Fox AgeFox = MaxFox(fox);
                if(rabbit.Count > 0)
                {
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
                        animals.Remove(rabbit[i]);
                    }
                    else (rabbit[i].Year == 5 || rabbit[i].Year == 10){
                        animals.Add(rabbit[i].Reproduction());
                    }
                    rabbit[i].Aging();
                }
            }
        }

        private Fox MaxFox(List<Fox> fox)
        {
            fox.Sort();
            return fox[0];
        }
    }
}

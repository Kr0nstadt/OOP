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
        private string _actions = "";

        public string Actions => _actions;
        public List<Animals> list => animals;

        public string CountAnimalse => Counter();
        public Cell()
        {
            animals = new List<Animals>();
        }
        private string Counter()
        {
            int Fox = 0;
            int Rabbit = 0;
            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i] is Rabbit)
                {
                    Rabbit++;
                }
                else
                {
                    Fox++;
                }
            }
            return $"{Fox}/{Rabbit} ";

        }
        public void Iteration()
        {
            List<Rabbit> rabbit = new List<Rabbit>();
            List<Fox> fox = new List<Fox>();
            string countAnimalse = "";
            for(int i = 0; i < animals.Count; i++)
            {
                if (animals[i].IsAlive)
                {
                    if (animals[i] is Rabbit)
                    {
                        rabbit.Add((Rabbit)animals[i]);
                    }
                    else
                    {
                        fox.Add((Fox)animals[i]);
                    }
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
                        _actions += $"Лиса померла\n";
                    }
                }
                Fox AgeFox;
                if(fox.Count > 0 && rabbit.Count > 0)
                {
                    AgeFox = MaxFox(fox);

                    for(int i = 0;i < rabbit.Count; i++)
                    {
                        animals.Remove(rabbit[i]);
                        _actions += $"Зайку съели, гады, ироды\n";
                        AgeFox.Eat();
                        if(AgeFox.EatCount == 2)
                        {
                            AgeFox.EatCount = 0;
                            _actions += $"Лиса наелась и родила\n";
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
                        _actions += $"Зайцик помер\n";
                        RemoveAnimals(rabbit[i]);
                    }
                    else if (rabbit[i].Year == 5 || rabbit[i].Year == 10)
                    {
                        _actions += $"Зайка плодится\n";
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
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxAndRabit
{
    public abstract class Animals
    {
        protected int year;
        protected int stability;
        protected int x;
        protected int y;
        protected int direction;
        protected bool life = true;

        public Animals(int stability, int x, int y, int direction)
        {
            this.year = 0;
            this.stability = stability;
            this.x = x;
            this.y = y;
            this.direction = direction;
        }

        public abstract void Aging();
        public abstract void Movement();
        public abstract Animals Reproduction();

        public bool IsAlive
        {
            get { return life; }
        }
        public int Y
        {
            get { return y; }
        }
        public int X
        {
            get { return x; }
        }

        protected void Derection()
        {
            direction++;
            if(direction > 3)
            {
                direction = 0;
            }
        }
    }
}

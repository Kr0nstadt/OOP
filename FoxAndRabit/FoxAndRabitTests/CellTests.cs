using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoxAndRabit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxAndRabit.Tests
{
    [TestClass()]
    public class CellTests
    {
        [TestMethod()]
        public void IterationTestCoordinate()
        {
            Fox.val = 0;
            Cell cell = new Cell();
            Fox f1 = new Fox(2, 2, 2, 1);
            Rabbit r1 = new Rabbit(3, 2, 1, 1);
            Rabbit r2 = new Rabbit(4, 1, 2, 2);
            cell.SetAnimals(r1);
            cell.SetAnimals(r2);
            cell.SetAnimals(f1);

            int XBef = cell.list[0].X;
            int YBef = cell.list[0].Y;
            int CountList = cell.list.Count;

            cell.Iteration();


            Assert.AreNotEqual(XBef, cell.list[0].X);
            Assert.AreNotEqual(YBef, cell.list[0].Y);
            Assert.AreNotEqual(CountList, cell.list.Count);//зайку схавали
        }

        [TestMethod()]
        public void IterationTestDead()
        {
            Fox.val = 0;
            Fox r1 = new Fox(3, 2, 1, 1);

            bool LifeBef = r1.IsAlive;

            for(int i = 0;i < 15; i++)
            {
                r1.Aging();
            }

            bool LifeAfter = r1.IsAlive;

            Assert.AreNotEqual (LifeBef, LifeAfter);
        }

        [TestMethod()]

        public void IterationTestRemove()
        {
            Fox.val = 0;
            Fox r1 = new Fox(3, 2, 1, 1);
            Fox r2 = new Fox(3, 2, 1, 1);
            Fox r3 = new Fox(3, 2, 1, 1);
            Cell cell = new Cell();
            cell.SetAnimals(r1);
            cell.SetAnimals(r2);
            cell.SetAnimals(r3);

            int CountBef = cell.list.Count;

            for(int i = 0;i < 1;i++)
            {
                cell.Iteration();
            }

            int CountAfter = cell.list.Count;

            Assert.AreNotEqual(CountBef, CountAfter);
        }
    }
}
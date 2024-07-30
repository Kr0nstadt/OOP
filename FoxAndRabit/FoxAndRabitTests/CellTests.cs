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
        public void IterationTest()
        {
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
    }
}
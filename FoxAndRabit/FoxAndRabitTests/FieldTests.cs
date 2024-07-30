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
    public class FieldTests
    {
        [TestMethod()]
        public void StageFieldTest()
        {
            Fox f1 = new Fox(2, 2, 2, 1);
            Rabbit r1 = new Rabbit(3,2,1,1);
            Rabbit r2 = new Rabbit(4,1,2,2);
            List<Animals> animals = new List<Animals>();
            animals.Add(r1);
            animals.Add(r2);
            animals.Add(f1);

            Field field = new Field(5,5,animals);

            int YBef = animals[0].Y;
            int XBef = animals[0].X;

            field.StageField();

            Assert.AreEqual(XBef, YBef);
        }
    }
}
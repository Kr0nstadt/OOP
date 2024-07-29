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
    public class RabbitTests
    {
        [TestMethod()]
        public void AgingTest()
        {
            Rabbit rabbit = new Rabbit(1, 2, 2, 1);
            int AgeBefore = rabbit.Year;
            rabbit.Aging();
            int AgeAfter = rabbit.Year;
            Assert.AreNotEqual(AgeAfter,AgeBefore);
        }
        [TestMethod()]
        public void AgingTest2()
        {
            Rabbit rabbit = new Rabbit(1, 2, 2, 1);
            bool LifeBefore = rabbit.IsAlive;
            for(int i = 0; i < 10; i++)
            {
                rabbit.Aging();
            }
            bool LifeAfter = rabbit.IsAlive;
            Assert.AreNotEqual(LifeAfter,LifeBefore);
        }
    }
}
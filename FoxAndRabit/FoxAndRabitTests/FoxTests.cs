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
    public class FoxTests
    {
        [TestMethod()]
        public void EatTest()
        {
            Fox fox = new Fox(1, 1, 1, 1);
            int before = fox.EatCount;
            fox.Eat();
            int after = fox.EatCount;
            Assert.AreNotEqual(before, after);
        }

        [TestMethod()]
        public void CompareToTest()
        {
            Fox first = new Fox(1, 1, 1, 1);
            Fox second = new Fox(2, 2, 2, 2);

            Assert.AreEqual(first.CompareTo(second), -1);
            first.Aging();
            Assert.AreEqual(first.CompareTo(second), 0);
            second.Aging();
            Assert.AreEqual(second.CompareTo(first),1);
            
        }
    }
}
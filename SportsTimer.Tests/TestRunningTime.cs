using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SportsTimer.Tests
{
    [TestClass]
    public class TestRunningTime
    {
        [TestMethod]
        public void TestRunningTimeIsNotNull()
        {
            //arreng

            //act
            RunningTime c = new RunningTime();

            //assert
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void TestRunningTimeNum_return3()
        {
            //arreng
            int a = 3;

            //act
            RunningTime c = new RunningTime() { Num=a};

            
            //assert
            Assert.AreEqual(c.Num, a);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleA1._17_VSTools
{
    [TestClass]
    public class SimpleTests
    {
        [TestMethod]
        public void IsTheSeaDeep()
        {
            bool exp = true;
            bool act = Deep.IsTheSeaDeep();


            Assert.AreEqual(exp, act);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestWineSampleCtor()
        {
            string wine = null;
            WineSampler wSam = new WineSampler(wine);
        }

        [TestMethod]
        public void TestWineSampleABC()
        {
            string wine = "Red";
            WineSampler wSam = new WineSampler(wine);
            var res = wSam.GetWineSample("Leather", "Blackberry");
            Assert.AreEqual("RedLeatherBlackberry", res);
        }
    }
}

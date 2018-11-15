using System;
using System.Xml.Linq;
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

        [TestMethod]
        public void TestChamps()
        {
            IChampionLoader iChaps = new TestLoaderChamps();
            WineSampler wS2 = new WineSampler(iChaps);
            var test = wS2.ChampionsByCountry("Italy");
            Assert.AreEqual(FChampExpectedData().ToString(), test.ToString()); //Should have more test for like passing Mexico and zero results!
        }

        internal static string FChampSampleData()
        {
            return @"<Racers><Racer><Firstname>Nino</Firstname><Lastname>Farina</Lastname><Country>Italy</Country><Starts>33</Starts><Wins>5</Wins></Racer><Racer><Firstname>Alberto</Firstname><Lastname>Ascari</Lastname><Country>Italy</Country><Starts>32</Starts><Wins>10</Wins></Racer><Racer><Firstname>Juan Manuel</Firstname><Lastname>Fangio</Lastname><Country>Argentina</Country><Starts>51</Starts><Wins>24</Wins></Racer><Racer><Firstname>Mike</Firstname><Lastname>Hawthorn</Lastname><Country>UK</Country><Starts>45</Starts><Wins>3</Wins></Racer><Racer><Firstname>Phil</Firstname><Lastname>Hill</Lastname><Country>USA</Country><Starts>48</Starts><Wins>3</Wins></Racer><Racer><Firstname>John</Firstname><Lastname>Surtees</Lastname><Country>UK</Country><Starts>111</Starts><Wins>6</Wins></Racer><Racer><Racer><Firstname>Nico</Firstname><Lastname>Rosberg</Lastname><Country>Germany</Country><Starts>206</Starts><Wins>23</Wins></Racer></Racers>";
        }

        internal static XElement FChampExpectedData()
        {
            return XElement.Parse(@"<Driver><Racers Name=""Nino Farina""/>< Racers Name = ""Alberto Ascari"" / ></Driver >");
        }

        internal class TestLoaderChamps : IChampionLoader
        {
            public XElement GetChampions()
            {
                return XElement.Parse(FChampSampleData());
            }
        }
    }

}

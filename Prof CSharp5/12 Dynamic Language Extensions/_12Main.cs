using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using Common;
using ConsoleA1._00_Common;
using Cons = System.Console;

namespace ConsoleA1._12_Dynamic_Language_Extensions
{
    class _12Main
    {
        public static void Main(string[] args)
        {
            Cons.WriteLine("Start Dynamic Language Extensions! - Checking only done at runtime.");

            //var sPerson = new Person();
            dynamic dyPerson = new Person();

            //sPerson.GetFullName("John", "Smithes");   //would not get past compiler.
            try
            {
                var fName = dyPerson.GetFullName("This", "Is!");
                Cons.WriteLine($"fName: {fName}");
            }
            catch (Exception ex)
            {
                Cons.WriteLine($"No method: {ex.Message}");
            }

            //Changing Type completly not just casting it!

            dynamic dyn;
            dyn = 100;
            Cons.WriteLine($"dyn type: {dyn.GetType()}, Value: {dyn}");

            dyn = "I'm a changling, see me change!";
            Cons.WriteLine($"dyn type: {dyn.GetType()}, Value: {dyn}");

            //Person p = new Person() {FirstName = "Fme", LastName = "Lme"};
            //var f = p.FullNameToString();
            //var t = p.ToString();
            
            dyn = new Person() {FirstName = "Dave", LastName = "Testy"};
            try
            {
                Cons.WriteLine($"dyn type: {dyn.GetType()}, Value: {dyn.FullNameToString()}");
            }
            catch (Exception ex)
            {
                Cons.WriteLine($"dyn type: {dyn.GetType()}, Value: {dyn.ToString()}, Ex Message:{ex.Message}");
            }

            //Use my own Dynamic Object....

            dynamic myDyn = new DynamicObj();
            myDyn.NickName = "Cess";
            myDyn.Thing = "Shoes";
            myDyn.Time = 10;
            
            Cons.WriteLine(myDyn.GetType());
            Cons.WriteLine($"Nick Name: {myDyn.NickName}, Thing: {myDyn.Thing}!, Times: {myDyn.Time * 4}");

            //Add a method to dynamic thing
            Func<DateTime, string> GetTomorrowDate = today => today.AddDays(1).ToShortDateString();
            myDyn.GetTomorrow = GetTomorrowDate;
            Cons.WriteLine($"Tomorrow is: {myDyn.GetTomorrow(DateTime.Now)}");
            
            //Add a method to dynamic thing after resharper...
            string GetTomorrowDate2(DateTime today) => today.AddDays(1).ToShortDateString();
            myDyn.GetTomorrow = (Func<DateTime, string>) GetTomorrowDate2;
            Cons.WriteLine($"Tomorrow is: {myDyn.GetTomorrow(DateTime.Now)}");

            //Now some for ExpandoObject!
            dynamic myExpObj = new ExpandoObject();
            myExpObj.NickName = "Cess";
            myExpObj.Thing = "Shoes";
            myExpObj.Time = 10;
            string GetNextDate(DateTime today) => today.AddDays(1).ToShortDateString();
            myExpObj.GetTomorrow = (Func<DateTime, string>) GetNextDate;

            myExpObj.Guests = new List<Person>();
            myExpObj.Guests.Add(new Person() {FirstName = "Ann", LastName = "Franks"});
            myExpObj.Guests.Add(new Person() {FirstName = "Jane", LastName = "Smith"});
            myExpObj.Guests.Add(new Person() {FirstName = "Zen", LastName = "Zero"});

            foreach (var g in myExpObj.Guests)
            {
                Cons.WriteLine($"Guest Name {g}");
            }

            //Read a file
            var fStream = GetFile("Test.csv");
            string[] headLine = fStream.ReadLine()?.Split(',');

            var rList = new List<dynamic>();
            while (fStream.Peek() > 0)
            {
                string[] dataLine = fStream.ReadLine().Split(',');
                dynamic dEntity = new ExpandoObject();
                for (int i = 0; i < headLine.Length; i++)
                {
                    ((IDictionary<string, object>) dEntity).Add(headLine[i], dataLine[i]);
                }

                rList.Add(dEntity);
            }

            foreach (var r in rList)
            {   
                var t = (IDictionary<string, object>)r;
                for (int i= 0; i < t.Count; i++)
                {
                    Cons.WriteLine($"{headLine?[i]}: {t[headLine?[i]]}");
                } 
            }
            
            Cons.ReadKey();
        }

        private static StreamReader GetFile(string fName)
        {
            if (File.Exists(fName))
            {
                return new StreamReader(fName);
            }

            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleA1._05_Generics
{

    class Account
    {
        public string Name { get; private set; }
        public decimal Balance { get; private set; }
        public Account(string name, Decimal balance)
        {
            this.Name = name;
            this.Balance = balance;
        }
    }
    class TAccount : IAccount
    {
        public string Name { get; private set; }
        public decimal Balance { get; private set; }
        public TAccount(string name, Decimal balance)
        {
            this.Name = name;
            this.Balance = balance;
        }
    }

    internal interface IAccount
    {
        decimal Balance { get; }
        string Name { get; }
    }

    class MethodsExample
    {
        public static void Main()
        {
            var accounts = new List<Account>()
            {
                new Account("April", 1523.00m),
                new Account("Bob", 2200m),
                new Account("Cat", 100101.11m)
            };

            Console.WriteLine($"Toatl of all balances := {Algoithm.AddBal(accounts), 2}");

            var tAccounts = new List<TAccount>()
            {
                new TAccount("April", 1523.00m),
                new TAccount("Bob", 2200m),
                new TAccount("Cat", 100101.11m)
            };

            Console.WriteLine($"Toatl of all balances := {Algoithm.AddBal2(tAccounts),2}");

            //Generic Methods with Delegates
            decimal total = Algoithm.AddBal3<TAccount, decimal>(tAccounts, (item, sum) => sum += item.Balance);

            //Generic Methods Specialization
            var mOverloads = new MethodOverloads();
            mOverloads.GenMet("April in May");
            mOverloads.GenMet(123.123d);
            mOverloads.GenMet<decimal>(123.123m);
            mOverloads.GenMet(123);
            mOverloads.Bar(123);
        }
    }

    static class Algoithm
    {
        public static decimal AddBal(IEnumerable<Account> accs)
        {
            decimal total = 0m;
            foreach (Account a in accs)
            {
                total += a.Balance;
            }
            return total;
        }

        public static decimal AddBal2<T>(IEnumerable<T> source) where T: IAccount
        {
            decimal total = 0m;
            foreach (var t in source)
            {
                total += t.Balance;
            }
            return total;
        }

        public static T2 AddBal3<T1, T2>(IEnumerable<T1> source, Func<T1, T2, T2> action)
        {
            T2 total = default(T2);
            foreach (T1 i in source)
            {
                total = action(i, total);
            }
            return total;
        }
    }

    class MethodOverloads
    {
        internal void GenMet<T>(T refIn)
        {
            Console.WriteLine($"GenMet<T>(TrefIn), object type: {refIn.GetType().Name}.");
        }
        internal void GenMet(int refIn)
        {
            Console.WriteLine($"GenMet(int refIn), object type: {refIn.GetType().Name}.");
        }

        internal void Bar<T>(T obj)
        {
            GenMet(obj);
        }
    }
}

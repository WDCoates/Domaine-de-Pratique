using System;
using System.Collections.Generic;
using ConsoleA1._00_Common;
using Con = System.Console;

namespace ConsoleA1._08_DelegatesLambdasEvents
{
    delegate string GetAString();

    class MathOps
    {
        public static double TimesTwo(double val)
        {
            return val * 2;
        }
        
        public static double Sqr(double val) => val * val;
    }

    class MathOpsV
    {
        public static void TimesTwo(double val)
        {
            double res =  val * 2;
            Con.WriteLine($"{res}");
        }

        public static void Sqr(double val)
        {
            double res = val * val;
            Con.WriteLine($"{res}");
        }
    }

    delegate double DoubleOp(double x);
    public struct Delegates
    {
        public static void DemoDelegates()
        {
            int x = 40;
            GetAString fStringMethod = new GetAString(x.ToString);
            GetAString sStringMethod = x.ToString;                      //Also can be done like this...


            Con.WriteLine($"x String is {fStringMethod()}");
            Con.WriteLine($"x String is {sStringMethod()}");

            //Simple Delagte Example
            DoubleOp[] ops =
            {
                MathOps.TimesTwo,
                MathOps.Sqr
            };


            for (int i = 0; i < ops.Length; i++)
            {
                Con.WriteLine($"Using ops[{ops[i].Method}]:");
                ProAndDis(ops[i], 2.0);
                ProAndDis(ops[i], 7.35);
                ProAndDis(ops[i], 1.555);
            }

            //Now with a Func to it.
            Func<double, double>[] fOps =
            {
                MathOps.TimesTwo,
                MathOps.Sqr
            };

            foreach (var o in fOps)
            {
                ProAndDispFunc(o, 3.0);
            }

            //Using our bubble Sort with our Employee Records
            Employee[] emps = {new Employee(1001, (decimal)110233.35), new Employee(1002, (decimal)20233.35), new Employee(1003, (decimal)130233.35)};
            BubbleSorter.Sort(emps, Employee.CompareSalary);

            //Multicast delegates
            Action<double> operAction = MathOpsV.TimesTwo;
            operAction += MathOpsV.Sqr;

            ProcAndDisAction(operAction, 3.5);

            operAction -= MathOpsV.TimesTwo;
            operAction += MathOpsV.TimesTwo;    //Order of execution not guaranteed

            ProcAndDisAction(operAction, 3.5);

            Delegate[] delInv = operAction.GetInvocationList();
            foreach (var delegatev in delInv)
            {
                var a = (Action<double>) delegatev;
                Con.WriteLine($"{a.Method}");

                //Somehow it should be possible to invoke these methods individually.
            }

            Action a1 = One;
            a1 += Two;
            try
            {
                a1();
            }
            catch (Exception ex)
            {
                Con.WriteLine("Exception caught!");
            }

            Delegate[] dA = a1.GetInvocationList();
            foreach (Action d in dA)
            {
                try
                {
                    d();
                }
                catch (Exception ex)
                {
                    Con.WriteLine("Exception what exception!");
                }
            }

            //ToDo: Anonymous Methods P 197
            string mid = ", middle bit, ";

            Func<string, string> anonDel = delegate(string parm)
            {
                parm += mid;
                parm += " end bit.";
                return parm;
            };

            Con.WriteLine(anonDel("Start"));

        }

        static void ProAndDis(DoubleOp action, double val)
        {
            double res = action(val);
            Con.WriteLine($"Value is {val}, result of operation is {res}");
        }

        static void ProAndDispFunc(Func<double, double> action, double val)
        {
            double res = action(val);
            Con.WriteLine($"Value is {val}, result of operation is {res}");
        }

        static void ProcAndDisAction(Action<double> action, double vala)
        {
            action(vala);
        }

        static void One()
        {
            Con.WriteLine($"One!");
            throw new Exception("Error in one!");
        }

        static void Two()
        {
            Con.WriteLine($"Two");
        }
    }

}

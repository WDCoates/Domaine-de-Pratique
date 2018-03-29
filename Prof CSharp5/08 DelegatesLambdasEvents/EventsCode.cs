using System;
using System.Windows;
using Con = System.Console;

namespace ConsoleA1._08_DelegatesLambdasEvents
{
    public class CarInfoEventsArgs : EventArgs
    {
        public string Car { get; private set; }

        public CarInfoEventsArgs(string car)
        {
            this.Car = car;
        }
    }

    public class CarDealer
    {
        public event EventHandler<CarInfoEventsArgs> NewCarInfo;

        public void NewCar(string car)
        {
            Con.WriteLine($"CarDealer: Notice of a new car a {car}.");
            RaiseNewCarInfo(car);
        }

        protected virtual void RaiseNewCarInfo(string car)
        {
            //EventHandler<CarInfoEventsArgs> newCarInfo = NewCarInfo;
            var newCarInfo = NewCarInfo;
            if (newCarInfo != null)
            {
                newCarInfo(this, new CarInfoEventsArgs(car));
            }
        }
    }

    public class Consumer
    {
        private string name;

        public Consumer(string name)
        {
            this.name = name;
        }

        public void NewCarIsHere(object sender, CarInfoEventsArgs e)
        {
            Con.WriteLine($@"{name}: A new {e.Car} has arrived.");
        }
    }

    public class WeakConsumer : IWeakEventListener
    {
        private string name;

        public WeakConsumer(string name)
        {
            this.name = name;
        }
        public void NewCarIsHere(object sender, CarInfoEventsArgs e)
        {
            Con.WriteLine($@"{name}: A new {e.Car} has arrived.");
        }

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            NewCarIsHere(sender, e as CarInfoEventsArgs);
            return true;
        }
    }
}

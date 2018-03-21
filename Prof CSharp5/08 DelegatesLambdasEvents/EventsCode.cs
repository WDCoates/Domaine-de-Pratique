using System;
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
            Con.WriteLine($"CarDealer: new car {car}");
            RaiseNewCarInfo(car);
        }

        protected virtual void RaiseNewCarInfo(string car)
        {
            EventHandler<CarInfoEventsArgs> newCarInfo = NewCarInfo;
            if (newCarInfo != null)
            {
                newCarInfo(this, new CarInfoEventsArgs(car));
            }
        }
    }
}

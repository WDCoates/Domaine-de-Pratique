using System;
using System.Windows;
using System.Threading.Tasks;

namespace ConsoleA1._08_DelegatesLambdasEvents
{
    class WeakCarInfoEM : WeakEventManager
    {
        public static void AddListener(object source, IWeakEventListener wListener)
        {
            CurrentManager.ProtectedAddListener(source, wListener);
        }
        public static void RemoveListener(object source, IWeakEventListener wListener)
        {
            CurrentManager.ProtectedRemoveListener(source, wListener);
        }
        public static WeakCarInfoEM CurrentManager
        {
            get
            {
                WeakCarInfoEM manager = GetCurrentManager(typeof(WeakCarInfoEM)) as WeakCarInfoEM;
                if (manager == null)
                {
                    manager = new WeakCarInfoEM();
                    SetCurrentManager(typeof(WeakCarInfoEM), manager);
                }

                return manager;
            }
        }


        private void CarDealer_NewCarInfo(object sender, CarInfoEventsArgs e)
        {
            DeliverEvent(sender, e);
        }

        protected override void StartListening(object source)
        {
            (source as CarDealer).NewCarInfo += CarDealer_NewCarInfo;
        }

        protected override void StopListening(object source)
        {
            (source as CarDealer).NewCarInfo -= CarDealer_NewCarInfo;
        }
    }
}

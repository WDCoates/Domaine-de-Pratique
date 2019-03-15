using System;
using System.Windows;

namespace WpfClasses
{
    public class MyDepObj : UIElement    //changed to UIElement as it extends the DependencyObject
    {

        public int Value
        {
            get { return (int) GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(MyDepObj),
            new PropertyMetadata(0, OnChangeValue, CoerceValue));


        public int Minimum
        {
            get { return (int) GetValue(MinProp); }
            set { SetValue(MinProp, value); }
        }
        public static readonly DependencyProperty MinProp =
            DependencyProperty.Register("Minimum", typeof(int), typeof(MyDepObj), new PropertyMetadata(0));

        public int Maximum
        {
            get { return (int)GetValue(MaxProp); }
            set { SetValue(MaxProp, value); }
        }

        private static object CoerceValue(DependencyObject dObj, object value)
        {
            int newValue = (int)value;
            MyDepObj cont = (MyDepObj)dObj;

            newValue = Math.Max(cont.Minimum, Math.Min(cont.Maximum, newValue));
            return newValue;
        }
        
        public static readonly DependencyProperty MaxProp =
            DependencyProperty.Register("Maximum", typeof(int), typeof(MyDepObj), new PropertyMetadata(999));

        public static int _oldValue;
        public static int _newValue;

        private static void OnChangeValue(DependencyObject obj, DependencyPropertyChangedEventArgs ceArgs)
        {
            _oldValue = (int) ceArgs.OldValue;
            _newValue = (int) ceArgs.NewValue;

            MyDepObj control = (MyDepObj)obj;
            var e = new RoutedPropertyChangedEventArgs<int>((int) ceArgs.OldValue, (int) ceArgs.NewValue,
                ValueChangedEvent);

            control.OnValueChanged(e);

        }

        protected virtual void OnValueChanged(RoutedPropertyChangedEventArgs<int> args)
        {
            RaiseEvent(args);
        }

        public static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent("ValueChanged",
            RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<int>), typeof(MyDepObj));

        
        public event RoutedPropertyChangedEventHandler<int> ValueChanged
        {
            add => AddHandler(ValueChangedEvent, value);
            remove => RemoveHandler(ValueChangedEvent, value);
        }

    }
}

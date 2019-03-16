using System;
using System.Windows;

namespace ClassLibrary
{
    public class MyAttachedProp : DependencyObject
    {
        public int MyProp1 { get { return (int)GetValue(MyPropProp); } set { SetValue(MyPropProp, value); } }

        private static readonly DependencyProperty MyPropProp = DependencyProperty.RegisterAttached("MyProp1", typeof(int), typeof(MyAttachedProp));

        private static void SetMyProp(UIElement u, int value)
        {
            u.SetValue(MyPropProp, value);
        }

        private static int GetMyProp(UIElement u)
        {
            return (int)u.GetValue(MyPropProp);
        }

    }
}

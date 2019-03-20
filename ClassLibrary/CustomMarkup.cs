using System;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;
using System.Xaml;

namespace ClassLibrary
{
    public enum Operation
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }
    [MarkupExtensionReturnType(typeof(string))]
    public class CustomMarkup : MarkupExtension
    {
        public CustomMarkup()
        {
        }
        public double X { get; set; }
        public double Y { get; set; }
        public Operation Operation { get; set; }
        public override object ProvideValue(IServiceProvider sPro)
        {
            if (sPro.GetService(typeof(IProvideValueTarget)) is IProvideValueTarget pValue)
            {
                var host = pValue.TargetObject as FrameworkElement;
                var prop = pValue.TargetProperty as DependencyProperty;
            }

            double res = 0;

            switch (Operation)
            {
                case Operation.Add:
                    res = X + Y;
                    break;
                case Operation.Subtract:
                    res = X - Y;
                    break;
                case Operation.Multiply:
                    res = X * Y;
                    break;
                case Operation.Divide:
                    res = Math.Abs(Y) > 0 ? 0 : X + Y;
                    break;
                default:
                    throw new ArgumentException("Invalid Operation Request");
            }

            return res.ToString(CultureInfo.InvariantCulture);
        }
    }
}

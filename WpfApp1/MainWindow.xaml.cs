using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassLibrary;

namespace WpfClasses
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> Messages { get; set; } = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = Messages;

            MyAttachedProp.SetMyProp(mapButtonT, 44);
            foreach (object i in LogicalTreeHelper.GetChildren(dp1))
            {
                FrameworkElement fE = i as FrameworkElement;
                if (fE != null)
                    dp1List.Items.Add($"{MyAttachedProp.GetMyProp(fE)}: {fE.Name}");
            }
        }

        private void AddMessage(string message, object sender, RoutedEventArgs eArgs)
        {
            Messages.Add(
                $"{message}, Sender: {(sender as FrameworkElement).Name}; Source: {(eArgs.Source as FrameworkElement).Name}; Origin: {(eArgs.OriginalSource as FrameworkElement).Name}");
        }

        private void OnOuterButtonClick(object sender, RoutedEventArgs e)
        {
            AddMessage("Outer Button Event", sender, e);
        }

        private void OnClickButton2(object sender, RoutedEventArgs e)
        {
            AddMessage("Button 2 Event", sender, e);
            e.Source = sender;
        }

        private void OnInner1(object sender, RoutedEventArgs e)
        {
            AddMessage("Inner 1 Button Event", sender, e);
        }

        private void OnInner2(object sender, RoutedEventArgs e)
        {
            AddMessage("Inner 2 Button Event", sender, e);
            e.Handled = true;
        }
    }
}

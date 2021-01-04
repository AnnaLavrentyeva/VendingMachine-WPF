using System;
using System.Collections.Generic;
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
using WpfApp.src;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MachineView _machineView = new MachineView();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _machineView;
        }

        private void Buy(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            _machineView.Purchase(button.DataContext);
        }

        private void Inser20(object sender, RoutedEventArgs e)
        {
            _machineView.InsertChange(0.20);
        }

        private void Insert50(object sender, RoutedEventArgs e)
        {
            _machineView.InsertChange(0.50);
        }

        private void Insert100(object sender, RoutedEventArgs e)
        {
            _machineView.InsertChange(1.0);
        }

        private void Refill_items(object sender, RoutedEventArgs e)
        {
            _machineView.Refill();
        }

        private void Take_Change(object sender, RoutedEventArgs e)
        {
            _machineView.CollectMoney();
        }

        private void Delete_items(object sender, RoutedEventArgs e)
        {
            _machineView.Empty();
        }
    }
}

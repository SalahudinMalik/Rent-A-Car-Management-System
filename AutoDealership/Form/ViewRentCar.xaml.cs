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
using System.Windows.Shapes;
using CarDALEF;
using ViewModel;
using System.ComponentModel;

namespace AutoDealership.Form
{
    /// <summary>
    /// Interaction logic for ViewRentCar.xaml
    /// </summary>
    public partial class ViewRentCar : Window
    {
        BackgroundWorker worker;
        public ViewRentCar()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync(); 
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            RCB_Factory obj = new RCB_Factory();
            this.Dispatcher.Invoke(new Action(delegate
            {
                List<RCBViewModel> list = obj.GetAll();
                GridRCD.ItemsSource = list;
            }));
        }
    }
}

using CarDALEF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using ViewModel;

namespace AutoDealership.Form
{
    /// <summary>
    /// Interaction logic for DeleteCar.xaml
    /// </summary>
    public partial class DeleteCar : Window
    {
        CarViewModel _vm;
        BackgroundWorker worker;
        public DeleteCar()
        {
          
            InitializeComponent();
            _vm = new CarViewModel();
            this.DataContext = _vm;
        }
        public string rReg()
        {
            string ret = cbCar.Text.ToString();
            return ret;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            CarFactory obj = new CarFactory();
            List<CarViewModel> list = obj.GetAll();
           
            this.Dispatcher.Invoke(new Action(delegate
            {
                cbCar.ItemsSource = list;
                cbCar.DisplayMemberPath = "CA_RegNo";
                cbCar.SelectedValuePath = "CA_ID";
            }));
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            string regno = rReg();
            CarFactory obj = new CarFactory();
            bool result = obj.Delete(regno);
            if (result)
            {
                MessageBox.Show("Data is Deleted ", "Deleted");
                this.Close();
            }
            else
                MessageBox.Show("Data is not Deleted Something is wrong", "Error!");
            
        }
    }
}

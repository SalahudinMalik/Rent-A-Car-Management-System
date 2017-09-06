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
    /// Interaction logic for ReturnCar.xaml
    /// </summary>
    public partial class ReturnCar : Window
    {
        BackgroundWorker worker;
        CarViewModel _vm;
        public ReturnCar()
        {
            InitializeComponent();
            _vm = new CarViewModel();
            this.DataContext = _vm;
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
            List<CarViewModel> list = obj.GetAllCarSF();
            
            this.Dispatcher.Invoke(new Action(delegate
            {
                cbCar.ItemsSource = list;
                cbCar.DisplayMemberPath = "CA_RegNo";
                cbCar.SelectedValuePath = "CA_ID";
            }));
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(cbCar.SelectedValue.ToString());
            CarFactory obj = new CarFactory();
            if(obj.ChangeStatus(id, true))
            {
                MessageBox.Show("Car is Added to Data Successfully", "Added");
                this.Close();
            }
            else
                MessageBox.Show("Car is not Added to Data", "Error!");

        }
    }
}

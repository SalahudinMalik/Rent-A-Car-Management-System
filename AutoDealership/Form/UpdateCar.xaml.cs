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
    /// Interaction logic for UpdateCar.xaml
    /// </summary>
    public partial class UpdateCar : Window
    {
        CarViewModel _vm;
        BackgroundWorker worker;
        public UpdateCar()
        {
            _vm = new CarViewModel();
            InitializeComponent();
            this.DataContext = _vm;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            ChangeCarInfo obj = new ChangeCarInfo(rid());
            obj.ShowDialog();

        }
         void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            CarFactory obj = new CarFactory();
            List<CarViewModel> list = obj.GetAllCar();
            
            this.Dispatcher.Invoke(new Action(delegate
            {
                cbCar.DisplayMemberPath = "CA_RegNo";
                cbCar.SelectedValuePath = "CA_ID";
                cbCar.ItemsSource = list;
            }));
            
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync(); 
            
            
        }
        public int rid()
        {
            int id = int.Parse(cbCar.SelectedValue.ToString());
            return id;
            
        }

    }
}

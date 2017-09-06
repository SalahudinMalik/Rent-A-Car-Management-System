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
    /// Interaction logic for DeleteEmployee.xaml
    /// </summary>
    public partial class DeleteEmployee : Window
    {
        BackgroundWorker worker;
        EmployeeViewModel _vm;
        public DeleteEmployee()
        {
            _vm = new EmployeeViewModel();
            this.DataContext = _vm;
            InitializeComponent();
        }
        public string RName()
        {
            return (cbEmployee.Text.ToString());
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EmployeeFactory obj = new EmployeeFactory();
            List<EmployeeViewModel> list = obj.GetAll();
            this.Dispatcher.Invoke(new Action(delegate
            {
                cbEmployee.ItemsSource = list;
                cbEmployee.DisplayMemberPath = "E_Name";
                cbEmployee.SelectedValuePath = "E_ID";
            }));
           
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();  
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            string name = RName();
            EmployeeFactory obj = new EmployeeFactory();
            bool result = obj.Delete(name);
            if(result)
            {
                MessageBox.Show("Data is Deleted ", "Deleted");
                this.Close();
            }
            else
                MessageBox.Show("Data is not Deleted Something is wrong", "Error!");
            
        }
    }
}

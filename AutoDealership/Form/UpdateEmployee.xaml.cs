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
    /// Interaction logic for UpdateEmployee.xaml
    /// </summary>
    public partial class UpdateEmployee : Window
    {
        EmployeeViewModel _vm;
        public UpdateEmployee()
        {
            _vm = new EmployeeViewModel();
            InitializeComponent();
            this.DataContext = _vm;
        }
        BackgroundWorker worker;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerAsync(); 
            
        }

        void Worker_DoWork(object sender, DoWorkEventArgs e)
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
       public int rID()
       {
           
          int id=int.Parse(cbEmployee.SelectedValue.ToString());
          return id;
       }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
           // int id = ;
           // MessageBox.Show(id.ToString());
            ChangeEmployeeInfo CEIobj = new ChangeEmployeeInfo(rID());
            CEIobj.ShowDialog();
            this.Close();
           
        }

        
    }
}

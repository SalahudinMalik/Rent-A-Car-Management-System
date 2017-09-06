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

namespace AutoDealership.Form
{
    /// <summary>
    /// Interaction logic for ResourceForm.xaml
    /// </summary>
    public partial class ResourceForm : Window
    {
        public ResourceForm()
        {
            InitializeComponent();
        }

        ManageShowRoom MSRobj;
        private void btnSR_Click(object sender, RoutedEventArgs e)
        {
            MSRobj = new ManageShowRoom();
            MSRobj.ShowDialog();
        }
        public EmployeeForm Eobj;
        private void btnME_Click(object sender, RoutedEventArgs e)
        {
            Eobj = new EmployeeForm();
            Eobj.ShowDialog();
        
        }
        public CarsForm CFobj;
        private void btnCars_Click(object sender, RoutedEventArgs e)
        {
            CFobj = new CarsForm();
            CFobj.ShowDialog();


        
        }
    }
}

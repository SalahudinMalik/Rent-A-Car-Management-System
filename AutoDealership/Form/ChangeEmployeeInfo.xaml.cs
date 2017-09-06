using CarDALEF;
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
using ViewModel;

namespace AutoDealership.Form
{
    /// <summary>
    /// Interaction logic for ChangeEmployeeInfo.xaml
    /// </summary>
    public partial class ChangeEmployeeInfo : Window
    {
        int EmployeeId = -1;
        EmployeeViewModel _vm;
        public ChangeEmployeeInfo(int empId)
        {
            InitializeComponent();
            EmployeeId = empId;
            
           
        }
        private void ForceValidation()
        {
            txtName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtPhone.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtDesg.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtSalary.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtAddress.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            EmployeeFactory EFobj = new EmployeeFactory();
            Employee_Table ETobj = EFobj.GetAllByName(EmployeeId);
            _vm = new EmployeeViewModel();
            _vm.E_Name = ETobj.E_Name;
            _vm.E_Address = ETobj.E_Address;
            _vm.E_Desg = ETobj.E_Desg;
            _vm.E_Phone = ETobj.E_Phone;
            _vm.E_Salary = ETobj.E_Salary;
            this.DataContext = _vm;

            
            
                     
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ForceValidation();
            if (Validation.GetHasError(txtName) || Validation.GetHasError(txtPhone)
                || Validation.GetHasError(txtDesg) || Validation.GetHasError(txtSalary)
                || Validation.GetHasError(txtAddress))
            {
                MessageBox.Show("Error Some Data is Missing", "ERROR");
                return;
            }
            EmployeeFactory EFobj = new EmployeeFactory();
            _vm = new EmployeeViewModel();
            Employee_Table Eobj = new Employee_Table();
            Eobj.E_ID = EmployeeId;
            Eobj.E_Name = txtName.Text;
            Eobj.E_Address = txtAddress.Text;
            Eobj.E_Desg = txtDesg.Text;
            Eobj.E_Salary = decimal.Parse(txtSalary.Text.ToString());
            Eobj.E_Phone = int.Parse(txtPhone.Text.ToString());
            if(EFobj.Update(Eobj))
            {
                MessageBox.Show("Data is Changed Successfully", "Changed");
            }
            else
                MessageBox.Show("Data is not Changed", "ERROR");
            this.Close();

        }
    }
}

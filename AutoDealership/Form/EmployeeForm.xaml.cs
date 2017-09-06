using AutoDealership.Form;
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

namespace AutoDealership
{
    /// <summary>
    /// Interaction logic for EmployeeForm.xaml
    /// </summary>
    public partial class EmployeeForm : Window
    {
        EmployeeViewModel _vm;
        public EmployeeForm()
        {
            
            InitializeComponent();
           _vm = new EmployeeViewModel();
           this.DataContext = _vm;
        }
        private void ForceValidation()
        {
            txtName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtPhone.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtDesg.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtSalary.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtAddress.GetBindingExpression(TextBox.TextProperty).UpdateSource();
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
            Employee_Table obj = new Employee_Table();
            obj.E_Name = txtName.Text.Trim();
            int ph = Convert.ToInt32(txtPhone.Text);
            obj.E_Phone = ph;
            obj.E_Desg = txtDesg.Text.Trim();
            obj.E_Address = txtAddress.Text.Trim();
            obj.E_Salary = decimal.Parse(txtSalary.Text);
            EmployeeFactory iobj = new EmployeeFactory();
            if(iobj.insert(obj))
            {
                MessageBox.Show("Data Saved Successfully", "Saved");
                txtName.Text = null;
                txtDesg.Text = null;
                txtAddress.Text = null;
                txtPhone.Text = null;
                txtSalary.Text = null;
            }
            else
                MessageBox.Show("Error in Data ", "Error");
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            UpdateEmployee UEobj = new UpdateEmployee();
            UEobj.ShowDialog();

        }

        private void MenuItem_Click_View(object sender, RoutedEventArgs e)
        {
            ViewEmployee VEobj = new ViewEmployee();
            VEobj.ShowDialog();
        }

        private void MenuItem_Click_Delete(object sender, RoutedEventArgs e)
        {
            DeleteEmployee DEobj = new DeleteEmployee();
            DEobj.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Please Google.", "Tip");
        }
    }
}

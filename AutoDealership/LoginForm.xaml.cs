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
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        LoginViewModel _vm;
        public LoginForm()
        {
            _vm = new LoginViewModel();
            this.DataContext = _vm;
            InitializeComponent();
            

        }
        private void ForceValidation()
        {
            txtuName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtPasword.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            ForceValidation();
            if (Validation.GetHasError(txtPasword) || Validation.GetHasError(txtuName))
            {
                MessageBox.Show("Error Some Data is Missing", "ERROR");
                return;
            }
            ResourceForm RFobj = new ResourceForm();
            LoginFactory obj = new LoginFactory();
            Admin_Table Aobj = new Admin_Table();
            Aobj = obj.GetData(2);
            if (txtuName.Text == Aobj.A_UserName && txtPasword.Text == Aobj.A_Password)
            {
                this.Close();
                RFobj.ShowDialog();
                
            }
            else if (Aobj.A_UserName != txtuName.Text)
            {
                MessageBox.Show("User Name is Wrong Please Enter Again", "Error!");
            }
            else if (txtPasword.Text != Aobj.A_Password)
            {
                MessageBox.Show("Password is Wrong Please Enter Again", "Error!");
            }
           
            else
                MessageBox.Show("Something is Wrong", "Error!");
            
        }
    }
}

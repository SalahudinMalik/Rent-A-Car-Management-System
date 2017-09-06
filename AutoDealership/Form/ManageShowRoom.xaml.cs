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
    /// Interaction logic for ManageShowRoom.xaml
    /// </summary>
    /// 
    public partial class ManageShowRoom : Window
    {
        ShowRModelView _vm;
        public ManageShowRoom()
        {
            InitializeComponent();
            _vm = new ShowRModelView();
            this.DataContext = _vm;
        }
        private void ForceValidation()
        {
            txtShowRName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtCNumber.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtCity.GetBindingExpression(TextBox.TextProperty).UpdateSource();
           
        }
       
        private void MenuItem_Click_Delete(object sender, RoutedEventArgs e)
        {
            DeleteShowroom obj = new DeleteShowroom();
            obj.ShowDialog();
        }

        private void MenuItem_Click_View(object sender, RoutedEventArgs e)
        {
            ViewShowroom obj = new ViewShowroom();
            obj.ShowDialog();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ForceValidation();
            if (Validation.GetHasError(txtShowRName) || Validation.GetHasError(txtCNumber)
                || Validation.GetHasError(txtCity))
            {
                MessageBox.Show("Error Some Data is Missing", "ERROR");
                return;
            }
            ShowRFactory obj = new ShowRFactory();
            ShowRoom SRobj = new ShowRoom();
            City Cobj = new City();
            SRobj.ShowRName = txtShowRName.Text;
            SRobj.SRContectNumber =int.Parse( txtCNumber.Text.ToString());
            Cobj.CityName = txtCity.Text;
            if(obj.insert(Cobj , SRobj))
            {
                MessageBox.Show("Car Showroom is Saved Successfully", "Saved");
            }
            else
                MessageBox.Show("Car Showroom is Not Saved ", "Error!");
            txtCity.Text = null;
            txtCNumber.Text = null;
            txtShowRName.Text = null;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Please Google." , "Tip");
        }
    }
}

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
    /// Interaction logic for CarsForm.xaml
    /// </summary>
    public partial class CarsForm : Window
    {
        CarViewModel _vm;
        public CarsForm()
        {
            InitializeComponent();
            _vm = new CarViewModel();
            this.DataContext = _vm;
        }
        private void ForceValidation()
        {
            txtRegNo.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtColor.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtCompany.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtModel.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ForceValidation();
            if (Validation.GetHasError(txtRegNo) || Validation.GetHasError(txtColor)
                || Validation.GetHasError(txtCompany) || Validation.GetHasError(txtModel))
            {
                MessageBox.Show("Error Some Data is Missing" , "ERROR");
                return;
            }
                
            Car_Table obj = new Car_Table();
            obj.CA_RegNo = txtRegNo.Text.Trim();
            obj.CA_Color = txtColor.Text.Trim();
            obj.CA_Company = txtCompany.Text.Trim();
            obj.CA_Model = int.Parse(txtModel.Text);
            obj.CA_Status = true;
            CarFactory CFobj = new CarFactory();
            if(CFobj.insert(obj))
            {
                MessageBox.Show("Car is Added Successfully", "Data Saved");
            }
            else
                MessageBox.Show("Data Is not Added", "Error");
            txtRegNo.Text = " ";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_Delete(object sender, RoutedEventArgs e)
        {
            DeleteCar DCobj = new DeleteCar();
            DCobj.ShowDialog();
        }

        private void MenuItem_Click_View(object sender, RoutedEventArgs e)
        {
            ViewAllCar CFobj = new ViewAllCar();
            CFobj.ShowDialog();
        }

        private void MenuItem_Click_Update(object sender, RoutedEventArgs e)
        {
            UpdateCar obj = new UpdateCar();
            obj.ShowDialog();
        }

        private void MenuItem_Click_Return(object sender, RoutedEventArgs e)
        {
            ReturnCar obj = new ReturnCar();
            obj.ShowDialog();
        }

    }
}

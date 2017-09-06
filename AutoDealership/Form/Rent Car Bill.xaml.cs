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
    /// Interaction logic for Rent_Car_Bill.xaml
    /// </summary>
    public partial class Rent_Car_Bill : Window
    {
        BackgroundWorker worker;
        RCBViewModel _vm;
        public Rent_Car_Bill()
        {
            InitializeComponent();
            _vm = new RCBViewModel();
            _vm.RCB_DOI = DateTime.Today;
            _vm.RCB_DOR = DateTime.Today;
            this.DataContext = _vm;
            
        }
        private void ForceValidation()
        {
            cbRegNo.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();
            txtName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtPhone.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtAddress.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            //dpDOI.GetBindingExpression(DatePicker.SelectedDateFormatProperty).UpdateSource();
           // dpDOR.GetBindingExpression(DatePicker.SelectedDateFormatProperty).UpdateSource();
            txtRPD.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            cbTax.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();
        }
        decimal totalTemp = 0;
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ForceValidation();
            if (Validation.GetHasError(cbRegNo) || Validation.GetHasError(txtName)
                || Validation.GetHasError(txtPhone) || Validation.GetHasError(txtAddress)
                ||Validation.GetHasError(dpDOI) || Validation.GetHasError(dpDOR)
                || Validation.GetHasError(txtRPD) || Validation.GetHasError(cbTax))
            {
                MessageBox.Show("Error Some Data is Missing", "ERROR");
                return;
            }
            Customer_Table cObj = new Customer_Table();
            RCB_Table rObj = new RCB_Table();
            CarFactory cartFac = new CarFactory();
            rObj.CA_ID = int.Parse(cbRegNo.SelectedValue.ToString());
            cartFac.ChangeStatus(rObj.CA_ID, false);
            cObj.C_Name = txtName.Text.Trim();
            cObj.C_Address = txtAddress.Text.Trim();
            cObj.C_Phone = txtPhone.Text.Trim();
            RCB_Factory obj = new RCB_Factory();
            bool result = obj.insertC(cObj);
            rObj.C_ID = cObj.C_ID;
            DateTime issue , retrn;
            issue = DateTime.Parse( dpDOI.Text);
            retrn =  DateTime.Parse( dpDOR.Text);
            if(issue.Date > retrn.Date)
            {
                MessageBox.Show("Issue Date is Greater than Return Date", "Error");
            }
            else
            { 
                rObj.RCB_DOI = issue;
                rObj.RCB_DOR = retrn;
            }
            TimeSpan ts = retrn - issue ;
            decimal td = ts.Days;
            decimal rpd;
            rpd = decimal.Parse(txtRPD.Text);
            rObj.RCB_RentPD = rpd;
            decimal total;
            total = rpd * td;
           // TotalB.Text = total.ToString();
            
            rObj.T_ID = int.Parse(cbTax.SelectedValue.ToString());
            decimal tax = decimal.Parse(cbTax.Text.ToString());
            tax /= 100;
            //decimal taxd = decimal.Parse(tax.ToString());
            decimal taxp = (total * tax); 
            total +=taxp;

            rObj.RCB_TotalBill = total;
            totalTemp = total;
            TotalB.Text = totalTemp.ToString();
           bool rResult = obj.insertR(rObj);
            if(rResult && result)
            {
                MessageBox.Show("Data is Added Successfully", "Saved");
                txtName.Text = null;
                cbRegNo.SelectedItem = null;
                this.Close();
            }
            else
                MessageBox.Show("Data is not Added", "Error");
            

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
            RCB_Factory gobj = new RCB_Factory();
            this.Dispatcher.Invoke(new Action(delegate
            {
                List<CarViewModel> list = obj.GetAll();
                cbRegNo.ItemsSource = list;
                cbRegNo.DisplayMemberPath = "CA_RegNo";
                cbRegNo.SelectedValuePath = "CA_ID";
                List<Tax_Table> tlist = gobj.GetTax();
                cbTax.ItemsSource = tlist;
                cbTax.DisplayMemberPath = "T_Per";
                cbTax.SelectedValuePath = "T_ID";
            }));
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Please Google.", "Tip");
        }

        private void cbTax_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TotalB.Text = totalTemp.ToString();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ViewRentCar obj = new ViewRentCar();
            obj.ShowDialog();
        }

        
    }
}

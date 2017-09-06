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
    /// Interaction logic for ChangeCarInfo.xaml
    /// </summary>
    public partial class ChangeCarInfo : Window
    {
        int CarId = -1;
        CarViewModel _vm;
        public ChangeCarInfo(int carsid)
        {
            InitializeComponent();
           
            CarId = carsid;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            CarFactory Facobj = new CarFactory();
            Car_Table CTobj = new Car_Table();
            CTobj.CA_ID = CarId;
            CTobj.CA_RegNo = txtRegNo.Text;
            CTobj.CA_Color = txtColor.Text;
            CTobj.CA_Company = txtCompany.Text;
            CTobj.CA_Model = int.Parse(txtModel.Text.ToString());
            if(Facobj.Update(CTobj))
            {
                MessageBox.Show("Data is Saved Successfully", "Saved");
            }
            else
                MessageBox.Show("Data is Not Saved", "Error!");
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            CarFactory obj = new CarFactory();
            Car_Table Cobj = obj.GetAllCarT(CarId);
            _vm.CA_RegNo= Cobj.CA_RegNo;
            _vm.CA_Color = Cobj.CA_Color;
            _vm.CA_Company = Cobj.CA_Company;
            _vm.CA_Model = Cobj.CA_Model;
            _vm = new CarViewModel();
            this.DataContext = _vm;
        }
    }
}

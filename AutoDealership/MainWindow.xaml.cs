using AutoDealership.Form;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;

namespace AutoDealership
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CarViewModel _vm;
        public MainWindow()
        {
            _vm = new CarViewModel();
            this.DataContext = _vm;
            InitializeComponent();
        }
       
       
        public LoginForm LFobj;
        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            LFobj = new LoginForm();
            LFobj.ShowDialog();
        }
        Rent_Car_Bill RCobj;
        private void btnRC_Click(object sender, RoutedEventArgs e)
        {
            
            RCobj = new Rent_Car_Bill();
            RCobj.ShowDialog();
            
        }
       

    }
}

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
    /// Interaction logic for ViewShowroom.xaml
    /// </summary>
    public partial class ViewShowroom : Window
    {
        public ViewShowroom()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowRFactory Facobj = new ShowRFactory();
            List<ShowRModelView> list = Facobj.GetAll();
            SRGrid.ItemsSource = list;
            
            
        }
    }
}
